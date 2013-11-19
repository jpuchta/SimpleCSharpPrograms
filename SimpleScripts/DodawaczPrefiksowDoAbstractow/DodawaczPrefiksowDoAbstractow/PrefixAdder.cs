using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DodawaczPrefiksowDoAbstractow
{
    class PrefixAdder
    {
        private string prefix;
        private string nameIn;
        private string nameOut;

        private StreamReader input;
        private StreamWriter output;

        public PrefixAdder(string prefix, string nameIn, string nameOut)
        {
            this.prefix = prefix;
            this.nameIn = nameIn;
            this.input = new StreamReader(nameIn);
            this.nameOut = nameOut;
            this.output = new StreamWriter(nameOut);
        }


        public PrefixAdder(string prefix, string nameIn)
        {
            this.prefix = prefix;
            this.nameIn = nameIn;
            this.input = new StreamReader(nameIn);
            this.nameOut = "stdout";
            this.output = new StreamWriter(Console.OpenStandardOutput());
        }

        public PrefixAdder(string prefix)
        {
            // TODO: Complete member initialization
            this.prefix = prefix;
            this.nameIn = "stdin";
            this.input = new StreamReader(Console.OpenStandardInput());
            this.nameOut = "stdout";
            this.output = new StreamWriter(Console.OpenStandardOutput());
        }

        
        public void Run()
        {
            string line;
            while (FileHasentEnded())
            {
                line = input.ReadLine();
                output.WriteLine(prefix + line);
            }
        }

        public void Close()
        {
            input.Close();
            output.Close();
        }

        private bool FileHasentEnded()
        {
            return !(input.EndOfStream);
        }
    }
}
