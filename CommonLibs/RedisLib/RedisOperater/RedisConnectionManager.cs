using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLib;

namespace RedisLib.RedisOperater
{
    public class RedisConnectionManager: Singleton<RedisConnectionManager>
    {
        private static RedisConnectionManager _instance;
        private static readonly object Locker = new object();

        private ConnectionMultiplexer _conn;

        public ConnectionMultiplexer Conn
        {
            get {
                if (_conn==null)
                {
                    _conn = GetConnection();
                }
                return _conn;
            }
        }

        private ConnectionMultiplexer GetConnection()
        {
            throw new NotImplementedException();
        }
    }
}
