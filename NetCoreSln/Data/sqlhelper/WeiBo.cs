using Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Peak.Utilities;

namespace Data.sqlhelper
{
    public class WeiBo : BaseModel, IWeiBo<WeiBo>
    {
        #region Properties
        public int WeiBoId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        #endregion

        #region Methods
        public IList<WeiBo> GetList()
        { 
            string strSql = string.Format(@"
                      SELECT  [WeiBoID]
                      ,[Title]
                      ,[Content]
                      ,[CreateDate]
                      ,[UpdateDate]
                  FROM [WeiBo].[dbo].[WeiBo]      
            ");

            var dt = SqlHelper.Query(strSql).Tables[0];
            List<WeiBo> list = new List<WeiBo>();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(this.Parse(dt.Rows[i]));
                } 
            }
            return list;
        }
        #endregion


        #region Helper Methods
        private WeiBo Parse(DataRow row)
        {
            WeiBo model = new WeiBo();
            if (row.Table.Columns.Contains("WeiBoID"))
            {
                model.WeiBoId = row["WeiBoID"].ToInt();
            }

            if (row.Table.Columns.Contains("Title"))
            {
                model.Title = row["Title"].ToString();
            }

            if (row.Table.Columns.Contains("Content"))
            {
                model.Content = row["Content"].ToString();
            }

            if (row.Table.Columns.Contains("CreateDate"))
            {
                model.CreateDate = row["CreateDate"].ToDateTime();
            }

            if (row.Table.Columns.Contains("UpdateDate"))
            {
                model.UpdateDate = row["UpdateDate"].ToDateTime();
            }
            return model;
        }
        #endregion
    }
}
