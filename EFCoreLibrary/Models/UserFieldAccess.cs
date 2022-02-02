using System;
using System.Collections.Generic;
using HotChocolate.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLibrary.Models
{
    public partial class UserFieldAccess
    {
        [Key]
        [Authorize(Policy="UserFieldAccess.Id_policy")]
            public Guid Id { get; set; }
        [Authorize(Policy="UserFieldAccess.UserId_policy")]
            public Guid UserId { get; set; }
        [Authorize(Policy="UserFieldAccess.FieldId_policy")]
            public Guid FieldId { get; set; }
        [Authorize(Policy="UserFieldAccess.FieldLevelAccess_policy")]
            public int FieldLevelAccess { get; set; }

    [ForeignKey(nameof(FieldId))]
    [InverseProperty(nameof(Fields.UserFieldAccess))]
    public virtual Fields Field { get; set; }
    [ForeignKey(nameof(UserId))]
    [InverseProperty(nameof(Users.UserFieldAccess))]
    public virtual Users User { get; set; }
    }
}
