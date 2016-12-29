using System;

namespace WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            LoopCall();
          
            Console.Read();
        }

        private static void LoopCall()
        {
            var proxy = new Calc.SR.CalcServiceClient(); 
            for (int i = 0; i < 3; i++)
            { 
                proxy.DoWork();
            }
        }
    }
}
