namespace Rd.Plugins
{
    public static class MemberInfosComponentDataExtension
    {
        public const string COMPONENT_MEMBER_DATA = "Component.MemberData";

        public static MemberData[] GetMemberData(this ComponentData data)
        {
            return (MemberData[]) data[COMPONENT_MEMBER_DATA];
        }

        public static void SetMemberData(this ComponentData data, MemberData[] memberInfos)
        {
            data[COMPONENT_MEMBER_DATA] = memberInfos;
        }
    }
}