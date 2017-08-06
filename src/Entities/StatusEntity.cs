using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EDeviceClaims.Core;

namespace EDeviceClaims.Entities
{
    [Table("statuses", Schema = "app")]
    public class StatusEntity : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        
    }

}

