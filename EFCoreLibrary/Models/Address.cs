using System;
using System.Collections.Generic;
using HotChocolate.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLibrary.Models
{
    public partial class Address
    {
        public Address()
        {
            Book = new HashSet<Book>();
        }

        [Key]        
        [Authorize(Policy="Id_policy")]
        public Guid Id { get; set; }
        [Required]        
        [StringLength(50)]        
        [Authorize(Policy="City_policy")]
        public string City { get; set; }
        [Required]        
        [StringLength(50)]        
        [Authorize(Policy="Street_policy")]
        public string Street { get; set; }

        [InverseProperty("Address")]
        public virtual ICollection<Book> Book { get; set; }
    }
}
