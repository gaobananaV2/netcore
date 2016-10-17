using Layered.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered.Presentation
{
    //The presenter class is responsible for obtaining data, handling user events, and updating the view via its interface.
    public class ProductListPresenter
    {
        private IProductListView _productListView;
        private ProductService _productService;
        public ProductListPresenter(IProductListView ProductListView, ProductService ProductService)
        {
            _productService = ProductService;
            _productListView = ProductListView;
        }
        public void Display()
        {
            ProductListRequest productListRequest = new ProductListRequest();
            productListRequest.CustomerType = _productListView.CustomerType;
            ProductListResponse productResponse =
            _productService.GetAllProductsFor(productListRequest);
            if (productResponse.Success)
            {
                _productListView.Display(productResponse.Products);
            }
            else
            {
                _productListView.ErrorMessage = productResponse.Message;
            }
        }
    }

    //The benefit of having the presentation
    //layer is that it is now easy to test the presentation of the data and interactions between the user and
    //the system without worrying about the difficult-to-unit-test web forms.
}
