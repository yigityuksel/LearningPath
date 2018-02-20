using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionArchitecture.Core.Models
{
    public class Link
    {
        [Key]
        [Column(Order = 1)]
        public Guid Id { get; set; }
        [Key]
        [Column(Order = 2)]
        public Guid UserId { get; set; }
        public short Type { get; set; }
        public DateTime ExpirationDateTime { get; set; }
        public virtual User User { get; set; }
    }
}