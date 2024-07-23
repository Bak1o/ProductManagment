using ProductManagment.Models;

namespace ProductManagment.Interfaces
{
    public interface IProductService
    {
        GetProductResponse GetProduct(GetProductRequest request);
        CreateProductResponse CreateProduct(ProductModel request);
        UpdateProductResponse UpdateProduct(UpdateProductRequest request);
        DeleteProductResponse DeleteProduct(DeleteProductRequest request);
        
    }
}
