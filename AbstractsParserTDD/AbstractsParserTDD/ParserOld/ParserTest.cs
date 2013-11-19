using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AbstractsParserTDD
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void OpensTagTest()
        {
            string TD_Open = "asdf<td>asd";
            string TD_Close = "asdf</td>assa";
            string T_Open = "asdf<tt>adf";

            Assert.IsTrue(Parser.OpensTag("td", TD_Open));
            Assert.IsFalse(Parser.OpensTag("td", TD_Close));
            Assert.IsFalse(Parser.OpensTag("td", T_Open));
            Assert.IsTrue(Parser.OpensTag("tt", T_Open));
        }

        [TestMethod]
        public void IsOpensTagCaseInsensitiveTest()
        {
            string t_Open = "asdf<t>asd";
            string T_Open = "asdf<T>asd";
            string t_tag = "t";
            string T_tag = "T";

            Assert.IsTrue(Parser.OpensTag(t_tag, t_Open));
            Assert.IsTrue(Parser.OpensTag(t_tag, T_Open));
            Assert.IsTrue(Parser.OpensTag(T_tag, t_Open));
            Assert.IsTrue(Parser.OpensTag(T_tag, T_Open));
        }

        [TestMethod]
        public void ClosesTagTest()
        {
            string TD_Open = "asdf<td>asd";
            string TD_Close = "asdf</td>assa";
            string T_Open = "asdf<tt>adf</tt>";

            Assert.IsFalse(Parser.ClosesTag("td", TD_Open));
            Assert.IsTrue(Parser.ClosesTag("td", TD_Close));
            Assert.IsFalse(Parser.ClosesTag("td", T_Open));
            Assert.IsTrue(Parser.ClosesTag("tt", T_Open));
        }

        [TestMethod]
        public void IsClosesTagCaseInsensitiveTest()
        {
            string t_Close = "asdf</t>asd";
            string T_Close = "asdf</T>asd";
            string t_tag = "t";
            string T_tag = "T";

            Assert.IsTrue(Parser.ClosesTag(t_tag, t_Close));
            Assert.IsTrue(Parser.ClosesTag(t_tag, T_Close));
            Assert.IsTrue(Parser.ClosesTag(T_tag, t_Close));
            Assert.IsTrue(Parser.ClosesTag(T_tag, T_Close));
        }


        [TestMethod]
        public void ExtractInsideTagsTest()
        {
            string tag = "t";
            string TestedText = "asdbtr<t>abc</t>asdf";

            Assert.AreEqual<string>("abc", Parser.ExtractInsideTags(tag, TestedText));
        }

        [TestMethod, ExpectedException(typeof(NotParsingTagsException))]
        public void ExtractInsideTagsForNotClosedTag()
        {
            string tag = "t";
            string TestedText = "asdbtr<t>abc<t>asdf";
            Parser.ExtractInsideTags(tag, TestedText);
        }
        [TestMethod, ExpectedException(typeof(NotParsingTagsException))]
        public void ExtractInsideTagsForNotOpenedTag()
        {
            string tag = "t";
            string TestedText = "asdbtr</t>abcasdf";
            Parser.ExtractInsideTags(tag, TestedText);
        }


    }
}
