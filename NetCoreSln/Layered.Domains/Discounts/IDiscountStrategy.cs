using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered.Domains.Discounts
{
    //he Strategy pattern enables an algorithm to be encapsulated within a class and
    //switched at runtime to alter an object’s behavior.
    public interface IDiscountStrategy
    {
        decimal ApplyExtraDiscountsTo(decimal originalSalePrice);
    }
}
