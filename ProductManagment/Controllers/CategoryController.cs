using Microsoft.AspNetCore.Mvc;
using ProductManagment.Models;
using ProductManagment.Interfaces;

namespace ProductManagment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
     
     private readonly ICategoryService _categoryService;
        
        public CategoryController(ICategoryService categoryService) 
        {
            _categoryService = categoryService;
        }

       [HttpPost("createCategory")]

        public CreateCategoryResponse CreateCategory(CategoryModel request) => _categoryService.CreateCategory(request);

       
        [HttpPost("getCategory")]

        public GetCategoryResponse GetCategory(GetCategoryRequest request) => _categoryService.GetCategory(request);

        
        [HttpPost("updateCategory")]

        public UpdateCategoryResponse UpdateCategory(UpdateCategoryRequest request) => _categoryService.UpdateCategory(request);


        [HttpPost("deleteCategory")]

        public DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest request) => _categoryService.DeleteCategory(request);



        //private readonly ProductManagementContext _context;

        //public CategoryController(ProductManagementContext context) 
        //{
        //    _context = context;
        //}



        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]

        //public async Task<ActionResult> Create(Category category)
        //{
        //    await _context.Categories.AddAsync(category);
        //    await _context.SaveChangesAsync();      

        //    return CreatedAtAction(nameof(GetById),new {id  = category.Id}, category);
        //}



        //[HttpGet("{id}")]
        //[ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]

        //public async Task<IActionResult> GetById(int id)
        //{
        //    var category = await _context.Categories.FindAsync(id);
        //    return category == null ? NotFound() : Ok(category);
        //}
    }
}
