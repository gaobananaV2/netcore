using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util.Domain;

namespace Domains.Domains.Users
{
    public class Group : BaseEntity
    {
        #region Properties
        public int Code { get; set; }
        public string Name { get; set; }
        #endregion
    }
}
