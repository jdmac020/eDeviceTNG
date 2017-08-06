using System;
using EDeviceClaims.Core;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Domain.Models
{
    public class ClaimDomainModel
    {
        public Guid Id { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public DateTime WhenStarted { get; set; }
        public PolicyDomainModel Policy { get; set; }
        public StatusDomainModel Status { get; set; }
        public DateTime? WhenLastModified { get; set; }

        public ClaimDomainModel(ClaimEntity claim)
        {
            Id = claim.Id;
            WhenStarted = claim.WhenCreated;
            WhenLastModified = claim.WhenLastModified;
            Policy = new PolicyDomainModel(claim.Policy);
            Status = new StatusDomainModel(claim.Status);
        }
    }
}