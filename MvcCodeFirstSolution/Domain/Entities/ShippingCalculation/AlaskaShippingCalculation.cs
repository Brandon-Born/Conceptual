
namespace Domain.Entities.ShippingCalculation
{
    internal class AlaskaShippingCalculation : IShippingCalculation
    {
        public State State
        {
            get { return State.Alaska; }
        }

        public decimal Calculate(Product product)
        {
            return product.Price.RetailPrice + 13.00M;
        }
    }
}
