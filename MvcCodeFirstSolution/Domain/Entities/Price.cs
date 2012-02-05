using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    //[ComplexType]
    public class Price
    {
        public decimal WholesalePrice { get; set; }
        public decimal RetailPrice { get; set; }
        //public decimal Tax { get; set; }

    }
}
