using System;
using DesperateDevs.Serialization;

namespace CodeGenerator
{
    public class RDPreferences : Preferences
    {
        public RDPreferences(string properties, string userPoperties = null)
            : base(new Properties(properties), new Properties(userPoperties ?? string.Empty)) {
        }
    }
}