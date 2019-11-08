using System;
using Entitas.CodeGeneration.Plugins.Data;

namespace Entitas.CodeGeneration.Plugins.Component.DataProviders.ComponentDataProviders
{
    public class MemberDataComponentDataProvider : IComponentDataProvider
    {
        public void Provide(Type type, ComponentData data)
        {
            var memberData = type.GetPublicMemberInfos()
                .Select(info => new MemberData(
                    info.type.ToCompilableString(),
                    info.name))
                .ToArray();

            data.SetMemberData(memberData);
        }
    }
}