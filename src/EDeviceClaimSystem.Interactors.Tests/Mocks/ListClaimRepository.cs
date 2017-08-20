using System;
using System.Collections.Generic;
using System.Linq;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories;

namespace EDeviceClaimSystem.Interactors.Tests.Mocks
{
    public class ListClaimRepository : EfRepository<ClaimEntity, Guid>, IClaimRepository
    {
        private List<ClaimEntity> _claims = new List<ClaimEntity>();
        
        public List<ClaimEntity> GetAllOpen()
        {
            return _claims.Where(c => c.StatusName == "Open").ToList();
        }

        public new void Create(ClaimEntity claim)
        {
            _claims.Add(new ClaimEntity {Id = claim.Id, PolicyId = claim.PolicyId, StatusId = claim.StatusId, StatusName = claim.StatusName});
        }

        public new void Update(ClaimEntity claim)
        {
            var storedClaim = _claims.Find(c => c.Id == claim.Id);
            storedClaim.StatusId = claim.StatusId;
            storedClaim.PolicyId = claim.PolicyId;
        }

        public new ClaimEntity GetById(Guid id)
        {
            return _claims.Find(c => c.Id == id);
        }
    }
}
