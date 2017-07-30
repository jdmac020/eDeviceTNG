using System;
using EDeviceClaims.Core;

namespace EDeviceClaims.Entities
{
    public class StatusEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
    }

}

