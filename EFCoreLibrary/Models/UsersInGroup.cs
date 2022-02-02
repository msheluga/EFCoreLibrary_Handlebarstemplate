using System;
using System.Collections.Generic;
using HotChocolate.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLibrary.Models
{
    public partial class UsersInGroup
    {
        [Key]
        [Authorize(Policy="UsersInGroup.UserId_policy")]
            public Guid UserId { get; set; }
        [Key]
        [Authorize(Policy="UsersInGroup.GroupId_policy")]
            public Guid GroupId { get; set; }

    [ForeignKey(nameof(GroupId))]
    [InverseProperty(nameof(Groups.UsersInGroup))]
    public virtual Groups Group { get; set; }
    [ForeignKey(nameof(UserId))]
    [InverseProperty(nameof(Users.UsersInGroup))]
    public virtual Users User { get; set; }
    }
}
