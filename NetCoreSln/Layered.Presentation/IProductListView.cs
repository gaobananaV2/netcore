using Layered.Infrastructure.Enum;
using Layered.Services;
using System.Collections.Generic;

namespace Layered.Presentation
{
    public interface IProductListView
    {
        void Display(IList<ProductViewModel> products);
        CustomerType CustomerType { get; }
        string ErrorMessage { set; }
    }
}
