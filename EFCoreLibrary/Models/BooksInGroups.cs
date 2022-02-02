using System;
using System.Collections.Generic;
using HotChocolate.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLibrary.Models
{
    public partial class BooksInGroups
    {
        [Key]
        [Authorize(Policy="BooksInGroups.BookId_policy")]
            public Guid BookId { get; set; }
        [Key]
        [Authorize(Policy="BooksInGroups.GroupId_policy")]
            public Guid GroupId { get; set; }

    [ForeignKey(nameof(BookId))]
    [InverseProperty("BooksInGroups")]
    public virtual Book Book { get; set; }
    [ForeignKey(nameof(GroupId))]
    [InverseProperty(nameof(Groups.BooksInGroups))]
    public virtual Groups Group { get; set; }
    }
}
