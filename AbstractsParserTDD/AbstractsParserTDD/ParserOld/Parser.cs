using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractsParserTDD
{
    class Parser
    {
        public static bool OpensTag(string tag, string TestowanyTekst)
        {
            Tag T = new Tag(tag);
            return T.AmIOpenedIn(TestowanyTekst);
        }


        public static bool ClosesTag(string tag, string TestowanyTekst)
        {
            Tag T = new Tag(tag);
            return T.AmIClosedIn(TestowanyTekst);
        }

        public static string ExtractInsideTags(string tag, string TestedText)
        {
            Tag T = new Tag(tag);
            if (OpensTag(tag, TestedText) && ClosesTag(tag, TestedText))
            {
                int startIndex = T.IndexOfOpening(TestedText);
                int endIndex =T.IndexOfClosing(TestedText);
                return TestedText.Substring(startIndex, endIndex-startIndex);
            }
            else
                throw new NotParsingTagsException(tag, TestedText);
        }
    }
}
