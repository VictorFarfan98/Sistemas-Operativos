using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace ConsoleApp1
{


    class Program
    {
        static void Main(string[] args)
        {

            
            var ptypes = new threadtypes();
            ptypes.run_foreground();
            Console.ReadKey();
            ptypes.run_background();
            Console.ReadKey();
            var pclass = new ClassThread();
            pclass.run();
            Console.ReadKey();
            var p = new BasicThread();
            p.run();


            var pj = new hilojoin();
            pj.runJoin_v1();
            pj.runJoin_v2();
            pj.runJoin_v3();



            var pmanagment = new managment();
            pmanagment.runManagment();

            StaticClassThread.Run();



            Pool.Run();
            Pool.RunContext();



            ThreadInfo.Run();


            tasklab.Run();
            tasklab.RunTaskWait();
            tasklab.RunTaskAny();
            tasklab.RunTaskWaitAll();
            
            Console.ReadKey();

            Console.WriteLine("***** He salido del main thread *********");
        }
        
    }
}




  
