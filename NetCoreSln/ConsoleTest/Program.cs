using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new A();
            a.Id = 2;

            var b = new B();
            b.Id = 3;
            Console.WriteLine(a.Id);

            Console.WriteLine(b.Id);

            WeakReference c = new WeakReference(b);

            Console.WriteLine(GC.GetGeneration(a));

            GC.Collect();

            Console.WriteLine(GC.GetGeneration(a));

            GC.Collect();

            Console.WriteLine(GC.GetGeneration(a));

            //a = null;
            //Console.WriteLine("2"+GC.GetGeneration(a));

            Console.Read();
        }
    }

    public class A
    {
        public int Id { get; set; }

    }

    public struct B
    {
        public int Id { get; set; }

    }
}
