using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Domain.Models
{
    public class PolicyDomainModel
    {
        public Guid Id { get; set; }

        public string Number { get; set; }

        public string DeviceName { get; set; }

        public string SerialNumber { get; set; }

        public PolicyDomainModel(Policy policyEntity)
        {
            if (policyEntity == null) return;

            Id = policyEntity.Id;
            Number = policyEntity.Number;
            SerialNumber = policyEntity.SerialNumber;
            DeviceName = policyEntity.DeviceName;
        }
    }


    public class PolicyWithClaimsDomainModel : PolicyDomainModel
    {
        public List<ClaimDomainModel> Claims { get; set; }

        public PolicyWithClaimsDomainModel(Policy policyEntity) : base(policyEntity)
        {
            LoadClaims(policyEntity.Claims);
        }

        private void LoadClaims(IReadOnlyCollection<ClaimEntity> claims)
        {
            Claims = new List<ClaimDomainModel>();

            if (claims == null) return;

            foreach (var claim in claims)
            {
                Claims.Add(new ClaimDomainModel(claim));
            }
        }
        
    }
}
