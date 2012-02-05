using System;

namespace Domain.Entities.ShippingCalculation
{
    internal class UtahShippingCalculation : IShippingCalculation
    {
        public State State
        {
            get { return State.Utah; }
        }

        public decimal Calculate(Product product)
        {
            return product.Price.RetailPrice + 13.00M;
        }
    }
}
