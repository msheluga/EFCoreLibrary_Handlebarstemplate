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
            BooksInGroups = new HashSet<BooksInGroups>();
            UsersInGroup = new HashSet<UsersInGroup>();
        }

        [Key]
        [Authorize(Policy="Groups.Id_policy")]
            public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        [Authorize(Policy="Groups.GroupName_policy")]
            public string GroupName { get; set; }

    [InverseProperty("Group")]
        public virtual ICollection<BooksInGroups>
    BooksInGroups { get; set; }
    [InverseProperty("Group")]
        public virtual ICollection<UsersInGroup>
    UsersInGroup { get; set; }
    }
}
