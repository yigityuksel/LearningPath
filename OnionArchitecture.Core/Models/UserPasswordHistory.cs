using System;

namespace OnionArchitecture.Core.Models
{
    public class UserPasswordHistory
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime CreationDateTime { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}