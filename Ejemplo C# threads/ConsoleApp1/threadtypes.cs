using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ConsoleApp1
{
    class threadtypes
    {
        public void run_foreground()
        {
            Console.WriteLine("...............Tipos de threads:Foreground ............");
            Thread thr = new Thread(mythreadfunc);
            thr.Start();
            Console.WriteLine("Main finaliza.............");
            Console.WriteLine("Tipos de threads:foreground Main finaliza.............");

        }

        public void run_background()
        {
            Console.WriteLine("...............Tipos de threads:background............");
            Thread thr = new Thread(mythreadfunc);
            thr.Start();
            thr.IsBackground = true;
            Console.WriteLine("Tipos de threads:backround Main finaliza.............");

        }

        // Static method 
        static void mythreadfunc()
        {
            for (int c = 0; c <= 3; c++)
            {

                Console.WriteLine("Tipos de threads: Hilo en progreso");
                Thread.Sleep(1000);
            }
            Console.WriteLine("finaliza thread!!");
        }
    }
}
