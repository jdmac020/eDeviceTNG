using System;
using System.Collections.Generic;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories;

namespace EDeviceClaimSystem.Interactors.Tests.Mocks
{
    public class MirrorPolicyRepository : EfRepository<Policy, Guid>, IPolicyRepository
    {
        public List<ClaimEntity> GetAllOpen()
        {
            throw new NotImplementedException();
        }

        public new Policy Create(Policy policy)
        {
            return new Policy
            {
                Id = policy.Id
            };
        }

        public new void Update(Policy policy)
        {

        }

        public new Policy GetById(Guid id)
        {
            if(id != Guid.Empty)
                return new Policy { Id = id };

            return null;
        }

        public Policy GetByPolicyNumber(string number)
        {
            throw new NotImplementedException();
        }

        public ICollection<Policy> GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Policy> GetByEmailAddress(string email)
        {
            throw new NotImplementedException();
        }

        public void SavePolicyChanges()
        {
            throw new NotImplementedException();
        }
    }
}
