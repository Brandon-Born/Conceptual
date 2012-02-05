
namespace Domain.Entities.ShippingCalculation
{
    public interface IShippingCalculation
    {
        State State { get;  }
        decimal Calculate(Product product);
    }
}
