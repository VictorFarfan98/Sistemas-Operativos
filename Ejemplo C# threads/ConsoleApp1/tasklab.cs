using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace ConsoleApp1
{
    class tasklab
    {

        

        public static void RunTaskWait()
        {
            // Wait on a single task with a timeout specified.
            Task taskA = Task.Run(() => Thread.Sleep(2000));
            try
            {
                taskA.Wait(1000);       // Wait for 1 second.
                bool completed = taskA.IsCompleted;
                Console.WriteLine("Task A completed: {0}, Status: {1}",
                                 completed, taskA.Status);
                if (!completed)
                    Console.WriteLine("Timed out before task A completed.");
            }
            catch (AggregateException)
            {
                Console.WriteLine("Exception in taskA.");
            }
        }


        public static void RunTaskAny()
        {
            var tasks = new Task[3];
            var rnd = new Random();
            for (int ctr = 0; ctr <= 2; ctr++)
                tasks[ctr] = Task.Run(() => Thread.Sleep(rnd.Next(500, 3000)));

            try
            {
                int index = Task.WaitAny(tasks);
                Console.WriteLine("Task #{0} completed first.\n", tasks[index].Id);
                Console.WriteLine("Status of all tasks:");
                foreach (var t in tasks)
                    Console.WriteLine("   Task #{0}: {1}", t.Id, t.Status);
            }
            catch (AggregateException)
            {
                Console.WriteLine("An exception occurred.");
            }
        }

        public static void RunTaskWaitAll()
        {
            // Wait for all tasks to complete.
            Task[] tasks = new Task[10];
            for (int i = 0; i < 10; i++)
            {
                tasks[i] = Task.Run(() => Thread.Sleep(2000));
            }
            try
            {
                Task.WaitAll(tasks);
            }
            catch (AggregateException ae)
            {
                Console.WriteLine("One or more exceptions occurred: ");
                foreach (var ex in ae.Flatten().InnerExceptions)
                    Console.WriteLine("   {0}", ex.Message);
            }

            Console.WriteLine("Status of completed tasks:");
            foreach (var t in tasks)
                Console.WriteLine("   Task #{0}: {1}", t.Id, t.Status);
        }




        static public void Run()
        {
            Action<object> action = (object obj) =>
            {
                Console.WriteLine("Task={0}, obj={1}, Thread={2}",
                Task.CurrentId, obj,
                Thread.CurrentThread.ManagedThreadId);
            };

            // Create a task but do not start it.
            Task t1 = new Task(action, "alpha");

            // Construct a started task
            Task t2 = Task.Factory.StartNew(action, "beta");
            // Block the main thread to demonstrate that t2 is executing
            t2.Wait();

            // Launch t1 
            t1.Start();
            Console.WriteLine("t1 has been launched. (Main Thread={0})",
                              Thread.CurrentThread.ManagedThreadId);
            // Wait for the task to finish.
            t1.Wait();

            // Construct a started task using Task.Run.
            String taskData = "delta";
            Task t3 = Task.Run(() => {
                Console.WriteLine("Task={0}, obj={1}, Thread={2}",
                                  Task.CurrentId, taskData,
                                   Thread.CurrentThread.ManagedThreadId);
            });
            // Wait for the task to finish.
            t3.Wait();

            // Construct an unstarted task
            Task t4 = new Task(action, "gamma");
            // Run it synchronously
            t4.RunSynchronously();
            // Although the task was run synchronously, it is a good practice
            // to wait for it in the event exceptions were thrown by the task.
            t4.Wait();
        }


    }
}

