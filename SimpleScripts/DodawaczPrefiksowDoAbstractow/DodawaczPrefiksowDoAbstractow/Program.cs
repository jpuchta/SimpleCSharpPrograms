using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DodawaczPrefiksowDoAbstractow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj Katalog:");
            string path = Console.ReadLine();

            string[] Pliki = Directory.GetFiles(path);

            Directory.CreateDirectory(path+"\\out");

            string session;
            string type;
            PrefixAdder P;

            foreach (string name in Pliki)
            {
                if (IsCSV(name))
                {
                    Console.WriteLine("Plik: "+name);
                    Console.Write("Kod sesji: ");
                    session=Console.ReadLine();
                    Console.Write("Typ sesji: ");
                    type = Console.ReadLine();
                    P = new PrefixAdder(Prefiks(session,type),name,OutName(name));
                    P.Run();
                    P.Close();
                    Console.WriteLine(name+"\tDone\n============================\n");
                }
            }
            Console.ReadLine();
        }

        private static string OutName(string name)
        {
            return ".\\prefixed" + GetFileName(name);
        }

        private static string GetFileName(string name)
        {
            int WhereFrom=name.LastIndexOf('\\');
            return name.Substring(WhereFrom);
        }

        private static string Prefiks(string session, string type)
        {
            string fulltype;
            if (type == "o")
                fulltype = "oral";
            else if (type == "p")
                fulltype = "poster";
            else
                throw new Exception();
            return "{ " + session + "};{ " + fulltype + "};";
        }

        private static bool IsCSV(string name)
        {
            int L = name.Length;
            return String.Compare(".csv", name.Substring(L - 4)) == 0;
        }
    }
}
