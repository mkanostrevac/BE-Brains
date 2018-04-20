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
using T3_P1_2.Models;
using T3_P1_2.Repositories;

namespace T3_P1_2.Controllers
{
    public class UsersController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: api/Users
        public IEnumerable<User> GetUsers()
        {
            return unitOfWork.UserRepository.Get();
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = unitOfWork.UserRepository.GetByID(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            unitOfWork.UserRepository.Update(user);
            unitOfWork.Save();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unitOfWork.UserRepository.Insert(user);
            unitOfWork.Save();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = unitOfWork.UserRepository.GetByID(id);
            if (user == null)
            {
                return NotFound();
            }

            unitOfWork.UserRepository.Delete(id);
            unitOfWork.Save();

            return Ok(user);
        }
    }
}