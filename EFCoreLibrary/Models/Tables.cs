using System;
using System.Collections.Generic;
using HotChocolate.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLibrary.Models
{
    public partial class Tables
    {
        public Tables()
        {
            Fields = new HashSet<Fields>();
            UserTableAccess = new HashSet<UserTableAccess>();
        }

        [Key]        
        [Authorize(Policy="Id_policy")]
        public Guid Id { get; set; }
        [Required]        
        [Authorize(Policy="TableName_policy")]
        public string TableName { get; set; }
        [Required]        
        [Authorize(Policy="ControllerName_policy")]
        public string ControllerName { get; set; }

        [InverseProperty("Table")]
        public virtual ICollection<Fields> Fields { get; set; }
        [InverseProperty("Table")]
        public virtual ICollection<UserTableAccess> UserTableAccess { get; set; }
    }
}
