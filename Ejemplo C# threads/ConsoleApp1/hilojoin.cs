using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ConsoleApp1
{
    class hilojoin
    {
        public void runJoin_v1()
        {
            Console.WriteLine("...............Threads con problema de Join v1............");
            ej_Thread obj = new ej_Thread();


            Thread thr1 = new Thread(new ThreadStart(obj.Coidgo_Hilo1));
            Thread thr2 = new Thread(new ThreadStart(obj.Coidgo_Hilo2));
            thr1.Start();
            thr1.Join();
            thr2.Start();
            Console.WriteLine("Finaliza main thread  Threads con problema de Join. v1 ");
        }


        public void runJoin_v2()
        {
            Console.WriteLine("...............Threads con problema de Join v2............");
            ej_Thread obj = new ej_Thread();


            Thread thr1 = new Thread(new ThreadStart(obj.Coidgo_Hilo1));
            Thread thr2 = new Thread(new ThreadStart(obj.Coidgo_Hilo2));
            thr1.Start();
            thr1.Join();
            thr2.Start();
            thr2.Join();
            Console.WriteLine("Finaliza main thread  Threads con problema de Join. v2");
        }


        public void runJoin_v3()
        {
            Console.WriteLine("...............Threads con problema de Join v3............");
            ej_Thread obj = new ej_Thread();


            Thread thr1 = new Thread(new ThreadStart(obj.Coidgo_Hilo1));
            Thread thr2 = new Thread(new ThreadStart(obj.Coidgo_Hilo2));
            thr1.Start();
            thr2.Start();
            thr1.Join();
            thr2.Join();
            Console.WriteLine("Finaliza main thread  Threads con problema de Join. v2");
        }

    }
}
