using System;
using EDeviceClaims.Domain.Models;

namespace EDeviceClaims.WebUi.Models
{
    public class ClaimStatusViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ClaimStatusViewModel(StatusDomainModel status)
        {
            Id = status.Id;
            Name = status.Name;
        }
    }
}