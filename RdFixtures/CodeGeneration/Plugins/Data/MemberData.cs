namespace Rd.Plugins.Data
{
    public class MemberData
    {
        public readonly string name;

        public readonly string type;

        public MemberData(string type, string name)
        {
            this.type = type;
            this.name = name;
        }
    }
}