using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateServerLib.Auth
{
    public interface IAuth
    {
        void CheckVersion();
        void CheckToken();
    }
}
