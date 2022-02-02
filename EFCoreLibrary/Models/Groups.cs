using System;
using System.Collections.Generic;
using HotChocolate.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLibrary.Models
{
    public partial class Groups
    {
        public Groups()
        {
            Book = new HashSet<Book>();
            User = new HashSet<Users>();
        }

        [Key]        
        [Authorize(Policy="Id_policy")]
        public Guid Id { get; set; }
        [Required]        
        [StringLength(50)]        
        [Authorize(Policy="GroupName_policy")]
        public string GroupName { get; set; }

        [ForeignKey(nameof(GroupId))]
        [InverseProperty(nameof(Book.Group))]
        public virtual ICollection<Book> Book { get; set; }
        [ForeignKey(nameof(GroupId))]
        [InverseProperty(nameof(Users.Group))]
        public virtual ICollection<Users> User { get; set; }
    }
}
