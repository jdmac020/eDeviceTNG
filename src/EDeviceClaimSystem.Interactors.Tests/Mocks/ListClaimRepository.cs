using System;
using System.Collections.Generic;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories;

namespace EDeviceClaimSystem.Interactors.Tests.Mocks
{
    public class ListClaimRepository : EfRepository<ClaimEntity, Guid>, IClaimRepository
    {
        private List<ClaimEntity> _claims = new List<ClaimEntity>();
        
        public List<ClaimEntity> GetAllOpen()
        {
            
            return _claims;
        }

        public new void Create(ClaimEntity claim)
        {
            _claims.Add(new ClaimEntity {Id = claim.Id, PolicyId = claim.PolicyId, StatusId = claim.StatusId});
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
