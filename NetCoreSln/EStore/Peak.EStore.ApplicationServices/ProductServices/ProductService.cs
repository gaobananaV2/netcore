using Peak.EStore.Domains.Products;
using Peak.EStore.Repository.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.EStore.ApplicationServices.ProductServices
{
    class ProductService
    {
        private IProductRepository _productRepository;
        public ProductService()
        {
            _productRepository = new ProductRepository();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public IList<Product> GetAllProductsIn(int categoryId)
        {
            return _productRepository.GetAllProductsIn(categoryId);
        }
    }
}
