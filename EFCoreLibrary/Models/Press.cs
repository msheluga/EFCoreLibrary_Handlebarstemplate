using System;
using System.Collections.Generic;
using HotChocolate.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLibrary.Models
{
    public partial class Press
    {
        public Press()
        {
            Book = new HashSet<Book>();
        }

        [Key]        
        [Authorize(Policy="Id_policy")]
        public Guid Id { get; set; }
        [Required]        
        [StringLength(50)]        
        [Authorize(Policy="Name_policy")]
        public string Name { get; set; }
        [Required]        
        [StringLength(150)]        
        [Authorize(Policy="Email_policy")]
        public string Email { get; set; }
        [Authorize(Policy="Category_policy")]
        public int Category { get; set; }

        [InverseProperty("Press")]
        public virtual ICollection<Book> Book { get; set; }
    }
}
