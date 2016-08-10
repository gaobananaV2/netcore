using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Data.Dapper
{
    public class WeiBoDapper
    {
        public IList<WeiBo> GetList()
        {
            IDbConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            string query = @"   SELECT  [WeiBoID]
                      ,[Title]
                      ,[Content]
                      ,[CreateDate]
                      ,[UpdateDate]
                  FROM[WeiBo].[dbo].[WeiBo]  "; 
            return conn.Query<WeiBo>(query).AsList(); 
        }

    }

    public class WeiBo
    {
        public int WeiBoId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

    }
}
