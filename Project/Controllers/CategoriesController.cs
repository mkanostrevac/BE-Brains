using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Project.Models;
using Project.Services;

namespace Project.Controllers
{
    [RoutePrefix("project/categories")]
    public class CategoriesController : ApiController
    {
        private ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        // GET: /project/categories - vraca listu svih kategorija
        [Route("")]
        public IEnumerable<CategoryModel> GetCategories()
        {
            return categoriesService.GetAllCategories();
        }

        // POST: /project/categories - dodavanje nove kategorije
        [Route("", Name = "PostCategory")]
        [ResponseType(typeof(CategoryModel))]
        public IHttpActionResult PostCategory(CategoryModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CategoryModel createdCategory = categoriesService.CreateCategory(category);

            return CreatedAtRoute("PostCategory", new { id = createdCategory.ID }, createdCategory);
        }

        // PUT: /project/categories/{id} - promena postojece kategorije
        [Route("{id:int}")]
        [ResponseType(typeof(CategoryModel))]
        public IHttpActionResult PutCategory(int id, CategoryModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.ID)
            {
                return BadRequest();
            }

            CategoryModel updatedCategory = categoriesService.UpdateCategory(category);

            if (updatedCategory == null)
            {
                return NotFound();
            }

            return Ok(updatedCategory);
        }

        // DELETE: /project/categories/{id} - brisanje postojece kategorije
        [Route("{id:int}")]
        [ResponseType(typeof(CategoryModel))]
        public IHttpActionResult DeleteCategory(int id)
        {
            CategoryModel category = categoriesService.DeleteCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // GET: /project/categories/{id} - vraca kategoriju po vrednosti prosledjenog ID-a
        [Route("{id:int}")]
        [ResponseType(typeof(CategoryModel))]
        public IHttpActionResult GetCategory(int id)
        {
            CategoryModel category = categoriesService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
    }
}