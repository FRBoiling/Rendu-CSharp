using System;
using System.Collections.Generic;
using System.Text;

namespace Rd.Utils
{
    public class Singleton<T> where T : class, new()
    {
        private static T _inst;
        private static readonly object _sysLock = new object();
        public static T Inst
        {
            get
            {
                if (_inst != null) return _inst;
                lock (_sysLock)
                {
                    if (_inst == null)
                    {
                        _inst = new T();
                    }
                }
                return _inst;
            }
        }
    }
}
