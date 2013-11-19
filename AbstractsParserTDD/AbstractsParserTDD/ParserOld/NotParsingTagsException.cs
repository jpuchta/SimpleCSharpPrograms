using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractsParserTDD
{
    class NotParsingTagsException : Exception
    {
        private string tag;
        private string TestedText;

        public NotParsingTagsException(string tag, string TestedText)
        {
            // TODO: Complete member initialization
            this.tag = tag;
            this.TestedText = TestedText;
        }

    }
}
