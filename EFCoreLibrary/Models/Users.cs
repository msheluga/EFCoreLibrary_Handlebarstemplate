using System;
using System.Collections.Generic;
using HotChocolate.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLibrary.Models
{
    public partial class Users
    {
        public Users()
        {
            UserFieldAccess = new HashSet<UserFieldAccess>();
            UserTableAccess = new HashSet<UserTableAccess>();
            Group = new HashSet<Groups>();
        }

        [Key]        
        [Authorize(Policy="Id_policy")]
        public Guid Id { get; set; }
        [Required]        
        [StringLength(255)]        
        [Authorize(Policy="UserName_policy")]
        public string UserName { get; set; }
        [Column(TypeName = "datetime")]        
        [Authorize(Policy="LastLogin_policy")]
        public DateTime? LastLogin { get; set; }
        [Column("status")]        
        [Authorize(Policy="Status_policy")]
        public int? Status { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<UserFieldAccess> UserFieldAccess { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserTableAccess> UserTableAccess { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Groups.User))]
        public virtual ICollection<Groups> Group { get; set; }
    }
}
