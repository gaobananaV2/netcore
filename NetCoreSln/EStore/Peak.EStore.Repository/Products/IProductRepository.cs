using Peak.EStore.Domains.Products;
using System.Collections.Generic;

namespace Peak.EStore.Repository.Products
{
    public interface IProductRepository
    {
        IList<Product> GetAllProductsIn(int categoryId);
    }
}
