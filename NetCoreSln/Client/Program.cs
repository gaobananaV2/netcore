

using System;
using System.Collections.Generic;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> tmp = new List<int>() { 5, 1, 22, 11, 4 };
            //tmp.Sort((x, y) => -x.CompareTo(y));
            //for (int i = 0; i < tmp.Count; i++)
            //{
            //    Console.WriteLine(tmp[i]);
            //}


            List<Tuple<int, int>> tmp2 = new List<Tuple<int, int>>()
            {
                new Tuple<int,int>(2,1),
                new Tuple<int,int>(53,1),
                new Tuple<int,int>(12,1),
                new Tuple<int,int>(22,3),
                new Tuple<int,int>(1,2),
            };

            tmp2.Sort((x, y) => (x.Item1.CompareTo(y.Item1) + x.Item2.CompareTo(y.Item2) * 2));
            for (int i = 0; i < tmp2.Count; i++)
            {
                Console.WriteLine(tmp2[i]);
            }
        }
    }
}
