using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AbstractParser
{
    class AnAbstract
    {
        public string ID;
        public string Title;
        public string Speaker;
        public string OtherAutors;
        public string eMail;
        public string Country;
        public string Tresc;

        public AnAbstract(List<string> Pola)
        {
            ID = Reformat(Pola[0]);
            Title = Reformat(Pola[1]);
            Speaker = Reformat(Pola[2]);
            OtherAutors = Reformat(Pola[3]);
            Country = Reformat(Pola[4]);
            eMail = Reformat(Pola[5]);
            Tresc = Reformat(Pola[6]);
        }

        private string Reformat(string s)
        {
            return (change_newlines(change_tabs(RemoveLastNewline(s))));
        }

        private string RemoveLastNewline(string s)
        {
            if (s[s.Length - 1] == '\n')
                return s.Substring(0, s.Length - 1);
            else
                return s;
        }

        private string change_newlines(string s)
        {
            return s.Replace("\n", "\\n");
        }
        private string change_tabs(string s)
        {
            return s.Replace("\t", "\\t");
        }

        //stare tostring, potem zrobilem tostring na zyczenie Adama
/*        public override string ToString()
        {
            string Result = "ID:\t" + ID + "\nTitle:\t" + Title + "\nSpeaker:\t" + Speaker + "\nOtherAutors:\t" + OtherAutors + "\nCountry:\n" + Country + "\ne-mail:\t" + eMail + "\nTresc:\n" + Tresc;
            return Result;
        }
        */

        public override string ToString() //Na zyczenie Adama
        {
            return AdamsWrap(ID) + AdamsWrap(Title) + AdamsWrap(OtherAutors) + AdamsWrap(Speaker) + AdamsWrap(Tresc);
        }

        private string AdamsWrap(string s)
        {
            return "{" + s + "};";
        }

        public XElement ToXml()
        {
            XElement element = new XElement("abstract", new XElement("id",ID), new XElement("title",Title),new XElement("speaker",Speaker),new XElement("other_authors",OtherAutors),new XElement("email",eMail), new XElement("country",Country), new XElement("content",Tresc));
            return element;
        }

        public string ToXml(int level)
        {
            int L = level + 1;
            string inside = LittleTagWrap("id", ID, L) + LittleTagWrap("title", Title, L) + LittleTagWrap("speaker", Speaker, L) + LittleTagWrap("other", OtherAutors, L) + LittleTagWrap("email", eMail, L) + LittleTagWrap("country", Country, L) + BigTagWrap("content", Tresc, L);
            return BigTagWrap("abstract", inside, level);
        }

        private string LittleTagWrap(string tag,string text,int level=0)
        {
            return Tabs(level)+"<" + tag + ">" + text + "</" + tag + ">\n";
        }
        private string BigTagWrap(string tag, string text, int level=0)
        {
            return Tabs(level) + "<" + tag + ">\n" + Tabs(level + 1) +text + "\n"+Tabs(level)+"</" + tag + ">\n";
        }
        private string Tabs(int level)
        {
            string result = "";
            while (level>0)
                result+="\t";
            return result;
        }
    }
}
