using Microsoft.AspNetCore.Mvc;
using ProductManagment.Interfaces;
using ProductManagment.Models;

namespace ProductManagment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("createProduct")]

        public CreateProductResponse CreateProduct(ProductModel request) => _productService.CreateProduct(request);


        [HttpPost("getProduct")]

        public GetProductResponse GetProduct(GetProductRequest request) => _productService.GetProduct(request);

        
        [HttpPost("updateProduct")]

        public UpdateProductResponse UpdateProduct(UpdateProductRequest request) => _productService.UpdateProduct(request);

       
        [HttpPost("deleteProduct")]

        public DeleteProductResponse DeleteProduct(DeleteProductRequest request) => _productService.DeleteProduct(request);


    }
}
