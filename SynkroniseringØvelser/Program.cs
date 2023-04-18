using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynkroniseringØvelser
{
    internal class Program
    {
        static int counter = 0;
        static readonly object obj = new object();

        public void CountUp()
        {
            while (true)
            {
                Monitor.Enter(obj);
                try
                {
                    counter += 2;
                }
                finally
                {
                    Monitor.Exit(obj);
                }
                Console.WriteLine(counter);
                Thread.Sleep(1000);
            }
        }
        public void CountDown() 
        {
            while(true) 
            {
                Monitor.Enter(obj);
                try
                {
                    counter--;
                }
                finally 
                {
                    Monitor.Exit(obj);
                }
                Console.WriteLine(counter);
                Thread.Sleep(1000);
            }
        }
        
        static void Main(string[] args)
        {
            Program pg = new Program(); 
            Thread t1 = new Thread(pg.CountUp);
            Thread t2 = new Thread(pg.CountDown);
            t1.Start();
            t2.Start();
            Console.Read();
        }
    }
}
