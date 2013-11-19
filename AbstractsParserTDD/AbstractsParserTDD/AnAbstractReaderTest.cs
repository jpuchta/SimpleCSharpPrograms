using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;

namespace AbstractsParserTDD
{
    [TestClass]
    public class AnAbstractReaderTest
    {

        [TestMethod]
        public void ReadedAbstractTest()
        {
            AnAbstractReader AR = new AnAbstractReader("TestData.html");
            AR.ReadAbstract();
        }

        [TestMethod]
        public void IsAbstractReadCorrectly()
        {
            AnAbstractReader AR = new AnAbstractReader("VerySimpleTestData.html");
            AnAbstract A = new AnAbstract(AR.ReadAbstract());

            Assert.AreEqual<string>(" Numer", A.ID);
            Assert.AreEqual<string>(" Tytuł", A.Title);
            Assert.AreEqual<string>("Speaker", A.Speaker);
            Assert.AreEqual<string>(" , OtherAuthor", A.OtherAutors);
            Assert.AreEqual<string>(" Country", A.Country);
            Assert.AreEqual<string>(" e@ma.il", A.eMail);
            Assert.AreEqual<string>(" Treść1\n Treść2\n $1$\n ", A.Tresc);
        }

        [TestMethod]
        public void ReadAbstractsList()
        {
            AnAbstractReader AR = new AnAbstractReader("TestData.html");
            List<AnAbstract> Bu=new List<AnAbstract>();

            bool  czyniekoniec=true;

            while (czyniekoniec)
            {
                try
                {
                    Bu.Add(new AnAbstract(AR.ReadAbstract()));
                }
                catch (EndOfStreamException e)
                {
                    czyniekoniec=false;
                }
            }
        }
    }
}
