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
        //2: ThreadPool不支持线程执行的先后次序；
        #endregion

        //http://www.cnblogs.com/luminji/archive/2011/05/13/2044801.html
    }
}
