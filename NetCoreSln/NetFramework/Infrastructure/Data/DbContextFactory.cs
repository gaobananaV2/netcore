using System.Configuration;
using Infrastructure.Caching;

namespace Infrastructure.Data
{
    public class DbContextFactory
    {
        public static IDbContext GetDbContext()
        {
            //var cacheManager = new PerRequestCacheManager();
            ////线程内实例唯一
            //var db = cacheManager.Get<IDbContext>("DbContext");
            //if (db == null)
            //{
                var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                var db = new HrObjectContext(connectionString);
            //    cacheManager.Set("DbContext", db);
            //}
            return db; 
        }
    }
}