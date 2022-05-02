using System;
using System.Threading;

namespace Synkronisering_øvelse
{
    class Program
    {

        static object countLock = new object();

        static int count;

        static void Main(string[] args)
        {
            var t1 = new Thread(IncrementCount);
            var t2 = new Thread(IncrementCount);

            t1.Name = "Thread1";
            t2.Name = "Thread2";

            t1.Start();
            Thread.Sleep(10);
            t2.Start();

        }

        static void IncrementCount()
        {
            while (true)
            {
                lock (countLock)
                {
                    if (Thread.CurrentThread.Name == "Thread1")
                    {
                        count += 2;
                        Console.WriteLine("{0} Count is currently at " + count, Thread.CurrentThread.Name);
                    }
                    if (Thread.CurrentThread.Name == "Thread2")
                    {
                        count--;
                        Console.WriteLine("{0} Count is currently at " + count, Thread.CurrentThread.Name);
                    }
                }

                if (Thread.CurrentThread.Name == "Thread1")
                {
                    Thread.Sleep(1000);
                }

                if (Thread.CurrentThread.Name == "Thread2")
                {
                    Thread.Sleep(2000);
                }
            }
        }

    }
}
