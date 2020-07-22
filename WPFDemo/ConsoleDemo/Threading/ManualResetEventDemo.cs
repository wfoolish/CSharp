using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleDemo.Threading
{
    /// <summary>
    /// ManualResetEvent每次接受信号后需手动重置（调用Reset方法）
    /// </summary>
    internal class ManualResetEventDemo
    {
        private static ManualResetEvent manualResetEvent = new ManualResetEvent(false);
        public static void TestEntry()
        {
            Thread t1 = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    Console.WriteLine(string.Format("thread {0} started to wait autoResetEvent1", Thread.CurrentThread.ManagedThreadId));
                    manualResetEvent.WaitOne();
                    Console.WriteLine(string.Format("thread {0} has waited a signal", Thread.CurrentThread.ManagedThreadId));
                    manualResetEvent.Reset();
                }
            }));
            Thread t2 = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    Console.WriteLine(string.Format("thread {0} started to wait autoResetEvent1", Thread.CurrentThread.ManagedThreadId));
                    manualResetEvent.WaitOne();
                    Console.WriteLine(string.Format("thread {0} has waited a signal", Thread.CurrentThread.ManagedThreadId));
                }
            }));
            t1.Start();
            t2.Start();
            int i = 0;
            while (i++ <= 5)
            {
                Thread.Sleep(2000);
                manualResetEvent.Set();
            }
            Console.ReadLine();
        }
    }
}
