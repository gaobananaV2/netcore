using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebServiceConsole.WS.SR; 

namespace TestWebServiceConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TestWebServiceSoapClient client = new TestWebServiceSoapClient();
            
            MySoapHeader header = new MySoapHeader();
            header.UserName = "peak";
            header.PassWord = "111111";
            var result = client.HelloWorldWithUserNameAndPassWord(header);
            Console.WriteLine(result);

            client.HelloWorldWithLog();
            client.HelloWorldWithLog2();
            Console.Read();
        }
    }
}
