using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TestService1();
            TestService2();
        }

        private static void TestService2()
        {
            Service2.SR.Service2Client client = new Service2.SR.Service2Client();
            Console.WriteLine(client.GetData2(3));
        }

        private static void TestService1()
        {
            Service1.SR.Service1Client client = new Service1.SR.Service1Client();
            Console.WriteLine(client.GetData(3));
        }
    }
}
