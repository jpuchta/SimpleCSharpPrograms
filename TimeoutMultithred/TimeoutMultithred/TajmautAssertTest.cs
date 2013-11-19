using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimeoutMultithred
{
    [TestClass]
    public class TajmautAssertTest
    {
        [TestMethod]
        public void TestUseOfTajmautAssertMethod()
        {
            Worker Alan = new Worker(62, "Alan");
            Worker Bob = new Worker(128, "Bob");
            Worker Clark = new Worker(256, "Clark");
            Worker Dylan = new Worker(512, "Dylan");
            Worker Evan = new Worker(1025, "Evan");

            Tajmaut.Assertion(Alan, 300);
            Tajmaut.Assertion(Bob, 600);
            Tajmaut.Assertion(Clark, 1200);
            Tajmaut.Assertion(Dylan, 2400, "4");
            Tajmaut.Assertion(Evan, 4800, "5");
        }

        //Potrzeba napisac kilka testow tego, jak reaguje moja asercja.
    }
}
