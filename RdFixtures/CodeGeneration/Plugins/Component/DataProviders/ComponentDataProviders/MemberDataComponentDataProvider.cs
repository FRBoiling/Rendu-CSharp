using System;
using System.Linq;
using Rd.Utils;

namespace Rd.Plugins
{
    public class MemberDataComponentDataProvider : IComponentDataProvider
    {
        public void Provide(Type type, ComponentData data)
        {
            var publicMemberInfos= type.GetPublicMemberInfos();
            var memberData = publicMemberInfos
                .Select(info => new MemberData(
                    info.type.ToCompilableString(),
                    info.name))
                .ToArray();
            data.SetMemberData(memberData);
        }
    }
}