using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoGenerater
{
    public class GeneraterManager
    {
        private static Dictionary<int, IGenerater> generaters = new Dictionary<int, IGenerater>();

        public static void Run(CodeFileParser parser)
        {
            foreach (var item in generaters)
            {
                item.Value.Run(parser);
            }
        }

        public static void Add(int type, IGenerater generater)
        {
            if (generaters.ContainsKey(type))
            {

            }
            else
            {
                generaters.Add(type, generater);
            }
        }

    }
}
