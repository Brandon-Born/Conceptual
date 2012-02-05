using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Abstractions;

namespace Domain.Entities
{
    public class Category : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
