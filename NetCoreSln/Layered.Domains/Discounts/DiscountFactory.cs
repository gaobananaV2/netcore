using Layered.Infrastructure.Enum;

namespace Layered.Domains.Discounts
{
    //The Factory pattern enables a class to delegate the responsibility of creating a valid object.
    public static class DiscountFactory
    {
        public static IDiscountStrategy GetDiscountStrategyFor(CustomerType customerType)
        {
            switch (customerType)
            {
                case CustomerType.Trade:
                    return new TradeDiscountStrategy();
                default:
                    return new NullDiscountStrategy();
            }
        }
    }
}
