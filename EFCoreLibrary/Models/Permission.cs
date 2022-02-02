using System;
using System.Collections.Generic;
using HotChocolate.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLibrary.Models
{
    public partial class Permission
    {
        [Key]
        [Authorize(Policy="Permission.Id_policy")]
            public Guid Id { get; set; }
        [Authorize(Policy="Permission.UserId_policy")]
            public Guid UserId { get; set; }
        [Required]
        [Authorize(Policy="Permission.TableName_policy")]
            public string TableName { get; set; }
        [Authorize(Policy="Permission.TableAccessLevel_policy")]
            public short TableAccessLevel { get; set; }
        [Required]
        [Authorize(Policy="Permission.FieldName_policy")]
            public string FieldName { get; set; }
        [Authorize(Policy="Permission.FieldAccessLevel_policy")]
            public short FieldAccessLevel { get; set; }
        [Authorize(Policy="Permission.FieldDataType_policy")]
            public string FieldDataType { get; set; }
        [Authorize(Policy="Permission.FieldProperties_policy")]
            public string FieldProperties { get; set; }
        [Authorize(Policy="Permission.FieldOrder_policy")]
            public int? FieldOrder { get; set; }
    }
}
