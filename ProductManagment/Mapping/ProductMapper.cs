using ProductManagment.Entities;
using ProductManagment.Interfaces;
using ProductManagment.Models;

namespace ProductManagment.Mapping
{
    public class ProductMapper : IMapper<Entities.Product, ProductModel>
    {
        public ProductModel MapFromEntityToModel(Entities.Product source) => new ProductModel
        {
            Name = source.Name,
            Description = source.Description,
            Price = source.Price,
            Category = source.Category,
            Id = source.Id,
        };

        public Entities.Product MapFromModelToEntity(ProductModel source)
        {
            var entity = new Entities.Product();
            MapFromModelToEntity(source, entity);
            return entity;
        }

        public void MapFromModelToEntity(ProductModel source, Entities.Product target)
        {
            target.Name = source.Name;
            target.Description = source.Description;
            target.Price = source.Price;
            target.Category = source.Category;
            target.Id = source.Id;

        }
    }
}
