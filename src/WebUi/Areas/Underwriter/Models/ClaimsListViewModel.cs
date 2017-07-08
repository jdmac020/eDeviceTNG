using System;
using System.Collections.Generic;
using EDeviceClaims.Core;
using EDeviceClaims.Domain.Models;

namespace EDeviceClaims.WebUi.Areas.Underwriter.Models
{
    public class ClaimsListViewModel : List<UnderwriterClaimViewModel>
    {
        public ClaimsListViewModel(List<ClaimDomainModel> claims)
        {
            foreach (var claim in claims)
            {
                Add(new UnderwriterClaimViewModel(claim));
            }
        }
    }

    public class UnderwriterClaimViewModel
    {
        public string Status { get; set; }

        public string Start { get; set; }

        public string Name { get; set; }

        public Guid PolicyId { get; set; }

        public Guid Id { get; set; }

        public UnderwriterClaimViewModel(ClaimDomainModel claim)
        {
            Id = claim.Id;
            PolicyId = claim.Policy.Id;
            Name = claim.Policy.DeviceName;
            Start = $"{claim.WhenStarted.ToShortDateString()} {claim.WhenStarted.ToShortTimeString()}";
            Status = claim.Status.ToString();
        }
        
    }
}