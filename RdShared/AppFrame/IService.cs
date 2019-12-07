using System;
using System.Collections.Generic;
using System.Text;

namespace AppFrame
{
    public interface IService
    {
        void Start();
        void Update();
        void Stop();
        void Run(string[] args);
    }
}
