using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeoutMultithred
{
    public interface IRunable
    {
        void Run();
        string ObjectsName();
    }
}
