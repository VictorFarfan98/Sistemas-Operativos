using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    public class ej_Thread
    {

        // Non-static method 
        public void Coidgo_Hilo1()
        {
            for (int z = 0; z < 10; z++)
            {
                Console.WriteLine("Thread2:" + z);
                Thread.Sleep(1000);
            }
            Console.WriteLine("Finaliza hilo 1 problema sync....");
        }

        public void Coidgo_Hilo2()
        {
            for (int z = 0; z < 10; z++)
            {
                Console.WriteLine("Thread1:" + z);
                Thread.Sleep(600);
            }
            Console.WriteLine("Finaliza  hilo 2 problema sync ....");
        }
    };

    class BasicThread
    {



        public void run()
        {
            Console.WriteLine("...............Threads con problema de syncronización............");
            ej_Thread obj = new ej_Thread();


            Thread thr1 = new Thread(new ThreadStart(obj.Coidgo_Hilo1));
            Thread thr2 = new Thread(new ThreadStart(obj.Coidgo_Hilo2));
            thr1.Start();
            thr2.Start();
            Console.WriteLine("Finaliza main thread ....");

        }

        
    }
}
