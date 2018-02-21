using System;
using System.Collections.Generic;

namespace OnionArchitecture.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime PasswordCreationTime { get; set; }

        public virtual ICollection<UserPasswordHistory> UserPasswordHistories { get; set; }
        public virtual ICollection<Link> Links { get; set; }
    }
}