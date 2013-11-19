using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MergerAbstraktuf
{
    class Program
    {
        static void Main(string[] args)
        {

            Directory.CreateDirectory("./Zmergowane");
            StreamWriter Wynik = new StreamWriter("./Zmergowane/Wynik.csv");

            StreamReader Input;

            string[] pliki = Directory.GetFiles(".");


            foreach (string name in pliki)
            {
                if (IsCSV(name))
                {
                    Input = new StreamReader(name);
                    Przepisz(Input, Wynik);
                    Input.Close();
                }
            }

            Wynik.Close();
            Console.WriteLine("Zmergowane!");
            Console.WriteLine("Wynik w pliku ./Zmergowane/Wynik.csv");
            Console.WriteLine("Naciśnij <Enter>, aby zakończyć");
            Console.ReadLine();
        }

        private static void Przepisz(StreamReader Input, StreamWriter Wynik)
        {
            while (!Input.EndOfStream)
            {
                Wynik.WriteLine(Input.ReadLine());
            }
            Wynik.WriteLine();
        }

        private static bool IsCSV(string name)
        {
            int L = name.Length;
            return String.Compare(".csv", name.Substring(L - 4)) == 0;
        }

    }
}
