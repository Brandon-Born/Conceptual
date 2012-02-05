using System.Collections.Generic;

namespace Domain.Entities.ShippingCalculation
{
    public static class ShippingCalculationFactory
    {
        public static IEnumerable<IShippingCalculation> GetShippingCalculations()
        {
            return new List<IShippingCalculation>
                   {
                       new AlaskaShippingCalculation(),
                       new CaliforniaShippingCalculation(),
                       new UtahShippingCalculation()
                   };
        }

    }
}
