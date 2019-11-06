using System;
using System.Linq;
using DesperateDevs.Utils;

namespace Entitas.CodeGeneration.Plugins
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