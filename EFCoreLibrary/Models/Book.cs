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
            BooksInGroups = new HashSet<BooksInGroups>();
        }

        [Key]
        [Authorize(Policy="Book.Id_policy")]
            public Guid Id { get; set; }
        [Required]
        [Column("ISBN")]
        [StringLength(30)]
        [Authorize(Policy="Book.Isbn_policy")]
            public string Isbn { get; set; }
        [Required]
        [StringLength(50)]
        [Authorize(Policy="Book.Title_policy")]
            public string Title { get; set; }
        [Required]
        [StringLength(50)]
        [Authorize(Policy="Book.Author_policy")]
            public string Author { get; set; }
        [Column(TypeName = "money")]
        [Authorize(Policy="Book.Price_policy")]
            public decimal Price { get; set; }
        [Authorize(Policy="Book.AddressId_policy")]
            public Guid AddressId { get; set; }
        [Authorize(Policy="Book.PressId_policy")]
            public Guid PressId { get; set; }

    [ForeignKey(nameof(AddressId))]
    [InverseProperty("Book")]
    public virtual Address Address { get; set; }
    [ForeignKey(nameof(PressId))]
    [InverseProperty("Book")]
    public virtual Press Press { get; set; }
    [InverseProperty("Book")]
        public virtual ICollection<BooksInGroups>
    BooksInGroups { get; set; }
    }
}
