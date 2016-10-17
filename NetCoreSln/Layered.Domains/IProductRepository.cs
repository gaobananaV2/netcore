using Layered.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered.Domains
{
    //The Repository pattern acts as an in-memory collection or repository for business entities, 
    //completely abstracting away the underlying data infrastructure.
    public interface IProductRepository
    {
        IList<Product> FindAll();
    }
}
