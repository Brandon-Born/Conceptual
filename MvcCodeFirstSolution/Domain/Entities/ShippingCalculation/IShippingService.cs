
namespace Domain.Entities.ShippingCalculation
{
    public interface IShippingService
    {
        decimal CalculateShippingAmount(Product product, State shipToState);
    }
}
