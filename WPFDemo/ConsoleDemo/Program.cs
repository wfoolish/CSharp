using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ExpressionDemo.ResolveLamda(x => x.Age > 5);

            string result = new TextLinq().Search(x => x.Key .Equals( "1001"));
            Console.WriteLine(result);

            Linq2Xml.M1();
            Console.Read();
        }
    }
}
