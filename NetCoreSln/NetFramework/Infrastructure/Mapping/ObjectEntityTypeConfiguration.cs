﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Infrastructure.Mapping
{
    public abstract class ObjectEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        protected ObjectEntityTypeConfiguration()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {

        }
    } 
}
