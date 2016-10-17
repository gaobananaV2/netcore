using Layered.Domains;
using Layered.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered.Services
{
    public static class ProductMapperExtensionMethods
    {
        public static IList<ProductViewModel> ConvertToProductListViewModel(this IList<Product> products)
        {
            IList<ProductViewModel> productViewModels = new List<ProductViewModel>();
            foreach (Product p in products)
            {
                productViewModels.Add(p.ConvertToProductViewModel());
            }
            return productViewModels;
        }
        public static ProductViewModel ConvertToProductViewModel(this Product product)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.ProductId = product.Id;
            productViewModel.Name = product.Name;
            productViewModel.RRP = String.Format("{0:C}", product.Price.RRP);
            productViewModel.SellingPrice =
            String.Format("{0:C}", product.Price.SellingPrice);
            if (product.Price.Discount > 0)
                productViewModel.Discount = String.Format("{0:C}", product.Price.Discount);
            if (product.Price.Savings < 1 && product.Price.Savings > 0)
                productViewModel.Savings = product.Price.Savings.ToString("#%");
            return productViewModel;
        }
    }
}
