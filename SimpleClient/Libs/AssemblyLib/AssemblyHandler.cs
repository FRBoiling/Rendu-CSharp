using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AssemblyLib
{
    /// <summary>
    /// 反射处理类
    /// </summary>
    public class AssemblyHandler
    {
        string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"..\..\..\ThirdLib";
        //D:\NewProject\ProjectX\Bin\Server\Message.ClientProtocol.dll
        /// <summary>
        /// 获取程序集名称列表
        /// </summary>
        /// <returns></returns>
        public AssemblyResult GetAssemblyName()
        {
            AssemblyResult result = new AssemblyResult();
            string[] dicFileName = Directory.GetFileSystemEntries(path);
            if (dicFileName!=null)
            {
                List<string> assemblyList = new List<string>();
                foreach (var item in dicFileName)
                {
                    assemblyList.Add(item.Substring(item.LastIndexOf('/') + 1));
                }
                result.AssemblyNameList = assemblyList;
            }
            return result;
        }

        /// <summary>
        /// 获取程序集中的类名
        /// </summary>
        /// <param name="assemblyName">程序集</param>
        /// <returns></returns>
        public AssemblyResult GetClassName(string assemblyName)
        {
            AssemblyResult result = new AssemblyResult();
            if (!String.IsNullOrEmpty(assemblyName))
            {
                Assembly assembly = Assembly.LoadFrom(assemblyName);
                result.Assembly = assembly;
                Type[] types = assembly.GetTypes();
                Dictionary<string, Type> classTypeList = new Dictionary<string, Type>();
                foreach (var item in types)
                {
                    if (classTypeList.ContainsKey(item.FullName))
                    {
                    }
                    else
                    {
                        classTypeList.Add(item.FullName, item);
                    }
                }
                result.ClassTypeList = classTypeList;
            }
            return result;
        }

        /// <summary>
        /// 获取类的属性、方法
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public AssemblyClassInfo GetClassInfo(string assemblyName,string className)
        {
            AssemblyClassInfo result = new AssemblyClassInfo();
            result.ClassFullName = className;
            if (!String.IsNullOrEmpty(assemblyName) && !String.IsNullOrEmpty(className))
            {
                Assembly assembly = Assembly.LoadFrom(assemblyName);
                Type type = assembly.GetType(className, true, true);
                if (type!=null)
                {
                    result.ClassFullName = type.FullName;
                    result.ClassName = type.Name;
                    List<PropertyInfo> propertieList = new List<PropertyInfo>();
                    PropertyInfo[] propertyinfo = type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    foreach (var item in propertyinfo)
                    {
                        propertieList.Add(item);
                    }
                    result.Properties = propertieList;

                    //类的方法
                    List<MethodInfo> methods = new List<MethodInfo>();
                    MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    foreach (var item in methodInfos)
                    {
                        methods.Add(item);
                    }
                    result.Methods = methods;
                }
            }
            return result;
        }



    }
}
