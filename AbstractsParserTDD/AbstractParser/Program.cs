using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AbstractParser
{
    class Program
    {
        static void Main(string[] args)
        {
            AnAbstractTranslator Translator;
            
            Console.WriteLine("Podaj Katalog:");
            string path = Console.ReadLine();

            string[] Pliki = Directory.GetFiles(path);

            foreach (string name in Pliki)
            {
                if (IsHtml(name))
                {
                    Console.WriteLine(CutHtmlExtention(name));
                    Translator = new AnAbstractTranslator(CutHtmlExtention(name));
                    Translator.TranslateAll();
                    Translator.Close();
                }
            }
            Console.ReadLine();

        }

        private static string CutHtmlExtention(string name)
        {
            return name.Substring(0, name.Length - 5);
        }

        private static bool IsHtml(string name)
        {
            int L=name.Length;
            return String.Compare(".html", name.Substring(L - 5))==0;
        }
    }
}
