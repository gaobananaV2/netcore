﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.sqlhelper
{
    public interface IWeiBo<T>
    {
        IList<T> GetList();
    }
}
