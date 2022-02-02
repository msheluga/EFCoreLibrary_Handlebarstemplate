using System;
using System.Collections.Generic;
using HotChocolate.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLibrary.Models
{
    [Index(nameof(DeviceCode), Name = "IX_DeviceCodes_DeviceCode", IsUnique = true)]
    [Index(nameof(Expiration), Name = "IX_DeviceCodes_Expiration")]
    public partial class DeviceCodes
    {
        [Key]
        [StringLength(200)]
        [Authorize(Policy="DeviceCodes.UserCode_policy")]
            public string UserCode { get; set; }
        [Required]
        [StringLength(200)]
        [Authorize(Policy="DeviceCodes.DeviceCode_policy")]
            public string DeviceCode { get; set; }
        [StringLength(200)]
        [Authorize(Policy="DeviceCodes.SubjectId_policy")]
            public string SubjectId { get; set; }
        [StringLength(100)]
        [Authorize(Policy="DeviceCodes.SessionId_policy")]
            public string SessionId { get; set; }
        [Required]
        [StringLength(200)]
        [Authorize(Policy="DeviceCodes.ClientId_policy")]
            public string ClientId { get; set; }
        [StringLength(200)]
        [Authorize(Policy="DeviceCodes.Description_policy")]
            public string Description { get; set; }
        [Authorize(Policy="DeviceCodes.CreationTime_policy")]
            public DateTime CreationTime { get; set; }
        [Authorize(Policy="DeviceCodes.Expiration_policy")]
            public DateTime Expiration { get; set; }
        [Required]
        [Authorize(Policy="DeviceCodes.Data_policy")]
            public string Data { get; set; }
        [Required]
        [Column("Intentional_Long_Name")]
        [Authorize(Policy="DeviceCodes.IntentionalLongName_policy")]
            public string IntentionalLongName { get; set; }
    }
}
