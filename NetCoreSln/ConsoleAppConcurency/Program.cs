using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppConcurency
{
    class Program
    {
        static void Main(string[] args)
        {
            RunThreadPool();

        }

        async Task DoSthAsync()
        {
            int val = 13;
            await Task.Delay(TimeSpan.FromSeconds(2));
            Console.WriteLine(val.ToString());
        }

        async Task DoSthAsync2()
        {
            int val = 13;
            await Task.Delay(TimeSpan.FromSeconds(2)).ConfigureAwait(false);
            Console.WriteLine(val.ToString());
        }

        #region Parallel

        void RotateMatrices(IEnumerable<Matrix> matrices, float degrees)
        {
            Parallel.ForEach(matrices, matrix => matrix.Rotate(degrees));
        }

        private class Matrix
        {
            internal void Rotate(float degrees)
            {
                throw new NotImplementedException();
            }
        }


        IEnumerable<bool> PrimalityTest(IEnumerable<int> values)
        {
            return values.AsParallel().Select(val => IsPrime(val));
        }

        private bool IsPrime(int val)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Reactive Extensions(RX)
        interface IObserver<in T>
        {
            void OnNext(T item);
            void OnCompleted();
            void OnError(Exception error);
        }

        interface IObservable<out T>
        {
            IDisposable Subscribe(IObserver<T> observer);
        }

        //Observable.Interval(TimeSpan.FromSeconds(1))
        //.Timestamp()
        //.Where(x => x.Value % 2 == 0)
        //.Select(x => x.Timestamp)
        //.Subscribe(x => Trace.WriteLine(x));

        //        IObservable<DateTimeOffset> timestamps =
        //Observable.Interval(TimeSpan.FromSeconds(1))
        //.Timestamp()
        //.Where(x => x.Value % 2 == 0)
        //.Select(x => x.Timestamp);
        //        timestamps.Subscribe(x => Trace.WriteLine(x));
        #endregion

        #region Thread
        public static void RunThread()
        {
            for (int i = 0; i < 30; i++)
            {
                Thread t = new Thread(new ThreadStart(ThreadProc));
                t.Name = "Overred_" + i;
                t.Start();
            }
            Console.Read();
        }

        private static void ThreadProc()
        {
            try

            {

                for (int i = 0; i < 10; i++)

                {

                    Console.WriteLine("{0}  Value:{1}", Thread.CurrentThread.Name, i);

                }



            }

            catch (Exception ex)

            {

                Console.WriteLine(ex.Message);

            }
        }
        #endregion

        #region ThreadPool
        public static void RunThreadPool()
        {
            for (int i = 0; i < 30; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProcPool));
                //这个问题就是ThreadPool有个GetMaxThreads，可以通过GetMaxThreads(out int workerThreads, out int completionPortThreads);
                //方法获取到，如果线程池满拉，则会死锁更严重！  另：ThreadPool都为后台线程 
                //Thread t = new Thread(new ThreadStart(ThreadProc));
                //t.Name = "Overred_" + i;
                //t.Start();
            }
            Console.Read();
        }

        private static void ThreadProcPool(object state)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(" Value:{0}", i);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Task
        //1: ThreadPool不支持线程的取消、完成、失败通知等交互性操作
        //2: ThreadPool不支持线程执行的先后次序
        #endregion

        //http://www.cnblogs.com/luminji/archive/2011/05/13/2044801.html
        //ThreadPool是一个公共的线程池，如果你想要实现自己的线程池的话，需要自行实现
        //.NET Framework里面大多数异步的东西（如Timer）都是用的ThreadPool
        //threadPool 本身正是为了减少线程使用数量，避免过多上下文切换才设计出来的。内存占用肯定会比新建大幅数量的线程少的多
        //.NET Framework 提供的线程池效率中庸的一大原因就是提供第三方保障，如内存和线程安全
        //其实.NET自带的线程池效率很高，经过很大调整和优化的，一般实现都比不过它 
        //如果不是有绝对的“违背”，只要封装一下ThreadPool就可以了，比如负载均衡，任务取消都可以实现，MSDN Magazine中有一个系列谈了很多这方面的问题，可以一看。
        //net的线程池的优点很多，就是没有任务管理的方法
        //大家应该知道每个进程只会有一个threadpool,也就是说如果你再用threadpool，那么别人写的代码也可能在用threadpool，
        //因为一个进程的代码可能包括多个模块，
        //而这些模块可能由不同的人开发的，而线程池事实上是用一个队列来隔离请求与处理的，那么大家就都往这个队列里压入workcallback，
        //好了，队列就变得越来越庞大，后面进来的workcallback就在那里等着吧。这还好，最要命的就是v.net本身很多多线程处理的任务也是用的threadpool，
        //比如wcf，那么这个时候就完了，外面的请求就开始变的慢，甚至开始超时。。。
    }
}
