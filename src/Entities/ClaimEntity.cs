﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Core;

namespace EDeviceClaims.Entities
{
    // may need to up cap App
    [Table("claims", Schema = "app")]
    public class ClaimEntity : EntityBase<Guid>
    {
        public Guid PolicyId { get; set; }
        public virtual Policy Policy { get; set; }
        public ClaimStatus Status { get; set; }
    }
}
