using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Domain.Models
{
    public class StatusDomainModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public StatusDomainModel(StatusEntity status)
        {
            Id = status.Id;
            Name = status.Name;
        }
    }
}
