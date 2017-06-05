using Core.Entities.Foundation;

namespace Core.Entities
{
   public class Product : BaseEntity
    {
        // Base Model for Products 
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

    }
}
