using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.sqlhelper
{
    public class WeiBoAnalysis : BaseModel, IWeiBoAnalysis<WeiBoAnalysis>
    {
        #region Properties
        public int WeiBoId { get; set; }
        public int CommentCount { get; set; }
        public int ForwardCount { get; set; } 
        #endregion

        #region Methods
        public IList<WeiBoAnalysis> GetList()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
