using System;
using System.Collections.Generic;
using HotChocolate.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLibrary.Models
{
    [Index(nameof(Use), Name = "IX_Keys_Use")]
    public partial class Keys
    {
        [Key]
        [Authorize(Policy="Keys.Id_policy")]
            public string Id { get; set; }
        [Authorize(Policy="Keys.Version_policy")]
            public int Version { get; set; }
        [Authorize(Policy="Keys.Created_policy")]
            public DateTime Created { get; set; }
        [Authorize(Policy="Keys.Use_policy")]
            public string Use { get; set; }
        [Required]
        [StringLength(100)]
        [Authorize(Policy="Keys.Algorithm_policy")]
            public string Algorithm { get; set; }
        [Column("IsX509Certificate")]
        [Authorize(Policy="Keys.IsX509certificate_policy")]
            public bool IsX509certificate { get; set; }
        [Authorize(Policy="Keys.DataProtected_policy")]
            public bool DataProtected { get; set; }
        [Required]
        [Authorize(Policy="Keys.Data_policy")]
            public string Data { get; set; }
    }
}
