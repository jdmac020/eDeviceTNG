using System;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories;

namespace EDeviceClaims.Interactors
{
    public interface IUpdateClaimInteractor
    {
        ClaimEntity UpdateStatus(ClaimEntity claim, StatusEntity status);
    }
    public class UpdateClaimInteractor : IUpdateClaimInteractor
    {
        public UpdateClaimInteractor()
        {
            
        }

        public UpdateClaimInteractor(IClaimRepository claimRepository, IStatusRepository statusRepository)
        {
            _claimRepo = claimRepository;
            _statusRepo = statusRepository;
        }

        private IClaimRepository _claimRepo;

        private IClaimRepository ClaimRepo
        {
            get { return _claimRepo ?? (_claimRepo = new ClaimRepository()); }
            set { _claimRepo = value; }
        }

        private IStatusRepository _statusRepo;

        private IStatusRepository StatusRepo
        {
            get { return _statusRepo ?? (_statusRepo = new StatusRepository()); }
            set { _statusRepo = value; }
        }

        public ClaimEntity UpdateStatus(ClaimEntity claim, StatusEntity status)
        {

            claim.Status = status;
            claim.StatusId = status.Id;
            claim.StatusName = status.Name;
            claim.WhenLastModified = DateTime.Now;

            ClaimRepo.Update(claim);

            return claim;
        }
    }
}