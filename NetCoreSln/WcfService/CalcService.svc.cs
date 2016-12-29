using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WcfService
{

    public class CalcService : ICalcService
    {
        bool ICalcService.DoWork()
        {
            Debug.Write("thread " + Thread.CurrentThread.ManagedThreadId.ToString());
            Debug.WriteLine("start operation ");
            Thread.Sleep(1000);
            Debug.WriteLine("end operation");
            return true;
        }
    }
}
