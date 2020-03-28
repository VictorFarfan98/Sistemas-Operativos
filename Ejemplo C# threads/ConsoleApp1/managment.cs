using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace ConsoleApp1
{
    

    class managment
    {

        public static void HiloHijo()
        {
            try
            {
                Console.WriteLine("Iniciando managment de hilo");


                for (int counter = 0; counter <= 10; counter++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine(counter);
                }

                Console.WriteLine("Finaliza el hilo de managment");
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine("Notificación de abort" + e.ToString());
            }
            finally
            {
                Console.WriteLine("Que ocurre.....:");
            }
        }


        public void runManagment()
        {

            Console.WriteLine("Iniciando el proceso de managment");

            ThreadStart childref = new ThreadStart(HiloHijo);
            Thread childThread = new Thread(childref);
            childThread.Start();

            //stop the main thread for some time
            Thread.Sleep(2000);
            //now abort the child
            Console.WriteLine("Main thread ejecutando el abort");
            childThread.Abort();

            
        }


    }
}
