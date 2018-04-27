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
using T4_P1_2.Models;
using T4_P1_2.Repositories;

namespace T4_P1_2.Controllers
{
    public class UsersController : ApiController
    {
        private IUnitOfWork db;

        public UsersController(IUnitOfWork db)
        {
            this.db = db;
        }

        // GET: api/Users
        public IEnumerable<User> GetUsers()
        {
            return db.UsersRepository.Get();
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.UsersRepository.GetByID(id);
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

            db.UsersRepository.Update(user);
            db.Save();

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

            db.UsersRepository.Insert(user);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.UsersRepository.GetByID(id);
            if (user == null)
            {
                return NotFound();
            }

            db.UsersRepository.Delete(id);
            db.Save();

            return Ok(user);
        }
    }
}