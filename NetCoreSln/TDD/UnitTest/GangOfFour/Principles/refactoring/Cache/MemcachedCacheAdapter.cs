﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockAndInject.GangOfFour.Principles.refactoring
{
    public class MemcachedCacheAdapter : ICacheStorage
    {
        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public T Retrieve<T>(string key)
        {
            throw new NotImplementedException();
        }

        public void Store(string key, object data)
        {
            throw new NotImplementedException();
        }
    }
}
