using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimeoutMultithred
{
    class Tajmaut
    {
        public static void Wait(int milliseconds)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (true)
            {
                if (stopwatch.ElapsedMilliseconds >= milliseconds)
                {
                    break;
                }
                Thread.Sleep(1); //so processor can rest for a while
            }
        }

        public static void RunWithTimeout(Action TimeConsumer, int timeOutForThead)
        {
            Thread RobionaAkcja=new Thread(new ThreadStart(TimeConsumer));
            RobionaAkcja.Start();
            Wait(timeOutForThead);
            if (RobionaAkcja.IsAlive)
            {
                RobionaAkcja.Abort();
                throw new AutOfTimeException();
            }
        }

        public static void RunWithTimeout(IRunable obj, int timeOutForThread)
        {
            RunWithTimeout(obj.Run, timeOutForThread);
        }

        internal static void Assertion(IRunable Object, int miliseconds, string name="")
        {
            try
            {
                RunWithTimeout(Object, miliseconds);
            }
            catch (AutOfTimeException e)
            {
                string message = AssertionMessage(Object, miliseconds, name);
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail(message);
            }
        }

        private static string AssertionMessage(IRunable Object, int miliseconds, string name)
        {
            string AssertionName;
            if (name == "")
                AssertionName=Object.ObjectsName()+".Run()";
            else
                AssertionName=name;
            return AssertionName + " has exceeded " + miliseconds + " miliseconds.";
        }
    }
}
