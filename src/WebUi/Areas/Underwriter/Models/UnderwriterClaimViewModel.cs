using System;
using EDeviceClaims.Domain.Models;

namespace EDeviceClaims.WebUi.Areas.Underwriter.Models
{
    public class UnderwriterClaimViewModel
    {
        public string Status { get; set; }

        public string Start { get; set; }

        public string DeviceName { get; set; }
        public string CustomerName { get; set; }

        public Guid PolicyId { get; set; }

        public Guid Id { get; set; }

        public UnderwriterClaimViewModel(ClaimDomainModel claim)
        {
            Id = claim.Id;
            PolicyId = claim.Policy.Id;
            DeviceName = claim.Policy.DeviceName;
            CustomerName = $"{claim.CustomerFirstName} {claim.CustomerLastName}";
            Start = $"{claim.WhenStarted.ToShortDateString()} {claim.WhenStarted.ToShortTimeString()}";
            Status = claim.Status.ToString();
        }
        
    }
}