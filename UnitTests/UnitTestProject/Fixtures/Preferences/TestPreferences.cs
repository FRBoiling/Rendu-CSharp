using Rd.Serialization;

namespace UnitTestProject.Fixtures.Preferences
{
    public class TestPreferences : Rd.Serialization.Preferences
    {
        public TestPreferences(string properties, string userPoperties = null)
            : base(new Properties(properties), new Properties(userPoperties ?? string.Empty))
        {
        }
    }
}