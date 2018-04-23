using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace T3_P1_3.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }


        public Address()
        {
            Users = new List<User>();
        }

    }
}