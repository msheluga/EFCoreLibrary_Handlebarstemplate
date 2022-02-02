using System;
using System.Collections.Generic;
using HotChocolate.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLibrary.Models
{
    public partial class UserTableAccess
    {
        [Key]
        [Authorize(Policy="UserTableAccess.Id_policy")]
            public Guid Id { get; set; }
        [Authorize(Policy="UserTableAccess.UserId_policy")]
            public Guid UserId { get; set; }
        [Authorize(Policy="UserTableAccess.TableId_policy")]
            public Guid TableId { get; set; }
        [Authorize(Policy="UserTableAccess.TableAccessLevel_policy")]
            public int TableAccessLevel { get; set; }

    [ForeignKey(nameof(TableId))]
    [InverseProperty(nameof(Tables.UserTableAccess))]
    public virtual Tables Table { get; set; }
    [ForeignKey(nameof(UserId))]
    [InverseProperty(nameof(Users.UserTableAccess))]
    public virtual Users User { get; set; }
    }
}
