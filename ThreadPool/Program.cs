using System;

using System.Threading;

namespace ThreadPooling
{
    class Program
    {
        static void Main(string[] args)
        {

            ThreadPoolDemo tpd = new ThreadPoolDemo();
            for (int i = 0; i < 2; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.Task1));
                ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.Task2));
            }


            Console.WriteLine("Hello Teacher!");
            Console.ReadLine();
        }



        public class ThreadPoolDemo
        {
             public void Task1(object obl)
                    {
                        for (int i = 0; i <= 2; i++)
                        {
                            Console.WriteLine("Task 1 is being executed");
                        }
                    }

                    public void Task2(object obj)
                    {
                        for (int i = 0; i <= 2; i++)
                        {
                            Console.WriteLine("Task 2 is being executed");
                        }
                    }
        }
    }
}