using Client.WebApiOdata.Models;
using Microsoft.OData.Core;
using System;

namespace Client
{
    class Program
    {
        static void ListAllProducts(Default.Container container)
        {
            foreach (var p in container.Demos)
            {
                Console.WriteLine("{0} {1} {2}", p.Name, p.Price, p.Category);
            }
        } 

        static void Main(string[] args)
        {
            string serviceUri = "http://localhost:56744/";
            var container = new Default.Container(new Uri(serviceUri));
            container.SendingRequest2 += Container_SendingRequest2;
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

        static void AddProduct(Default.Container container, Product product)
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
