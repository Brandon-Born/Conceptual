
namespace Domain.Entities.ShippingCalculation
{
    internal class CaliforniaShippingCalculation : IShippingCalculation
    {
        public State State
        {
            get { return State.California; }
        }

        public decimal Calculate(Product product)
        {
            return product.Price.RetailPrice + 13.00M;
        }
    }
}
