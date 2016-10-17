using Layered.Domains.Discounts;
using Layered.Infrastructure.Enum;
using System.Collections.Generic;

namespace Layered.Domains
{
    //service layer, which will act as the gateway into the application
    //The role of the service layer is to act as an entry point into the application; sometimes this is known as a facade.

    //The service layer provides the presentation layer with a strongly typed view model, sometimes called the presentation model.
    //A view model is a strongly typed class that is optimized for specific views.
    public class ProductDomainService
    {
        private IProductRepository _productRepository;
        public ProductDomainService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IList<Product> GetAllProductsFor(CustomerType customerType)
        {
            IDiscountStrategy discountStrategy = DiscountFactory.GetDiscountStrategyFor(customerType);
            IList<Product> products = _productRepository.FindAll();
            products.Apply(discountStrategy);
            return products;
        }
    }
}
