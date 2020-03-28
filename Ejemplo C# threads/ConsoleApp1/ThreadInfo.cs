//*** microsoft example: https://docs.microsoft.com/en-us/dotnet/api/system.threading.thread?view=netframework-4.8
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ConsoleApp1
{
    
public class ThreadInfo
{
    static Object obj = new Object();

    public static void Run()
    {
        ThreadPool.QueueUserWorkItem(ShowThreadInformation);
        var th1 = new Thread(ShowThreadInformation);
            th1.Name = "TH1";
        th1.Start();
        var th2 = new Thread(ShowThreadInformation);
            th2.Name = "TH1";
            th2.IsBackground = true;
        th2.Start();
        Thread.Sleep(500);
        Thread.CurrentThread.Name = "Main";
        ShowThreadInformation(null);
    }

    private static void ShowThreadInformation(Object state)
    {
        lock (obj)
        {
            var th = Thread.CurrentThread;
            Console.WriteLine("Managed thread #{0}: ", th.ManagedThreadId);
            Console.WriteLine("   Name: {0}", th.Name);
            Console.WriteLine("   Background thread: {0}", th.IsBackground);
            Console.WriteLine("   Thread pool thread: {0}", th.IsThreadPoolThread);
            Console.WriteLine("   Priority: {0}", th.Priority);
            Console.WriteLine("   Culture: {0}", th.CurrentCulture.Name);
            Console.WriteLine("   UI culture: {0}", th.CurrentUICulture.Name);
            Console.WriteLine();
        }
    }
}
    // The example displays output like the following:
    //       Managed thread #6:
    //          Background thread: True
    //          Thread pool thread: False
    //          Priority: Normal
    //          Culture: en-US
    //          UI culture: en-US
    //       
    //       Managed thread #3:
    //          Background thread: True
    //          Thread pool thread: True
    //          Priority: Normal
    //          Culture: en-US
    //          UI culture: en-US
    //       
    //       Managed thread #4:
    //          Background thread: False
    //          Thread pool thread: False
    //          Priority: Normal
    //          Culture: en-US
    //          UI culture: en-US
    //       
    //       Managed thread #1:
    //          Background thread: False
    //          Thread pool thread: False
    //          Priority: Normal
    //          Culture: en-US
    //          UI culture: en-US
}