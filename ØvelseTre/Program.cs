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
                ThreadPool.QueueUserWorkItem(meth.WritDataWithLowPriority, ThreadPriority.Lowest);
            }
            for (int i = 0; i < 8; i++)
            {
                ThreadPool.QueueUserWorkItem(meth.WriteDataFromThreadPoolWithHigestPriority);
            }
            Thread.Sleep(10000);
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



        }

        public void WritDataWithLowPriority(object obj)
        {
            Thread.Sleep(1000);
            Thread thi = Thread.CurrentThread;
            thi.Priority = (ThreadPriority) obj;

            Console.WriteLine($"Id:{thi.ManagedThreadId} isAlive:{thi.IsAlive} isBackground:{ thi.IsBackground} priority:{thi.Priority}" );


        }
    }

}