using System;
using System.Collections.Generic;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories;

namespace EDeviceClaimSystem.Interactors.Tests.Mocks
{
    public class MirrorClaimRepository : EfRepository<ClaimEntity, Guid>, IClaimRepository
    {
        public List<ClaimEntity> GetAllOpen()
        {
            throw new NotImplementedException();
        }

        public new ClaimEntity Create(ClaimEntity claim)
        {
            return new ClaimEntity { Id = claim.Id, PolicyId = claim.PolicyId, StatusId = claim.StatusId };
        }

        public new void Update(ClaimEntity claim)
        {
            
        }

        public new ClaimEntity GetById(Guid id)
        {
            return new ClaimEntity {Id = id};
        }
    }
}
