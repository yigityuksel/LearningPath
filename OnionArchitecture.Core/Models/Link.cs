using System;
using OnionArchitecture.Core.Enums;

namespace OnionArchitecture.Core.Models
{
    public class Link
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public LinkType Type { get; set; }
        public DateTime ExpirationDateTime { get; set; }
        public virtual User User { get; set; }
    }
}