using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Repositories
{
    public interface IPolicyRepository : IEfRepository<Policy, Guid>
    {
        Policy GetByPolicyNumber(string number);
        ICollection<Policy> GetByUserId(string userId);
        ICollection<Policy> GetByEmailAddress(string email);
        void SavePolicyChanges();
    }

    public class PolicyRepository : EfRepository<Policy, Guid>, IPolicyRepository
    {
        public PolicyRepository() : base(new EDeviceClaimsUnitOfWork())
        {
        }

        public PolicyRepository(IEfUnitOfWork unitOfWork) : base(unitOfWork) { }

        public Policy GetByPolicyNumber(string number)
        {
            return ObjectSet
              .FirstOrDefault(p => p.Number.ToLower() == number.ToLower());
        }

        public ICollection<Policy> GetByUserId(string userId)
        {
            return ObjectSet.Where(p => p.UserId == userId)
                                    .Include( c => c.Claims)
                                    .ToList();
        }

        public ICollection<Policy> GetByEmailAddress(string email)
        {
            return ObjectSet.Where(p => p.CustomerEmail == email).ToList();
        }

        public void SavePolicyChanges()
        {
            EfUnitOfWork.Context.SaveChanges();
        }
    }
}