using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockAndInject.GangOfFour.Principles.refactoring
{
    public class ProductService
    {
        //The Dependency inversion Principle
        //The  ProductService class now depends only on an abstraction rather than a concrete implementation
        private IProductRepository _productRepository;

        //The ProductService class is still tied to the concrete implementation of the  ProductRepository
        //because it’s currently the job of the  ProductService class to create the instance.This can be seen in
        //the ProductService class constructor. 
        //public ProductService()
        //{
        //    _productRepository = new ProductRepository();
        //}


        //Dependency Injection can move the responsibility of creating
        //Dependency Injection comes in three flavors: Constructer, Method, and Property.
        //the ProductRepository implementation out of the  ProductService class and having it injected via
        //the class’s constructor
        //public ProductService(IProductRepository productRepository)
        //{
        //    _productRepository = productRepository;
        //}


        private ICacheStorage _cacheStorage;
        public ProductService(IProductRepository productRepository,
        ICacheStorage cacheStorage)
        {
            _productRepository = productRepository;
            _cacheStorage = cacheStorage;
        }

        public IList<Product> GetAllProductsIn(int categoryId)
        {
            IList<Product> products;
            string storageKey = string.Format("products_in_category_id_{0}", categoryId);
            products = _cacheStorage.Retrieve<List<Product>>(storageKey);
            if (products == null)
            {
                products = _productRepository.GetAllProductsIn(categoryId);
                _cacheStorage.Store(storageKey, products);
            }
            return products;
        }
    }
    //By removing the responsibility of obtaining dependen-
    //cies from the ProductService, you are ensuring that the  ProductService class adheres to the Single
    //Responsibility principle


}
