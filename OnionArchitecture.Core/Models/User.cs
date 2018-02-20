using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnionArchitecture.Core.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public List<UserPassword> UserPassword { get; set; }
    }
}