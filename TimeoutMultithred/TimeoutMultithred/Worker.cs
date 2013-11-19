using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeoutMultithred
{
    class Worker : IRunable
    {
        private int N;
        private string name;

        public Worker(int N)
        { this.N = N; this.name = "Worker"; }

        public Worker(int N, string Name)
        { this.N = N; this.name = Name; }

        public void Run()
        {
            TimeConsumer(N);
        }
        private void TimeConsumer(int N)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < 1024 * 1024; j++)
                    ;
            }
        }

        public string ObjectsName()
        {
            return name;
        }
    }
}
