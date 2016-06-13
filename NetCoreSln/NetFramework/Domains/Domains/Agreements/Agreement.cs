using System;
using Domains.Domains.Users;
using Util.Domain;

namespace Domains.Domains.Agreements
{
    public class Agreement : BaseEntity 
    {
        #region Properties
        public string Title { get; set; } 
        public int CategoryCode { get; set; } 
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Creator { get; set; }
        public virtual Group Category { get; set; }  //引用属性
        #endregion 

    }
}