using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AbstractsParserTDD
{
    [TestClass]
    public class TagTest
    {
        [TestMethod]
        public void IntexOfOpeningTest()
        {
            Tag T = new Tag("bu");
            string s = "abc<bu>d";
            Assert.AreEqual<int>(7, T.IndexOfOpening(s));
        }
        public void IndexOfClosingTest()
        {
            Tag T = new Tag("bu");
            string s = "abc</bu>d";
            Assert.AreEqual<int>(2, T.IndexOfClosing(s));
        }
    }
}
