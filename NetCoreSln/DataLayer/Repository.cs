using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface Repository
    {
        IQueryable  Query(QueryModel model);
        void Remove(QueryModel model);

        void Insert(Item item);

        void Update(Item item);
    }

    public class Item
    {
    }

    public class QueryModel
    {
    }
}
