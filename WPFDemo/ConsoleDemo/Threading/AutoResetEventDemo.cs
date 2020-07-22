using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleDemo.Threading
{
    internal class AutoResetEventDemo
    {
        public static void TestEntry()
        {
            Thread t1 = new Thread(new ThreadStart(() =>
            {
                Console.WriteLine(string.Format("thread {0} started to wait autoResetEvent1", Thread.CurrentThread.ManagedThreadId));
                autoResetEvent1.WaitOne();
                Console.WriteLine(string.Format("thread {0} has waited a signal", Thread.CurrentThread.ManagedThreadId));
            }));
            Thread t2 = new Thread(new ThreadStart(() =>
            {
                Console.WriteLine(string.Format("thread {0} started to wait autoResetEvent2", Thread.CurrentThread.ManagedThreadId));
                autoResetEvent2.WaitOne();
                Console.WriteLine(string.Format("thread {0} has waited a signal", Thread.CurrentThread.ManagedThreadId));
                autoResetEvent1.Set();
            }));
            t1.Start();
            t2.Start();
            Thread.Sleep(2000);
            autoResetEvent2.Set();
            Console.Read();
        }


        public static void TestEntry2()
        {
            Thread t1 = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    Console.WriteLine(string.Format("thread {0} started to wait autoResetEvent1", Thread.CurrentThread.ManagedThreadId));
                    autoResetEvent1.WaitOne();
                    Console.WriteLine(string.Format("thread {0} has waited a signal", Thread.CurrentThread.ManagedThreadId));
                }
            }));
            Thread t2 = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    Console.WriteLine(string.Format("thread {0} started to wait autoResetEvent1", Thread.CurrentThread.ManagedThreadId));
                    autoResetEvent1.WaitOne();
                    Console.WriteLine(string.Format("thread {0} has waited a signal", Thread.CurrentThread.ManagedThreadId));
                }
            }));
            t1.Start();
            t2.Start();
            int i = 0;
            while (i++ <= 5) {
                Thread.Sleep(2000);
                autoResetEvent1.Set();
            }            
            Console.Read();
        }

        private static AutoResetEvent autoResetEvent1 = new AutoResetEvent(false);
        private static AutoResetEvent autoResetEvent2 = new AutoResetEvent(false);
    }
}
