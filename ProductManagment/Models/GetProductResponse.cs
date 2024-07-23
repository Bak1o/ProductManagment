using ProductManagment.Entities;

namespace ProductManagment.Models
{
    public class GetProductResponse
    {
        internal ProductModel Product;
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Category Category { get; set; }

        public string Description { get; set; }
    }
}
