using System;
using System.Collections.Generic;
using HotChocolate.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLibrary.Models
{
    public partial class Fields
    {
        public Fields()
        {
            UserFieldAccess = new HashSet<UserFieldAccess>();
        }

        [Key]
        [Authorize(Policy="Fields.Id_policy")]
            public Guid Id { get; set; }
        [Authorize(Policy="Fields.TableId_policy")]
            public Guid TableId { get; set; }
        [Required]
        [Authorize(Policy="Fields.FieldName_policy")]
            public string FieldName { get; set; }
        [Required]
        [Authorize(Policy="Fields.FieldDataType_policy")]
            public string FieldDataType { get; set; }
        [Authorize(Policy="Fields.FieldProperties_policy")]
            public string FieldProperties { get; set; }
        [Column("fieldOrder")]
        [Authorize(Policy="Fields.FieldOrder_policy")]
            public int FieldOrder { get; set; }

    [ForeignKey(nameof(TableId))]
    [InverseProperty(nameof(Tables.Fields))]
    public virtual Tables Table { get; set; }
    [InverseProperty("Field")]
        public virtual ICollection<UserFieldAccess>
    UserFieldAccess { get; set; }
    }
}
