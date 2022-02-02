using System;
using System.Collections.Generic;
using HotChocolate.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLibrary.Models
{
    [Keyless]
    public partial class UserAccessView
    {
        [Authorize(Policy="UserAccessView.UserId_policy")]
            public Guid UserId { get; set; }
        [Required]
        [StringLength(255)]
        [Authorize(Policy="UserAccessView.UserName_policy")]
            public string UserName { get; set; }
        [Required]
        [Authorize(Policy="UserAccessView.TableName_policy")]
            public string TableName { get; set; }
        [Authorize(Policy="UserAccessView.TableAccessLevel_policy")]
            public int TableAccessLevel { get; set; }
        [Required]
        [Authorize(Policy="UserAccessView.FieldName_policy")]
            public string FieldName { get; set; }
        [Authorize(Policy="UserAccessView.FieldLevelAccess_policy")]
            public int FieldLevelAccess { get; set; }
        [Required]
        [Authorize(Policy="UserAccessView.FieldDataType_policy")]
            public string FieldDataType { get; set; }
        [Authorize(Policy="UserAccessView.FieldProperties_policy")]
            public string FieldProperties { get; set; }
        [Column("fieldOrder")]
        [Authorize(Policy="UserAccessView.FieldOrder_policy")]
            public int FieldOrder { get; set; }
        [Required]
        [Authorize(Policy="UserAccessView.ControllerName_policy")]
            public string ControllerName { get; set; }
    }
}
