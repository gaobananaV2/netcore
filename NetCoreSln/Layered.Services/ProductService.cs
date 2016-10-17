using Layered.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered.Services
{
    public class ProductService
    {
        private ProductDomainService _productService;
        public ProductService(ProductDomainService ProductService)
        {
            _productService = ProductService;
        }
        public ProductListResponse GetAllProductsFor(ProductListRequest productListRequest)
        {
            ProductListResponse productListResponse = new ProductListResponse();
            try
            {
                IList<Product> productEntities = _productService.GetAllProductsFor(productListRequest.CustomerType);
                productListResponse.Products = productEntities.ConvertToProductListViewModel();
                productListResponse.Success = true;
            }
            catch (Exception ex)
            {
                // Log the exception…
                productListResponse.Success = false;
                // Return a friendly error message
                productListResponse.Message = "An error occurred";
            }
            return productListResponse;
        }
    }
}
