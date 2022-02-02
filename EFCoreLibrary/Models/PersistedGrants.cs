using System;
using System.Collections.Generic;
using HotChocolate.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLibrary.Models
{
    [Index(nameof(ConsumedTime), Name = "IX_PersistedGrants_ConsumedTime")]
    [Index(nameof(Expiration), Name = "IX_PersistedGrants_Expiration")]
    [Index(nameof(SubjectId), nameof(ClientId), nameof(Type), Name = "IX_PersistedGrants_SubjectId_ClientId_Type")]
    [Index(nameof(SubjectId), nameof(SessionId), nameof(Type), Name = "IX_PersistedGrants_SubjectId_SessionId_Type")]
    public partial class PersistedGrants
    {
        [Key]
        [StringLength(200)]
        [Authorize(Policy="PersistedGrants.Key_policy")]
            public string Key { get; set; }
        [Required]
        [StringLength(50)]
        [Authorize(Policy="PersistedGrants.Type_policy")]
            public string Type { get; set; }
        [StringLength(200)]
        [Authorize(Policy="PersistedGrants.SubjectId_policy")]
            public string SubjectId { get; set; }
        [StringLength(100)]
        [Authorize(Policy="PersistedGrants.SessionId_policy")]
            public string SessionId { get; set; }
        [Required]
        [StringLength(200)]
        [Authorize(Policy="PersistedGrants.ClientId_policy")]
            public string ClientId { get; set; }
        [StringLength(200)]
        [Authorize(Policy="PersistedGrants.Description_policy")]
            public string Description { get; set; }
        [Authorize(Policy="PersistedGrants.CreationTime_policy")]
            public DateTime CreationTime { get; set; }
        [Authorize(Policy="PersistedGrants.Expiration_policy")]
            public DateTime? Expiration { get; set; }
        [Authorize(Policy="PersistedGrants.ConsumedTime_policy")]
            public DateTime? ConsumedTime { get; set; }
        [Required]
        [Authorize(Policy="PersistedGrants.Data_policy")]
            public string Data { get; set; }
    }
}
