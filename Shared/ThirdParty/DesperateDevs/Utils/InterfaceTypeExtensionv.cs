using System;

namespace DesperateDevs.Utils
{
    public static class InterfaceTypeExtension
    {
        public static bool ImplementsInterface<T>(this Type type)
        {
            if (!type.IsInterface)
                return type.GetInterface(typeof (T).FullName) != null;
            return false;
        }
    }
}