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
using T3_P1_3.Models;
using T3_P1_3.Repositories;

namespace T3_P1_3.Controllers
{
    public class UsersController : ApiController
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: api/Users
        public IEnumerable<User> GetUsers()
        {
            return db.UserRepository.Get();
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.UserRepository.GetByID(id);
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

            db.UserRepository.Update(user);
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

            db.UserRepository.Insert(user);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.UserRepository.GetByID(id);
            if (user == null)
            {
                return NotFound();
            }

            db.UserRepository.Delete(id);
            db.Save();

            return Ok(user);
        }

        [ResponseType(typeof(User))]
        [Route("api/users/{id}/address/{addressId}", Name = "AddAddress")]
        [HttpPut]
        public IHttpActionResult PutAddress(int id, int addressId = 0)
        {
            User user = db.UserRepository.GetByID(id);

            if (user == null)
            {
                return NotFound();
            }

            Address address = db.AddressRepository.GetByID(addressId);

            if (address == null)
            {
                return NotFound();
            }

            user.Address = address;
            db.UserRepository.Update(user);
            db.Save(); // automatski ce biti sacuvana i adresa

            return CreatedAtRoute("AddAddress", new { id = user.Id, addressId = address.Id }, user);
        }
    }
}