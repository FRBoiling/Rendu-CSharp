using AssemblyLib;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;

namespace GenerateCodeLib
{
    public class ParseCode
    {
        /// <summary>
        /// 根据反射读取协议dll生成协议解析源码
        /// </summary>
        /// <param name="assemblyName"></param>
        public static string AssemblyParseDll(string assemblyName)
        {
            AssemblyHandler handler = new AssemblyHandler();
            AssemblyResult result = handler.GetClassName(assemblyName);
            result.AssemblyNameList = new List<string>();
            result.AssemblyNameList.Add(assemblyName);

            string strGenerateCode = GenerateCodeModel.GenerateCode(result.ClassTypeList);
            string codeFileName = "GateServer_Code.cs";
            string codeFileFullName = @"..\..\SimpleClient\Libs\ClientLib\" + codeFileName;
            FileInfo fCodeFileName = new FileInfo(codeFileFullName);
            StreamWriter wResponseRecv = fCodeFileName.CreateText();
            wResponseRecv.WriteLine(strGenerateCode);
            wResponseRecv.Close();

            return strGenerateCode;
        }

        public static string AssemblyParseDll(string assemblyName, out AssemblyResult result)
        {
            AssemblyHandler handler = new AssemblyHandler();
            result = handler.GetClassName(assemblyName);
            result.AssemblyNameList = new List<string>();
            result.AssemblyNameList.Add(assemblyName);

            string strGenerateCode = GenerateCodeModel.GenerateCode(result.ClassTypeList);
            string codeFileName = "GateServer_Code.cs";
            string codeFileFullName = @"..\..\SimpleClient\Libs\ClientLib\" + codeFileName;
            FileInfo fCodeFileName = new FileInfo(codeFileFullName);
            StreamWriter wResponseRecv = fCodeFileName.CreateText();
            wResponseRecv.WriteLine(strGenerateCode);
            wResponseRecv.Close();

            return strGenerateCode;
        }


        /// <summary>
        /// 动态编译并执行代码
        /// </summary>
        /// <param name="filesNames">代码</param>
        /// <param name="newPath">输出dll路径</param>
        /// <returns>返回输出内容</returns>
        public static CompilerResults DebugRun(string [] filesNames, string newPath)
        {
            CSharpCodeProvider complier = new CSharpCodeProvider();

            CompilerParameters paras = new CompilerParameters();

            paras.ReferencedAssemblies.Add(@"System.dll");
            paras.ReferencedAssemblies.Add(@"System.IO.dll");
            paras.ReferencedAssemblies.Add(@"System.Xml.dll");
            paras.ReferencedAssemblies.Add(@"ClientProtocol.dll");
            paras.ReferencedAssemblies.Add(@"protobuf-net.dll");
            paras.ReferencedAssemblies.Add(@"LogLib.dll");
            paras.ReferencedAssemblies.Add(@"ServerFrameWork.dll");
            paras.ReferencedAssemblies.Add(@"TcpLib.dll");
            paras.ReferencedAssemblies.Add(@"UtilityLib.dll");
            paras.ReferencedAssemblies.Add(@"ApiLib.dll");
            paras.ReferencedAssemblies.Add(@"GenerateCodeLib.dll");

            paras.GenerateInMemory = false;
            paras.GenerateExecutable = false;
            paras.OutputAssembly = newPath;

            CompilerResults result = complier.CompileAssemblyFromFile(paras,filesNames);

         
            return result;
        }
    }
}
