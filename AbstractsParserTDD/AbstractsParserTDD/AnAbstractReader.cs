using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace AbstractsParserTDD
{
    class AnAbstractReader
    {
        public const string RowExtractRegex = "<tr>[\r\n]* <td.*>[\r\n]*([^\x00]*)[\r\n]* </td>[\r\n]*</tr>";
        public const string AuthorRowExtractRegex = "<tr>[\r\n]* <td.*>[\r\n]*([^<]*)<u>([^<]*)</u>([^<]*)[\r\n]* </td>[\r\n]*</tr>";
        public const string IsAuthorRegex = ".*<u>.*</u>.*";
        public const string SpeakerExtractRegex = ".*<u>(.*)</u>.*";
        public const string OtherAuthorsExtractRegex = "(.*)<u>.*</u>(.*)";
        public const string HrExtractRegex = "<hr.*>";

        private StreamReader str;

        

        public AnAbstractReader(string path)
        {
            str = new StreamReader(path);
        }
        public AnAbstractReader()
        {
            str = new StreamReader(Console.OpenStandardInput());
        }


        public List<string> ReadAbstract()
        {
            try
            {
                List<string> Result = new List<string>();
                string bufor = "";

                while (IsNotHr(bufor = ReadRow()))
                {
                    if (IsAutor(bufor))
                    {
                        Result.Add(ExtractSpeaker(bufor));
                        Result.Add(ExtractOtherAuthors(bufor));
                    }
                    else
                        Result.Add(bufor);
                }
                return Result;
            }
            catch
            {
                throw new EndOfStreamException();
            }
        }

        private string ExtractOtherAuthors(string bufor)
        {
            string Wynik="";
            Match m = Regex.Match(bufor, OtherAuthorsExtractRegex);
            Wynik = m.Groups[1].Value+m.Groups[2].Value;
            return Wynik;
        }

        private string ExtractSpeaker(string bufor)
        {
            return Regex.Match(bufor,SpeakerExtractRegex).Groups[1].Value;
        }

        private bool IsAutor(string bufor)
        {
            return Regex.Match(bufor,IsAuthorRegex).Success;
        }

        private bool IsNotHr(string p)
        {
            return !Regex.Match(p,HrExtractRegex).Success;
        }

        public string ReadRow()
        {
            string bufor="";
            Match m;
            Match ma;
            while (true)
            {
                if ((m = MatchRow(bufor)).Success)
                    return ExtractSimpleRow(m);
                else if ((ma = MatchAuthorsRow(bufor)).Success)
                    return ExtractAuthorRow(ma);
                else
                    bufor += str.ReadLine()+"\n";
            }
        }

        private string ExtractSimpleRow(Match m)
        {
            return m.Groups[1].Value;
        }

        private string ExtractAuthorRow(Match ma)
        {
            return ma.Groups[1] + "<u>" + ma.Groups[2] + "</u>" + ma.Groups[3];
        }

        private Match MatchRow(string bufor)
        {
            return Regex.Match(bufor,RowExtractRegex);
        }
        private Match MatchAuthorsRow(string bufor)
        {
            return Regex.Match(bufor, RowExtractRegex);
        }
    }
}
