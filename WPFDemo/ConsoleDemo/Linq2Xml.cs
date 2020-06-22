using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleDemo
{
    public class Linq2Xml
    {
        public static void M1()
        {
            XDocument xDocument = XDocument.Load("../../files/Persons.xml");
            IEnumerable<XElement> persons = xDocument.Descendants("Person");
            XElement p = persons.Where(x => x.Attribute("Age").Value.Equals("24")).FirstOrDefault();
            Console.WriteLine(string.Format("{0}-{1}", p.Attribute("Name").Value, p.Attribute("Age").Value));
        }
    }
}
