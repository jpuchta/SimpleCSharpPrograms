using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractsParserTDD
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
            ID = removeLastEnter(Pola[0]);
            Title = removeLastEnter(Pola[1]);
            Speaker = removeLastEnter(Pola[2]);
            OtherAutors = removeLastEnter(Pola[3]);
            Country = removeLastEnter(Pola[4]);
            eMail = removeLastEnter(Pola[5]);
            Tresc = removeLastEnter(Pola[6]);
        }

        private string removeLastEnter(string s)
        {
            if (s[s.Length - 1] == '\n')
                return s.Substring(0, s.Length - 1);
            else
                return s;
        }


        public override string ToString()
        {
            string Result = "ID:\t" + ID + "\nTitle:\t" + Title + "\nSpeaker:\t" + Speaker + "\nOtherAutors:\t" + OtherAutors + "\nCountry:\n" + Country + "\ne-mail:\t" + eMail + "\nTresc:\n" + Tresc;
            return Result;
        }

    }

}
