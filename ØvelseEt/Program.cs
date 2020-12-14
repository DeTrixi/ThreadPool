using System;
using System.Diagnostics;
using System.Threading;

namespace ØvelseEt
{
    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch mywatch = new Stopwatch(); Console.WriteLine("Thread Pool Execution");
            mywatch.Start();
            ProcessWithThreadPoolMethod();

            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + mywatch.ElapsedTicks);
            mywatch.Reset();
            Console.WriteLine("Thread Execution");
            mywatch.Start();
            ProcessWithThreadMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + mywatch.ElapsedTicks);


            //ThreadPool.QueueUserWorkItem(Process);
            Console.WriteLine("Hello Teacher!");
        }

        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Process);
            }
        }
        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }
        static void Process(object callback) {
            for (int i = 0; i < 100000; i++)
            {
                // for (int j = 0; j < 100000; j++)
                // {
                // }
            }
        }
    }
}