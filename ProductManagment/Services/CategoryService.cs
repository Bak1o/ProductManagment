using Microsoft.EntityFrameworkCore;
using ProductManagment.Interfaces;
using ProductManagment.Mapping;
using ProductManagment.Models;


namespace ProductManagment.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ProductManagementContext _context;
        private readonly IMapper<Entities.Category, CategoryModel> _categoryMapper;
       
        public CategoryService(ProductManagementContext context)
        {
            _categoryMapper = new CategoryMapper();
            _context = context;
        }
        public CreateCategoryResponse CreateCategory(CategoryModel category) 
        {
            var categoryAlreadyExist = _context.Categories.Any(p => p.Id == category.Id);

            if (categoryAlreadyExist) 
            {
                throw new DbUpdateException($"Category with id {category.Id} already exists.");
            }
            var newCategory = _context.Categories.Add(_categoryMapper.MapFromModelToEntity(category));
           
            _context.SaveChanges();
           
            return new CreateCategoryResponse { CreatedCategory = _categoryMapper.MapFromEntityToModel(newCategory.Entity) };
        }

        public GetCategoryResponse GetCategory(GetCategoryRequest getCategoryRequest) 
        {
            var category = _context.Categories.Find(getCategoryRequest.Id);
            var categoryModel = _categoryMapper.MapFromEntityToModel(category);
            var response = new GetCategoryResponse { Category = categoryModel };

            return response;

        }

        public UpdateCategoryResponse UpdateCategory(UpdateCategoryRequest updateCategoryRequest)
        {
            //var categoryExist = _context.Categories.Any(x=>x.Id == updateCategoryRequest.CategoryToUpdate.Id);
           
            //    if (!categoryExist)
            //{
            //    throw new DbUpdateException($"category with such id doesn't exist!");
            //}
            //var existingEntity = _context.Categories.Find(updateCategoryRequest.CategoryToUpdate.Id);

            ////_categoryMapper.MapFromEntityToModel()

            //existingEntity.Name = updateCategoryRequest.CategoryToUpdate.Name;
            //existingEntity.Code = updateCategoryRequest.CategoryToUpdate.Code;
            //existingEntity.Description = updateCategoryRequest.CategoryToUpdate.Description;

            //_context.SaveChanges();
            //return new UpdateCategoryResponse { UpdatedCategory = updateCategoryRequest.CategoryToUpdate };

            var existingCategoryToUpdate = _context.Categories.Find(updateCategoryRequest.CategoryToUpdate.Id);
            if (existingCategoryToUpdate == null) 
            {
                throw new DbUpdateException($" category with id{updateCategoryRequest.CategoryToUpdate.Id} doesn't exists");
            
            }

            _categoryMapper.MapFromModelToEntity(updateCategoryRequest.CategoryToUpdate, existingCategoryToUpdate);
            _context.SaveChanges();
            return new UpdateCategoryResponse { UpdatedCategory = updateCategoryRequest.CategoryToUpdate };
        }

        public DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest deleteCategoryRequest)
        {
            var categoryToDelete = _context.Categories.Find(deleteCategoryRequest.Id);
            if(categoryToDelete == null)
            {
                throw new DbUpdateException($"category with id {deleteCategoryRequest.Id} doesn't exists");
            }

            _context.Categories.Remove(categoryToDelete);
            _context.SaveChanges();
            return new DeleteCategoryResponse();
        }
    }
}
