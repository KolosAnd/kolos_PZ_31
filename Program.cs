using System;
using System.Text;

namespace Lab07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            //Console.WriteLine("------- Лаба 7 ----------\n");
            //var lab7 = new Romanovskyy();
            //lab7.FindAverage();
            //lab7.FindK();
            //lab7.FindS();
            //lab7.FindR();
            //Console.WriteLine("-------------------------\n");

            //Console.WriteLine("------- Лаба 8 ----------\n");
            //var lab8 = new Fisher();
            //lab8.FindAverage();
            //lab8.FindK();
            //lab8.FindS();
            //lab8.FindR();

            //lab8.FishFunc();

            //Console.WriteLine($"\nЯкщо рівень значущості a = 0.05, то:");
            //lab8.IntervalEstimation(lab8.t1);
            //Console.WriteLine($"Якщо рівень значущості a = 0.01, то:");
            //lab8.IntervalEstimation(lab8.t2);
            //Console.WriteLine("-------------------------\n");

            var lab9 = new Lab9();
            lab9.printData();

            var lab10 = new Lab10();
            lab10.printData();
            
        }
    }
}
