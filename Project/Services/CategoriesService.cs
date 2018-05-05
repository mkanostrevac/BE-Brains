using System.Collections.Generic;
using System.Linq;
using Project.Models;
using Project.Repositories;

namespace Project.Services
{
    public class CategoriesService : ICategoriesService
    {
        private IUnitOfWork db;

        public CategoriesService(IUnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<CategoryModel> GetAllCategories()
        {
            return db.CategoriesRepository.Get();
        }

        public CategoryModel CreateCategory(CategoryModel newCategory)
        {
            db.CategoriesRepository.Insert(newCategory);
            db.Save();

            return newCategory;
        }

        public CategoryModel UpdateCategory(CategoryModel category)
        {
            db.CategoriesRepository.Update(category);
            db.Save();

            return category;
        }

        public CategoryModel DeleteCategory(int categoryId)
        {
            CategoryModel category = db.CategoriesRepository.GetByID(categoryId);

            if (category != null)
            {
                db.CategoriesRepository.Delete(category);
                db.Save();
            }

            return category;
        }

        public CategoryModel GetCategory(int id)
        {
            return db.CategoriesRepository.GetByID(id);
        }
    }
}