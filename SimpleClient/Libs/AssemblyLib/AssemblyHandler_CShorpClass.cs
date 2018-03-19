using LogLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AssemblyLib
{
    /// <summary>
    /// 反射处理类
    /// </summary>
    public partial class AssemblyHandler
    {
        public object GetCSharpClassObj(string assemblyName, string className)
        {
            Assembly assembly = LoadCSharpAssembly(assemblyName);
            if (assembly==null)
            {
                return null;
            }
            return ActionAssembly(assembly,className);
        }

        public static Assembly LoadCSharpAssembly(string pathName)
        {
            byte[] bFile = null;
            try
            {
                using (FileStream fs = new FileStream(pathName, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        bFile = br.ReadBytes((int)fs.Length);
                        if (pathName.EndsWith(".dll"))
                        {
                            string pathName2 = pathName.Substring(0, pathName.LastIndexOf(".")) + ".pdb";
                            if (File.Exists(pathName2))
                            {
                                byte[] bFile2 = null;
                                using (FileStream fs2 = new FileStream(pathName2, FileMode.Open, FileAccess.Read))
                                {
                                    using (BinaryReader br2 = new BinaryReader(fs2))
                                    {
                                        bFile2 = br2.ReadBytes((int)fs2.Length);

                                        Assembly assembly = Assembly.Load(bFile, bFile2);
                                        return assembly;
                                    }
                                }
                            }
                            else
                            {
                                Assembly assembly = Assembly.Load(bFile);
                                return assembly;
                            }

                        }
                        else
                        {
                            Assembly assembly = Assembly.Load(bFile);
                            return assembly;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error("LoadCSharpAssembly error {0}", e.ToString());
                return null;
            }
            
        }

        /// <summary>
        /// 返回加载出来的实例
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="tempInstances"></param>
        /// <param name="retStrs"></param>
        public static object ActionAssembly(Assembly assembly, string Name)
        {
            //获取加载的所有对象模型
            Type[] instances = assembly.GetExportedTypes();

            try
            {

                //生成实例
                return assembly.CreateInstance(Name);
            }
            catch (Exception ex)
            {
                Log.Error("动态加载Error：" + ex.Message);
                return null;
            }

        }
    }
}
