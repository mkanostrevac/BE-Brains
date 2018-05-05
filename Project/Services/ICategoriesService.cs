using System.Collections.Generic;
using Project.Models;

namespace Project.Services
{
    public interface ICategoriesService
    {
        IEnumerable<CategoryModel> GetAllCategories();

        CategoryModel CreateCategory(CategoryModel newCategory);

        CategoryModel UpdateCategory(CategoryModel category);

        CategoryModel DeleteCategory(int id);

        CategoryModel GetCategory(int id);
    }
}
