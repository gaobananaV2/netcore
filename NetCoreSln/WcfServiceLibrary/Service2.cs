using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary
{
    public class Service2 : IService2
    {
        public string GetData2(int value)
        {
            if (value == 1)
            {
                throw new NotImplementedException();
            }
            return string.Format("You entered: {0}", value);
        }
    }
}
