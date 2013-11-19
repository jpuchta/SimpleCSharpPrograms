using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimeoutMultithred
{
    [TestClass]
    public class TimeoutForThreadTest
    {
        [TestMethod,ExpectedException(typeof(AutOfTimeException))]
        public void TestRunWithTimeout()
        {
            int timeOutForThead=100;
            Tajmaut.RunWithTimeout(TimeConsumer, timeOutForThead);
        }

        private void TimeConsumer()
        {
            for (int i = 0; i < 1024*1024; i++)
            {
                for (int j = 0; j < 1024*1024; j++)
                    ;
            }
        }
        private void TimeConsumerViaConsole()
        {
            Console.ReadLine();
        }



        [TestMethod, ExpectedException(typeof(AutOfTimeException))]
        public void TestInterfejsuIRunable()
        {
            Worker Jim = new Worker(1024);
            Tajmaut.RunWithTimeout((IRunable)(Jim), 10);
        }



    }
}
