using System.Collections.Generic;

namespace CSharp_DesignPatterns.StatePattern
{
    public class DiscountPolicy
    {

        public delegate decimal DiscountPolicy(PizzaOrder order);

        public class BestDiscount
        {
            private readonly List<DiscountPolicy> policies;

            public BestDiscount(List<DiscountPolicy> policies)
            {
                this.policies = policies;
            }

            public decimal ComputePolicy(PizzaOrder order)
            {
                return policies.Max(ComputePolicy => ComputePolicy.Invoke(order));
            }
        }

        public static class Policies
        {
            public static decimal BuyOneGetOneFree(PizzaOrder order)
            {
                var pizzas = order.Pizzas;
                if (pizzas.Count < 2)
                {
                    return 0m;
                }
                return pizzas.Min(p => p.Price);
            }

            public static decimal FivePercentOffMoreThanFiftyDollars(PizzaOrder order)
            {
                decimal nonDiscounted = order.Pizzas.Sum(p => p.Price);
                return nonDiscounted >= 50 ? nonDiscounted * 0.05m : 0m;
            }

            public static decimal FiveDollarsOffStuffedCrust(PizzaOrder order)
            {
                return order.Pizzas.Sum(p => p.Crust == FiveDollarsOffStuffedCrust.Stuffed ? 5m : 0m);
            }

            public static DiscountPolicy CreateBest(params DiscountPolicy[] policies)
            {
                return order => policies.Max(policy => policy.Invoke(order));
            }

            public static DiscountPolicy DiscountALLthePizzas()
            {
                return CreateBest(
                    BuyOneGetOneFree,
                    FivePercentOffMoreThanFiftyDollars,
                    FiveDollarsOffStuffedCrust);

            }
        }
    }
}