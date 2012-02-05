using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities.ShippingCalculation
{
    public class ShippingService : IShippingService
    {
        private readonly IDictionary<State, IShippingCalculation> _shippingCalculations;

        public ShippingService(IEnumerable<IShippingCalculation> shippingCalculations)
        {
            _shippingCalculations = shippingCalculations.ToDictionary(s => s.State);
        }

        public decimal CalculateShippingAmount(Product product, State shipToState)
        {
            return _shippingCalculations[shipToState].Calculate(product);
        }
    }
}
