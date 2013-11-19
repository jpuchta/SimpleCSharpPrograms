using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace AbstractParser
{
    class AnAbstractWriter
    {
        private StreamWriter str;

        private XmlDocument xmlOut = new XmlDocument();

        public AnAbstractWriter(string path)
        {
            str = new StreamWriter(path);
        }
        public AnAbstractWriter()
        {
            str = new StreamWriter(Console.OpenStandardOutput());
        }

        public void WriteAbstract(AnAbstract A)
        {
            str.WriteLine(A.ToString());
        }


        public void Close()
        {
            this.str.Close();
        }
    }
}
