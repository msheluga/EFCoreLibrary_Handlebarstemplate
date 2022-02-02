using System;
using System.Collections.Generic;
using HotChocolate.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLibrary.Models
{
    public partial class Book
    {
        public Book()
        {
            Group = new HashSet<Groups>();
        }

        [Key]        
        [Authorize(Policy="Id_policy")]
        public Guid Id { get; set; }
        [Required]        
        [Column("ISBN")]        
        [StringLength(30)]        
        [Authorize(Policy="Isbn_policy")]
        public string Isbn { get; set; }
        [Required]        
        [StringLength(50)]        
        [Authorize(Policy="Title_policy")]
        public string Title { get; set; }
        [Required]        
        [StringLength(50)]        
        [Authorize(Policy="Author_policy")]
        public string Author { get; set; }
        [Column(TypeName = "money")]        
        [Authorize(Policy="Price_policy")]
        public decimal Price { get; set; }
        [Authorize(Policy="AddressId_policy")]
        public Guid AddressId { get; set; }
        [Authorize(Policy="PressId_policy")]
        public Guid PressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Book")]
        public virtual Address Address { get; set; }
        [ForeignKey(nameof(PressId))]
        [InverseProperty("Book")]
        public virtual Press Press { get; set; }
        [ForeignKey(nameof(BookId))]
        [InverseProperty(nameof(Groups.Book))]
        public virtual ICollection<Groups> Group { get; set; }
    }
}
