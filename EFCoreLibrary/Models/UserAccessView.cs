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
        [Authorize(Policy="UserId_policy")]
        public Guid UserId { get; set; }
        [Required]        
        [StringLength(255)]        
        [Authorize(Policy="UserName_policy")]
        public string UserName { get; set; }
        [Required]        
        [Authorize(Policy="TableName_policy")]
        public string TableName { get; set; }
        [Authorize(Policy="TableAccessLevel_policy")]
        public int TableAccessLevel { get; set; }
        [Required]        
        [Authorize(Policy="FieldName_policy")]
        public string FieldName { get; set; }
        [Authorize(Policy="FieldLevelAccess_policy")]
        public int FieldLevelAccess { get; set; }
        [Required]        
        [Authorize(Policy="FieldDataType_policy")]
        public string FieldDataType { get; set; }
        [Authorize(Policy="FieldProperties_policy")]
        public string FieldProperties { get; set; }
        [Column("fieldOrder")]        
        [Authorize(Policy="FieldOrder_policy")]
        public int FieldOrder { get; set; }
        [Required]        
        [Authorize(Policy="ControllerName_policy")]
        public string ControllerName { get; set; }
    }
}
