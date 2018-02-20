using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionArchitecture.Core.Models
{
    public class UserPassword
    {
        [Key]
        [Column(Order = 1)]
        public Guid Id { get; set; }
        [Key]
        [Column(Order = 2)]
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public short Status { get; set; }
        public virtual User User { get; set; }
    }
}