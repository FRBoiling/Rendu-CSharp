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
            return appDomain.GetAssemblies().GetAllTypes();
        }

        public static Type[] GetAllTypes(this IEnumerable<Assembly> assemblies)
        {
            var typeList = new List<Type>();
            foreach (var assembly in assemblies)
                try
                {
                    typeList.AddRange(assembly.GetTypes());
                }
                catch (ReflectionTypeLoadException ex)
                {
                    typeList.AddRange(ex.Types.Where(type => type != null));
                }

            return typeList.ToArray();
        }

        public static Type[] GetNonAbstractTypes<T>(this AppDomain appDomain)
        {
            return appDomain.GetAllTypes().GetNonAbstractTypes<T>();
        }

        public static Type[] GetNonAbstractTypes<T>(this Type[] types)
        {
            return types.Where(type => !type.IsAbstract).Where(type => type.ImplementsInterface<T>()).ToArray();
        }

        public static T[] GetInstancesOf<T>(this AppDomain appDomain)
        {
            return appDomain.GetNonAbstractTypes<T>().GetInstancesOf<T>();
        }

        public static T[] GetInstancesOf<T>(this Type[] types)
        {
            return types.GetNonAbstractTypes<T>().Select(type => (T) Activator.CreateInstance(type)).ToArray();
        }
    }
}