using System;

namespace Rd.Utils
{
    public static class InterfaceTypeExtension
    {
        public static bool ImplementsInterface<T>(this Type type)
        {
            if (!type.IsInterface)
                return type.GetInterface(typeof(T).FullName) != null;
            return false;
        }

        public static bool ImplementsInterface(this Type type,string interfaceName)
        {
            if (!type.IsInterface)
            {
                var iInterface = type.GetInterface(interfaceName);
                return iInterface != null;
            }
            return false;
        }
    }
}