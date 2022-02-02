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
        [Authorize(Policy="Id_policy")]
        public Guid Id { get; set; }
        [Authorize(Policy="UserId_policy")]
        public Guid UserId { get; set; }
        [Required]        
        [Authorize(Policy="TableName_policy")]
        public string TableName { get; set; }
        [Authorize(Policy="TableAccessLevel_policy")]
        public short TableAccessLevel { get; set; }
        [Required]        
        [Authorize(Policy="FieldName_policy")]
        public string FieldName { get; set; }
        [Authorize(Policy="FieldAccessLevel_policy")]
        public short FieldAccessLevel { get; set; }
        [Authorize(Policy="FieldDataType_policy")]
        public string FieldDataType { get; set; }
        [Authorize(Policy="FieldProperties_policy")]
        public string FieldProperties { get; set; }
        [Authorize(Policy="FieldOrder_policy")]
        public int? FieldOrder { get; set; }
    }
}
