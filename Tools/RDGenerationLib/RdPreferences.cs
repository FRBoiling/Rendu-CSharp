using DesperateDevs.Serialization;

namespace RDGenerationLib
{
    public class RdPreferences : Preferences
    {
        public RdPreferences(string properties, string userPoperties = null)
            : base(new Properties(properties), new Properties(userPoperties ?? string.Empty))
        {
        }
    }
}