using System.Collections.Generic;

namespace Rd.Serialization
{
    public interface IConfigurable
    {
        Dictionary<string, string> defaultProperties { get; }

        void Configure(Preferences preferences);
    }
}