using System;

namespace NetBoilerplate.Domain.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
