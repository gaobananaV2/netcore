using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util.Domain;

namespace Domains.Domains.Agreements
{
    public class AgreementSign : BaseEntity 
    {
        #region Properties
        public int AgreeMentId { get; set; }
        public string AgreeOrNot { get; set; }
        public string StfId { get; set; }
        public DateTime? CreateDate { get; set; }
        public virtual Agreement Agreement { get; set; } 
        #endregion
    }
}
