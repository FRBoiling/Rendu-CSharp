using System;

namespace UtilityLib
{
    public class TimeUtil
    {
        private DateTime prev;

        public void Init()
        {
            prev = DateTime.Now;
        }

        public TimeSpan Update(out bool isPassDay)
        {
            var now = DateTime.Now;
            if (now.Day != prev.Day)
            {
                isPassDay = true;
            }
            else
            {
                isPassDay = false;
            }
            var delta = now - prev;
            prev = now;

            return delta;

        }
        public TimeSpan Update()
        {
            var now = DateTime.Now;
            var delta = now - prev;
            prev = now;

            return delta;
        }

        /// <summary>
        /// 从调用Update到现在的时间
        /// </summary>
        /// <returns></returns>
        public double Getthis()
        {
            var now = DateTime.Now;
            var delta = now - prev;
            return delta.TotalMilliseconds;
        }

        static public bool CheckRefresh(int[] refresh, DateTime lastRefresh)
        {
            if (lastRefresh.Date < DateTime.Today)
            {
                return true;
            }
            else
            {
                foreach (var item in refresh)
                {
                    if (lastRefresh.Hour < item && DateTime.Now.Hour > item)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
