﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Core;
using EDeviceClaims.Entities;


namespace EDeviceClaims.Repositories
{
    public interface IClaimRepository : IEfRepository<ClaimEntity, Guid>
    {
        new ClaimEntity GetById(Guid id);
        List<ClaimEntity> GetAllOpen();
    }

    public class ClaimRepository : EfRepository<ClaimEntity, Guid>, IClaimRepository
    {
        public ClaimRepository() : base(new EDeviceClaimsUnitOfWork())
        {
        }

        public ClaimRepository(IEfUnitOfWork unitOfWork) : base(unitOfWork) { }

        public new ClaimEntity GetById(Guid id)
        {
            return ObjectSet.Where(c => c.Id == id)
                .Include(c => c.Policy)
                .FirstOrDefault();
        }

        public List<ClaimEntity> GetAllOpen()
        {
            return ObjectSet.Where(c => c.Status.Name != "Approved" && c.Status.Name != "Denied")
                .Include(c => c.Policy)
                .ToList();
        }

        public new void Update(ClaimEntity claim)
        {
            EfUnitOfWork.Context.Entry(claim.Status).State = EntityState.Detached;
            ObjectSet.AddOrUpdate(claim);
            EfUnitOfWork.Commit();

            //ObjectSet.AddOrUpdate(claim);
            //EfUnitOfWork.Commit();
        }
    }
}
