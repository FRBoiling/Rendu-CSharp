using System.Collections.Generic;

namespace Rd.CodeGeneration
{
    public interface ICachable
    {
        Dictionary<string, object> objectCache { get; set; }
    }
}