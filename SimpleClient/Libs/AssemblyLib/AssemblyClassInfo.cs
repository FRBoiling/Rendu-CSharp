using System.Collections.Generic;
using System.Reflection;

namespace AssemblyLib
{
    /// <summary>
    /// 反射结果类
    /// </summary>
    public class AssemblyClassInfo
    {
        /// <summary>
        /// 完整类名
        /// </summary>
        public string ClassFullName { get; set; }
        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 类实例
        /// </summary>
        public object Class { get; set; }
        /// <summary>
        /// 类的属性
        /// </summary>
        public List<PropertyInfo> Properties { get; set; }
        /// <summary>
        /// 类的方法
        /// </summary>
        public Dictionary<string,MethodInfo> Methods { get; set; }
    }
}
