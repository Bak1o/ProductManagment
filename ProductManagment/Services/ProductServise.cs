using Microsoft.EntityFrameworkCore;
using ProductManagment.Interfaces;
using ProductManagment.Mapping;
using ProductManagment.Models;

namespace ProductManagment.Services
{
    public class ProductServise : IProductService
    {
        private readonly ProductManagementContext _context;
        private readonly IMapper<Entities.Product, ProductModel> _productMapper;

        public ProductServise(ProductManagementContext context)
        {
            _productMapper = new ProductMapper();
            _context = context;
        }
        public CreateProductResponse CreateProduct(ProductModel product)
        {
            var productAlreadyExist = _context.Products.Any(p => p.Id == product.Id);

            if (productAlreadyExist)
            {
                throw new DbUpdateException($"Product with id {product.Id} already exists.");
            }
            var newProduct = _context.Products.Add(_productMapper.MapFromModelToEntity(product));

            _context.SaveChanges();

            return new CreateProductResponse { CreatedProduct = _productMapper.MapFromEntityToModel(newProduct.Entity) };
        }

        public GetProductResponse GetProduct(GetProductRequest getProductRequest)
        {
            var product = _context.Products.Find(getProductRequest.Id);

            return new GetProductResponse { Product = _productMapper.MapFromEntityToModel(product) };

        }

        public UpdateProductResponse UpdateProduct(UpdateProductRequest updateProductRequest) 
        {
            var existingProductToUpdate = _context.Products.Find(updateProductRequest.ProductToUpdate.Id);
            if (existingProductToUpdate == null)
            {
                throw new DbUpdateException($"product with tis id {updateProductRequest.ProductToUpdate.Id} doesn't exists");   
            }

            _productMapper.MapFromModelToEntity(updateProductRequest.ProductToUpdate,existingProductToUpdate);
            _context.SaveChanges();

            return new UpdateProductResponse { UpdatedProduct = updateProductRequest.ProductToUpdate };
            
            }

        public DeleteProductResponse DeleteProduct(DeleteProductRequest deleteProductRequest)
        {
            var productToDelete = _context.Products.Find(deleteProductRequest.Id);

            if (productToDelete == null) 
            {
                throw new DbUpdateException($"product with id {deleteProductRequest.Id} doesn't exists");
                    
            }

            _context.Products.Remove(productToDelete);
            _context.SaveChanges();

            return new DeleteProductResponse { };
        }

       
    }
}
