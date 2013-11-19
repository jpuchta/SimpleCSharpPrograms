using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractParser
{
    class AnAbstractTranslator
    {
        private AnAbstractReader Reader;
        private AnAbstractWriter Writer;
        private string name;

        public AnAbstractTranslator(string name)
        {
            this.name = name;
            Reader = new AnAbstractReader(name + ".html");
            Writer = new AnAbstractWriter(name + ".csv");
        }

        public void TranslateAll()
        {
            int i = 0;
            while (Reader.CzyNieKoniecPliku())
            {
                try
                {
                    Writer.WriteAbstract(new AnAbstract(Reader.ReadAbstract()));

                    Console.Write(Message(++i));
                }
                catch (System.IO.EndOfStreamException e)
                {
                    break;
                }
            }
            Console.WriteLine(MessageOver());
//            Console.ReadLine();
        }

        private string MessageOver()
        {
            return name + ".html\t[Done]";
        }

        private string Message(int i)
        {
            return name+".html:\t "+i.ToString()+" Abstraktów.\r";
        }

        public void Close()
        {
            Writer.Close();
            Reader.Close();
        }
    }
}
