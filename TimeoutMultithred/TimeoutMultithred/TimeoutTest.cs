using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimeoutMultithred
{
    [TestClass]
    public class TimeoutTest
    {

        [TestMethod, Timeout(100)]
        public void SleapTest0010()
        {
            Tajmaut.Wait(10);
        }
        [TestMethod, Timeout(100)]
        public void SleapTest0020()
        {
            Tajmaut.Wait(20);
        }
        [TestMethod, Timeout(100)]
        public void SleapTest0040()
        {
            Tajmaut.Wait(40);
        }
        [TestMethod, Timeout(100)]
        public void SleapTest0080()
        {
            Tajmaut.Wait(80);
        }
        [TestMethod, Timeout(1000)]
        public void SleapTest0100()
        {
            Tajmaut.Wait(100);
        }
        [TestMethod, Timeout(1000)]
        public void SleapTest0200()
        {
            Tajmaut.Wait(200);
        }
        [TestMethod, Timeout(1000)]
        public void SleapTest0400()
        {
            Tajmaut.Wait(400);
        }
        [TestMethod, Timeout(1000)]
        public void SleapTest0800()
        {
            Tajmaut.Wait(800);
        }
        [TestMethod, Timeout(1100)]
        public void SleapTest1000()
        {
            Tajmaut.Wait(1000);
        }

    }
}
