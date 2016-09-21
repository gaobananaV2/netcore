using MockAndInject.GangOfFour.Principles.refactoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockAndInject.EnterprisePatterns.Null_Object_Pattern
{
    public class NullObjectCache : ICacheStorage
    {
        public void Remove(string key)
        {
            // Do nothing
        }
        public void Store(string key, object data)
        {
            // Do nothing
        }
        public T Retrieve<T>(string storageKey)
        {
            return default(T);
        }
    }
}
