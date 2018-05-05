using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public enum UserRoles { ROLE_ADMIN, ROLE_CUSTOMER, ROLE_SELLER }

    [Table("users")]
    public class UserModel
    {
        public int ID { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("user_role")]
        public UserRoles UserRole { get; set; }
    }
}