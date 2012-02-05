using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infrastructure.Mappings
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            //// Primary Key
            //this.HasKey(c => c.Id);


            //this.ToTable("Categories");
            //this.Property(c => c.Id).HasColumnName("CategoryId");
            //this.Property(c => c.Name).HasColumnName("CategoryName").IsRequired().HasMaxLength(50);
        }
    }
}
