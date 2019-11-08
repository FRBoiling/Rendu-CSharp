using Entitas.Extensions;
using Rd.Utils;

namespace Rd.Plugins.Component
{
    public static class ComponentDataExtension
    {
        public static string ToComponentName(this string fullTypeName, bool ignoreNamespaces)
        {
            return ignoreNamespaces
                ? fullTypeName.ShortTypeName().RemoveComponentSuffix()
                : fullTypeName.RemoveDots().RemoveComponentSuffix();
        }
    }
}