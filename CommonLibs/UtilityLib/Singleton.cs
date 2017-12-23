using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLib
{
    public class Singleton<T> where T:class,new()
    {
        private static T _inst;
        private static readonly object _sysLock = new object();
        public static T Inst
        {
            get
            {
                if (_inst == null)
                {
                    lock(_sysLock)
                    {
                        if (_inst == null)
                        {
                            _inst = new T();
                        }
                    }
                }
                return _inst;
            }
        }
    }
}
