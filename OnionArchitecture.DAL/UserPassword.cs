//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnionArchitecture.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserPassword
    {
        public System.Guid Id { get; set; }
        public System.Guid UserId { get; set; }
        public string Password { get; set; }
        public short Status { get; set; }
        public System.DateTime CreationDate { get; set; }
    
        public virtual User User { get; set; }
    }
}
