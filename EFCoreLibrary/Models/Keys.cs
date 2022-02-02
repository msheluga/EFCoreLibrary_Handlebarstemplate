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
        [Authorize(Policy="Id_policy")]
        public string Id { get; set; }
        [Authorize(Policy="Version_policy")]
        public int Version { get; set; }
        [Authorize(Policy="Created_policy")]
        public DateTime Created { get; set; }
        [Authorize(Policy="Use_policy")]
        public string Use { get; set; }
        [Required]        
        [StringLength(100)]        
        [Authorize(Policy="Algorithm_policy")]
        public string Algorithm { get; set; }
        [Column("IsX509Certificate")]        
        [Authorize(Policy="IsX509certificate_policy")]
        public bool IsX509certificate { get; set; }
        [Authorize(Policy="DataProtected_policy")]
        public bool DataProtected { get; set; }
        [Required]        
        [Authorize(Policy="Data_policy")]
        public string Data { get; set; }
    }
}
