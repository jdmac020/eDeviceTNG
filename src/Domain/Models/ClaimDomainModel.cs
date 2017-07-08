using System;
using EDeviceClaims.Core;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Domain.Models
{
    public class ClaimDomainModel
    {
        public Guid Id { get; set; }
        public DateTime WhenStarted { get; set; }
        public PolicyDomainModel Policy { get; set; }
        public ClaimStatus Status { get; set; }

        public ClaimDomainModel(ClaimEntity claim)
        {
            Id = claim.Id;
            WhenStarted = claim.WhenCreated;
            Policy = new PolicyDomainModel(claim.Policy);
            Status = claim.Status;
        }
    }
}