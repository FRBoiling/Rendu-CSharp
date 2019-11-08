using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace Rd.Networking
{
    public static class IPAddressStringExtension
    {
        public static IPAddress ResolveHost(this string host)
        {
            return ((IEnumerable<IPAddress>) Dns.GetHostEntry(host).AddressList).FirstOrDefault<IPAddress>((Func<IPAddress, bool>) (address => address.AddressFamily == AddressFamily.InterNetwork));
        }
    }
}