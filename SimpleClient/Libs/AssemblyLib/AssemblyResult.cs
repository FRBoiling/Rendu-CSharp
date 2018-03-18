using System;
using System.Collections.Generic;
using System.Reflection;

namespace AssemblyLib
{
    /// <summary>
    /// 反射结果类
    /// </summary>
    public class AssemblyResult
    {
       public Assembly Assembly;
        /// <summary>
        /// 程序集名称
        /// </summary>
        public List<string> AssemblyNameList { get; set; }
        /// <summary>
        /// 类key为ClassName
        /// </summary>
        public Dictionary<string, Type> ClassTypeList { get; set; }
    }
}
