namespace CSharp_DesignPatterns.StatePattern
{
    public class PizzaOrderingSystem
    {
        readonly DiscountPolicy discountPolicy;

        public PizzaOrderingSystem(DiscountPolicy discountPolicy)
        {
            this.discountPolicy = discountPolicy;
        }

        public decimal ComputePrice(PizzaOrder order)
        {
            decimal nonDiscounted = order.Pizzas.Sum(p => p.Price);
            decimal discountedValue = discountPolicy(order);
            return nonDiscounted - discountedValue;
        }
    }
}