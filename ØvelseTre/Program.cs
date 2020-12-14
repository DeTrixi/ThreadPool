using System;
using System.Threading;

namespace ØvelseTre
{
    class Program
    {
        static void Main(string[] args)
        {
            Methods meth = new Methods();
            for (int i = 0; i < 8; i++)
            {
                ThreadPool.QueueUserWorkItem(meth.WritDataWithLowPriority);
            }
            for (int i = 0; i < 8; i++)
            {
                ThreadPool.QueueUserWorkItem(meth.WriteDataFromThreadPoolWithHigestPriority);
            }

            Console.WriteLine(ThreadPool.ThreadCount);


            Console.WriteLine("Hello Teacher!");
            Console.ReadLine();
        }

    }

    public class Methods
    {
        public void WriteDataFromThreadPoolWithHigestPriority(object obj)
        {
            Thread.Sleep(1000);
            Thread thi = Thread.CurrentThread;

            thi.Priority = ThreadPriority.Highest;
            Console.WriteLine($"Id:{thi.ManagedThreadId} isAlive:{thi.IsAlive} isBackground:{ thi.IsBackground} priority:{thi.Priority}" );

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Id:{thi.ManagedThreadId} isAlive:{thi.IsAlive} isBackground:{ thi.IsBackground} priority:{thi.Priority}" );
            }

        }

        public void WritDataWithLowPriority(object obj)
        {
            Thread.Sleep(1000);
            Thread thi = Thread.CurrentThread;

            thi.Priority = ThreadPriority.Lowest;
            Console.WriteLine($"Id:{thi.ManagedThreadId} isAlive:{thi.IsAlive} isBackground:{ thi.IsBackground} priority:{thi.Priority}" );


        }
    }

}