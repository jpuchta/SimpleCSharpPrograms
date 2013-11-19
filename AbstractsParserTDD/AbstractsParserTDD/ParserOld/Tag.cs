using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractsParserTDD
{
    class Tag
    {

        public Tag(string tag)
        {
            this.tag = tag.ToLower();
        }

        private string tag { get; set; }

        public string Opening()
        {
            return "<" + tag + ">";
        }
        public string Closing()
        {
            return "</" + tag + ">";
        }

        public bool AmIOpenedIn(string Tekst)
        {
            return Tekst.ToLower().Contains(Opening());
        }
        public bool AmIClosedIn(string Tekst)
        {
            return Tekst.ToLower().Contains(Closing());
        }



        public int IndexOfOpening(string TestedText)
        {
            return TestedText.ToLower().IndexOf(Opening())+Opening().Length;
        }
        public int IndexOfClosing(string TestedText)
        {
            return TestedText.ToLower().IndexOf(Closing());
        }

    }
}
