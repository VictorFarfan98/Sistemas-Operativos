using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ConsoleApp1
{
    class elements
    {
        public elements(string vt)
        {
            text = vt;
        }
        public string text;
    }
    public class Pool
    {
        public static void Run()
        {
            
            ThreadPool.QueueUserWorkItem(ThreadProc);
            Console.WriteLine("Main thread does some work, then sleeps.");
            Thread.Sleep(1000);

            Console.WriteLine("Main thread exits.");
        }
        public static void RunContext()
        {

            ThreadPool.QueueUserWorkItem(ThreadProcContext, new elements("mi contenido 1"));
            ThreadPool.QueueUserWorkItem(ThreadProcContext, new elements("mi contenido 2"));
            ThreadPool.QueueUserWorkItem(ThreadProcContext, new elements("mi contenido 3"));
            Console.WriteLine("Main thread does some work, then sleeps.");
            Thread.Sleep(1000);

            Console.WriteLine("Main thread exits.");
        }



        static void ThreadProc(Object stateInfo)
        {
            
            Console.WriteLine("thread pool.");
        }


        static void ThreadProcContext(Object stateInfo)
        {
            var ele = (elements)stateInfo;

            Console.WriteLine("thread pool."+ele.text);
        }



        
    }
    
}



