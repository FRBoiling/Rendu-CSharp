using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DesperateDevs.Utils
{
    public static class AppDomainExtension
    {
        public static Type[] GetAllTypes(this AppDomain appDomain)
        {
            return ((IEnumerable<Assembly>) appDomain.GetAssemblies()).GetAllTypes();
        }

        public static Type[] GetAllTypes(this IEnumerable<Assembly> assemblies)
        {
            List<Type> typeList = new List<Type>();
            foreach (Assembly assembly in assemblies)
            {
                try
                {
                    typeList.AddRange((IEnumerable<Type>) assembly.GetTypes());
                }
                catch (ReflectionTypeLoadException ex)
                {
                    typeList.AddRange(((IEnumerable<Type>) ex.Types).Where<Type>((Func<Type, bool>) (type => type != null)));
                }
            }
            return typeList.ToArray();
        }

        public static Type[] GetNonAbstractTypes<T>(this AppDomain appDomain)
        {
            return appDomain.GetAllTypes().GetNonAbstractTypes<T>();
        }

        public static Type[] GetNonAbstractTypes<T>(this Type[] types)
        {
            return ((IEnumerable<Type>) types).Where<Type>((Func<Type, bool>) (type => !type.IsAbstract)).Where<Type>((Func<Type, bool>) (type => type.ImplementsInterface<T>())).ToArray<Type>();
        }

        public static T[] GetInstancesOf<T>(this AppDomain appDomain)
        {
            return appDomain.GetNonAbstractTypes<T>().GetInstancesOf<T>();
        }

        public static T[] GetInstancesOf<T>(this Type[] types)
        {
            return ((IEnumerable<Type>) types.GetNonAbstractTypes<T>()).Select<Type, T>((Func<Type, T>) (type => (T) Activator.CreateInstance(type))).ToArray<T>();
        }
    }
}