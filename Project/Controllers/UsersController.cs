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
    [RoutePrefix("project/users")]
    public class UsersController : ApiController
    {
        private IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        // GET: /project/users - vraca listu svih korisnika
        [Route("")]
        public IEnumerable<UserModel> GetUsers()
        {
            return usersService.GetAllUsers();
        }

        // GET: /project/users/{id} - vraca korisnika po vrednosti prosledjenog ID-a
        [Route("{id:int}")]
        [ResponseType(typeof(UserModel))]
        public IHttpActionResult GetUser(int id)
        {
            UserModel user = usersService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: /project/users - dodavanje novog korisnika
        [Route("")]
        [ResponseType(typeof(UserModel))]
        public IHttpActionResult PostUser(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserModel createdUser = usersService.CreateUser(user);

            return Created("", createdUser);
        }

        // PUT: /project/users/{id} - promena postojeceg korisnika
        [Route("{id:int}")]
        [ResponseType(typeof(UserModel))]
        public IHttpActionResult PutUser(int id, UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.ID)
            {
                return BadRequest();
            }

            UserModel updatedUser = usersService.UpdateUser(id, user.FirstName, user.LastName, user.Username, user.Email);

            if (updatedUser == null)
            {
                return NotFound();
            }

            return Ok(updatedUser);
        }

        // PUT: /project/users/change/{id}/role/{role} - promena role (uloge) postojeceg korisnika
        [Route("change/{id:int}/role/{role:int}")]
        [ResponseType(typeof(UserModel))]
        public IHttpActionResult PutUserRole(int id, UserRoles role)
        {
            UserModel userWithUpdatedRole = usersService.UpdateUserRole(id, role);

            if (userWithUpdatedRole == null)
            {
                return NotFound();
            }

            return Ok(userWithUpdatedRole);
        }

        // PUT: /project/users/changePassword/{id} - promena lozinke postojeceg korisnika
        [Route("changePassword/{id:int}")]
        [ResponseType(typeof(UserModel))]
        public IHttpActionResult PutPassword(int id, [FromUri] string oldPassword, [FromUri]string newPassword)
        {
            UserModel userWithUpdatedPassword = usersService.UpdatePassword(id, oldPassword, newPassword);

            if (userWithUpdatedPassword == null)
            {
                return NotFound();
            }

            return Ok(userWithUpdatedPassword);
        }

        // DELETE: /project/users/{id} - brisanje postojeceg korisnika
        [Route("{id:int}")]
        [ResponseType(typeof(UserModel))]
        public IHttpActionResult DeleteUser(int id)
        {
            UserModel user = usersService.DeleteUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // GET: /project/users/by-username/{username} - vraca korisnika po vrednosti prosledjenog username-a
        [Route("by-username/{username}")]
        [ResponseType(typeof(UserModel))]
        public IHttpActionResult GetByUsername(string username)
        {
            UserModel user = usersService.GetUserByUsername(username);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}