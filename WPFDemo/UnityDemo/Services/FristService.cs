using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityDemo.Interfaces;

namespace UnityDemo.Services
{
    public class FristService : IFirstService
    {
        public void Method1()
        {
            Console.WriteLine("method1");
        }

        public void Method2()
        {
            Console.WriteLine("method2");
        }

        public string Property1 { get; set; }
    }
}
