using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestThread();
            //TestMutex();
            //SingleInstance();
            //DeadLock();
            //TestSemaphore();
            //TestSemaphoreProcess();
            //TestManualResetEvent();
            //TestAutoResetEvent();
            TestMannulEvent();
        }

        private static void TestThread()
        {
            Console.Title = "Thread Locking Demo";
            TestThreadSafe testThreadSafe = new TestThreadSafe();
            Thread t1 = new Thread(testThreadSafe.DoDivide);
            Thread t2 = new Thread(testThreadSafe.DoDivide);
            t1.Start();
            t2.Start();

        }

        #region Mutex  
        //Mutex is used to prevent the execution of a shared resource by multiple threads.
        //当声明Mutex时必须指定名称，否则只能进行进程内的线程同步。
        public static void TestMutex()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(new ThreadStart(Go));
                thread.Name = String.Concat("Thread ", i);
                thread.Start();
            }
            Console.ReadLine();

        }

        static void Go()
        {
            Thread.Sleep(500);
            WriteFile();
        }

        static Mutex mutex = new Mutex();
        static void WriteFile()
        {
            mutex.WaitOne();

            String ThreadName = Thread.CurrentThread.Name;
            Console.WriteLine("{0} using resource", ThreadName);

            try
            {
                using (StreamWriter sw = new StreamWriter("D:\\abc.txt", true))
                {
                    sw.WriteLine(ThreadName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("{0} releasing resource", ThreadName);

            mutex.ReleaseMutex();
        }

        //1.The name of the mutex should be a unique identifier of assembly or GUID.
        //2.Mutex hits performance, so it should be used when synchronization across process boundaries is required.

        static void SingleInstance()
        {
            String appGUID = "5a913d2e-1d4b-492c-a408-df315ca3de93";
            bool ok;
            Mutex mutex = new Mutex(true, appGUID, out ok);

            if (!ok)
            {
                Console.WriteLine("Another instance is already running.");
            }
            else
            {
                Console.WriteLine("Single instance is running.");
            }
            Console.ReadLine();
        }
        #endregion

        #region DeadLock
        static object lockObj1 = new object();
        static object lockObj2 = new object();
        static Thread t1 = new Thread(DoWork1);
        static Thread t2 = new Thread(DoWork2);

        static void DeadLock()
        {
            Console.Title = "Thread Deadlock Demo";
            t1.Start();
            t2.Start();

        }
        static void DoWork1()
        {
            lock (lockObj1)
            {
                Console.WriteLine("Inside DoWork1: lockObj1 grabbed");
                Thread.Sleep(1000);
                Console.WriteLine("Inside DoWork1, t1 thread state: {0}", t1.ThreadState);
                Console.WriteLine("Inside DoWork1, t2 thread state: {0}", t2.ThreadState);
                lock (lockObj2) //Deadlock, below code is not executed  
                {
                    Console.WriteLine("Inside DoWork1: lockObj2 grabbed");
                }
            }
        }

        static void DoWork2()
        {
            lock (lockObj2)
            {
                Console.WriteLine("Inside DoWork2: lockObj2 grabbed");
                Thread.Sleep(500);
                Console.WriteLine("Inside DoWork2, t1 thread state: {0}", t1.ThreadState);
                Console.WriteLine("Inside DoWork2, t2 thread state: {0}", t2.ThreadState);
                lock (lockObj1) ////Deadlock, below code is not executed  
                {
                    Console.WriteLine("Inside DoWork2: lockObj1 grabbed");
                }
            }
        }

        #endregion

        #region 信号量 Semaphore 
        //信号量说简单点就是为了线程同步，或者说是为了限制线程能运行的数量。
        //那它又是怎么限制线程的数量的哩？是因为它内部有个计数器，比如你想限制最多5个线程运行，那么这个计数器的值就会被设置成5，如果一个线程调用了这个Semaphore，那么它的计数器就会相应的减1，直到这个计数器变为0。这时，如果有另一个线程继续调用这个Semaphore，那么这个线程就会被阻塞。
        //获得Semaphore的线程处理完它的逻辑之后，你就可以调用它的Release()函数将它的计数器重新加1，这样其它被阻塞的线程就可以得到调用了。

        //我设置一个最大允许5个线程允许的信号量
        //并将它的计数器的初始值设为0
        //这就是说除了调用该信号量的线程都将被阻塞
        static Semaphore semaphore = new Semaphore(0, 5);

        static void TestSemaphore()
        {
            for (int i = 1; i <= 5; i++)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(work));

                thread.Start(i);
            }

            Thread.Sleep(1000);
            Console.WriteLine("Main thread over!");

            //释放信号量，将初始值设回5，你可以将
            //将这个函数看成你给它传的是多少值，计数器
            //就会加多少回去，Release()相当于是Release(1)
            semaphore.Release(5);
        }

        static void work(object obj)
        {
            semaphore.WaitOne();

            Console.WriteLine("Thread {0} start!", obj);

            semaphore.Release();
        }

        static void TestSemaphoreProcess()
        {
            Semaphore seamphore = new Semaphore(5, 5, "SemaphoreExample");

            seamphore.WaitOne();
            Console.WriteLine("Seamphore 1");
            seamphore.WaitOne();
            Console.WriteLine("Seamphore 2");
            seamphore.WaitOne();
            Console.WriteLine("Seamphore 3");

            Console.ReadLine();
            seamphore.Release(3);
        }

        //可以给信号量设置一个名称，这个名称是操作系统可见的，因此，可以使用这些信号量来协调跨进程边界的资源使用
        #endregion

        #region Event
        //http://www.cnblogs.com/qingyun163/archive/2013/01/05/2846633.html
        //http://www.codeguru.com/csharp/.net/net_framework/thread-synchronization-using-reset-events-in-.net-framework.htm
        public class EventWaitTest
        {
            private string name; //顾客姓名 
            // private static AutoResetEvent eventWait = new AutoResetEvent(false);
            private static ManualResetEvent eventWait = new ManualResetEvent(false);
            private static ManualResetEvent eventOver = new ManualResetEvent(false);

            public EventWaitTest(string name)
            {
                this.name = name;
            }

            public static void Product()
            {
                Console.WriteLine("服务员：厨师在做菜呢，两位稍等");
                Thread.Sleep(2000);
                Console.WriteLine("服务员：宫爆鸡丁好了");
                eventWait.Set();
                while (true)
                {
                    if (eventOver.WaitOne(1000, false))
                    {
                        Console.WriteLine("服务员：两位请买单");
                        eventOver.Reset();
                    }
                }
            }

            public void Consume()
            {
                while (true)
                {
                    if (eventWait.WaitOne(1000, false))
                    {
                        Console.WriteLine(this.name + "：开始吃宫爆鸡丁");
                        Thread.Sleep(2000);
                        Console.WriteLine(this.name + "：宫爆鸡丁吃光了");
                        eventWait.Reset();
                        eventOver.Set();
                        break;
                    }
                    else
                    {
                        Console.WriteLine(this.name + "：等着上菜无聊先玩会手机游戏");
                    }
                }
            }
        }

        static void TestManualResetEvent()
        {
            EventWaitTest zhangsan = new EventWaitTest("张三");
            EventWaitTest lisi = new EventWaitTest("李四");
            Thread t1 = new Thread(new ThreadStart(zhangsan.Consume));
            Thread t2 = new Thread(new ThreadStart(lisi.Consume));
            Thread t3 = new Thread(new ThreadStart(EventWaitTest.Product));
            t1.Start();
            t2.Start();
            t3.Start();
            Console.Read();
        }
        #endregion

        #region AutoResetEvent
        static AutoResetEvent _autoResetEvent = new AutoResetEvent(false);
        static void TestAutoResetEvent()
        {
            Thread thread1 = new Thread(new ParameterizedThreadStart(PrintNames));
            thread1.Name = "Thread1";
            thread1.Start("Simon");
            Console.WriteLine("Thread1 invoked");
            Thread thread2 = new Thread(new ParameterizedThreadStart(PrintNames));
            thread2.Name = "Thread2";
            thread2.Start("Bear Grylls");
            Console.WriteLine("Thread2 invoked");
            Thread thread3 = new Thread(new ParameterizedThreadStart(PrintNames));
            thread3.Name = "Thread3";
            thread3.Start("Les Stroud");
            Console.WriteLine("Thread3 invoked");
            Console.WriteLine("All the three threads are waiting in AddNames function!");
            //Release the first thread and let it take care of releasing the rest
            _autoResetEvent.Set();
            Console.ReadLine();
        }

        static void PrintNames(object name)
        {
            //Do some processing
            //Make all the incoming threads wait until it is signaled.
            _autoResetEvent.WaitOne();
            Console.WriteLine("{0} released!", Thread.CurrentThread.Name);
            Console.WriteLine("Name given: {0}", name);
            //Release the next thread
            _autoResetEvent.Set();
        }
        #endregion

        #region ManualResetEvent
        static ManualResetEvent _manualResetEvent = new ManualResetEvent(false);

        static void TestMannulEvent()
        {
            Thread thread1 = new Thread(new ParameterizedThreadStart(PrintNames2));
            thread1.Name = "Thread1";
            thread1.Start("Simon");
            Console.WriteLine("Thread1 invoked");
            Thread thread2 = new Thread(new ParameterizedThreadStart(PrintNames2));
            thread2.Name = "Thread2";
            thread2.Start("Bear Grylls");
            Console.WriteLine("Thread2 invoked");
            Thread thread3 = new Thread(new ParameterizedThreadStart(PrintNames2));
            thread3.Name = "Thread3";
            thread3.Start("Les Stroud");
            Console.WriteLine("Thread3 invoked");
            Console.WriteLine("All the three threads are waiting in AddNames function!");

            //Release the first thread and let it take care of releasing the rest
            _manualResetEvent.Set();

            Console.ReadLine();
        }

        static void PrintNames2(object name)
        {
            //Do some processing
            //Make all the incoming threads wait until it is signaled.
            _manualResetEvent.WaitOne();
            Console.WriteLine("{0} released!", Thread.CurrentThread.Name);
            //Try making the threads wait again. This will not succeed as an explicit reset is required for ManualResetEvent
            _manualResetEvent.WaitOne();
            Console.WriteLine("Name given: {0}", name);
        }
        #endregion

        //AutoResetEvent:
        //1. Once signaled only one thread is released.
        //2. Reset happens automatically after the thread is released.

        //ManualResetEvent:
        //1. Once signaled all the threads are released.
        //2. Reset should be manually done using the Reset method of the wait handle.Until the threads are explicitly un-signaled they will not wait on the Wait methods.
        
        //If the threads executing a particular method should be synchronized so that the method resource is accessed by one thread at a time, then use AutoResetEvent.
        //If all the threads should wait for an event to be completed by another thread and can start processing simultaneously after the event is occurred, then go for ManualResetEvent.
    }

    #region    Thread locking   

    /// <summary>
    /// thread1 (or t1) may be at LN3 and thread2 (or t2) may be executing LN5. In that case compiler may throw DivideByZeroException.
    /// num1 = rnd.Next(1, 5); //LN1  
    /// num2 = rnd.Next(1, 5); //LN2  
    /// Console.WriteLine(num1 / num2); //LN3 thread1  
    /// num1 = 0; //LN4  
    /// num2 = 0;//thread2 //LN5 thread5  
    /// </summary>
    //class TestThreadSafe
    //{
    //    int num1 = 0;
    //    int num2 = 0;
    //    Random rnd = new Random();
    //    public void DoDivide()
    //    {
    //        for (int i = 0; i < 5; i++)
    //        {
    //            num1 = rnd.Next(1, 5);
    //            num2 = rnd.Next(1, 5);
    //            Console.WriteLine(num1 / num2);
    //            num1 = 0;
    //            num2 = 0;
    //        }
    //    }
    //}



    class TestThreadSafe
    {
        // I have seen some people use as lock(this) that locks the complete class instance which at times may lead to a deadlock situation.
        // So the recommended practice is to have a private static variable created in a class and lock that variable only.

        private static object myLock = new object();
        public void DoDivide()
        {
            int num1 = 0;
            int num2 = 0;
            Random rnd = new Random();
            lock (myLock) //This will ensure that only one thread can enter into code.  
            {
                for (int i = 0; i < 10; i++)
                {
                    num1 = rnd.Next(1, 5);
                    num2 = rnd.Next(1, 5);
                    Console.WriteLine(num1 / num2);
                    num1 = 0;
                    num2 = 0;
                }
            }
        }
    }
    #endregion


}
