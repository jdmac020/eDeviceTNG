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
}