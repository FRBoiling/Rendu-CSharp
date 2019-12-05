using System;
using System.Linq;
using Rd.Plugins.Data;
using Rd.Utils;

namespace Rd.Plugins.Component.DataProviders.ComponentDataProviders
{
    public class MemberDataComponentDataProvider : IComponentDataProvider
    {
        public void Provide(Type type, ComponentData data)
        {
            //var memberData = type.GetPublicMemberInfos()
            //    .Select(info => new MemberData(
            //        info.type.ToCompilableString(),
            //        info.name))
            //    .ToArray();
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