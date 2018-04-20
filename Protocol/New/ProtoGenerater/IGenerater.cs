using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoGenerater
{
    public interface IGenerater
    {
        void Run(CodeFileParser parse);
    }
}
