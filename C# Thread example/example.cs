using System;
using System.Threading;

public class Worker(){
    public void DoWork(){
        while (!it_shouldStop){
            Console.WriteLine("Worker thread working ");
        }
        Console.WriteLine("worker thread terminating gracefully");
    }

    public void RequestStop(){
        it_shouldStop = true;
    }

    private volatile bool it_shouldStop;


    static void Main(){
        //Create a thread object. This does not start the thread
        Worker workerObject = new Worker()
        Thread workerThread = new Thread(workerObject.DoWork);

        //Start the worker thread
        workerThread.Start();
        Console.WriteLine("main thread. Starting worker thread...");

        //Loop until worker thread activates
        while(workerThread.isAlive);

        //Put the main thread to sleep for 1ms to allow the worker thread to do some work
        Thread.Sleep(1);

        //Request that the worker thread stop itself
        workerObject.RequestStop();


        //Use the Join method to block the current thread until the object's thread terminates
        workerThread.Join();
        Console.WriteLine("main thread. Worker thread has terminated....")
    }
}