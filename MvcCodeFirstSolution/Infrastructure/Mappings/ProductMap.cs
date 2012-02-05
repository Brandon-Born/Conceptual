using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infrastructure.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            //this.Property(p => p.Price.RetailPrice).HasColumnName("RetailPrice");
            //this.Property(p => p.Price.WholesalePrice).HasColumnName("WholesalePrice");
        }
    }
}
