using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ConsoleApp1
{
    class ClassThread
    {
        public class Thread_class
        {

            // Non-static method 
            public void Coidgo_Hilo1()
            {
                for (int z = 0; z < 10; z++)
                {
                    Console.WriteLine("Thread con clases Hilo 1 en progreso:" + z);
                    Thread.Sleep(1000);
                }
                Console.WriteLine("...............Threads con clases: finaliza hilo 1............");
            }
            

        };

        public void run()
        {
            Console.WriteLine("...............Threads con clases: Inicia............");
            var obj = new Thread_class();

            Thread thr1 = new Thread(new ThreadStart(obj.Coidgo_Hilo1));
            thr1.Start();
            Console.WriteLine("...............Threads con clases: finaliza............");

        }
    }
}
