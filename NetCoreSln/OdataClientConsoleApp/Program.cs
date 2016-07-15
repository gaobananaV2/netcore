using System;
using OdataClientConsoleApp.WebApiOdata.Models;
using Microsoft.OData.Core;
using OdataClientConsoleApp.ProductService;

namespace OdataClientConsoleApp
{
    class Program
    {
        static void ListAllProducts(Container container)
        {
            foreach (var p in container.Demos)
            {
                Console.WriteLine("{0} {1}", p.Name, p.Id);
            }
        }

        static void Main(string[] args)
        {
            string serviceUri = "http://localhost:58390/";
            var container = new Container(new Uri(serviceUri));
            //container.SendingRequest2 += Container_SendingRequest2;
            ListAllProducts(container);
        }

        private static void Container_SendingRequest2(object sender, Microsoft.OData.Client.SendingRequest2EventArgs e)
        {
            IODataRequestMessage requestMessage = (IODataRequestMessage)e.RequestMessage;
            if (requestMessage != null)
            {
                requestMessage.SetHeader("MinDataServiceVersion", "3.0");
            }
        }

        static void AddProduct(Container container, Product product)
        {
            container.AddToProducts(product);
            var serviceResponse = container.SaveChanges();
            foreach (var operationResponse in serviceResponse)
            {
                Console.WriteLine("Response: {0}", operationResponse.StatusCode);
            }
        }

    }
}
