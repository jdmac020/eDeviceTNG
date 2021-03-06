﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Core;

namespace EDeviceClaims.Entities
{
    [Table("claims", Schema = "app")]
    public class ClaimEntity : EntityBase<Guid>
    {
        public Guid PolicyId { get; set; }
        public virtual Policy Policy { get; set; }
        public Guid StatusId { get; set; }
        public string StatusName { get; set; }
        public virtual StatusEntity Status { get; set; }
    }
}
