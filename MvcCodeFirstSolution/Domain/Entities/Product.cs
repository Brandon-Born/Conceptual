using System.ComponentModel.DataAnnotations;
using Domain.Abstractions;

namespace Domain.Entities
{
    public class Product : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
