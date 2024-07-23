using ProductManagment.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProductManagment.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Category Category { get; set; }

        public string Description { get; set; }
    }
}
