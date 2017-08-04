using System;
using EDeviceClaims.Repositories;

namespace EDeviceClaims.Interactors
{
    public interface IUpdateClaimInteractor
    {
        void UpdateStatus(Guid claimId, Guid statusId);
    }
    public class UpdateClaimInteractor : IUpdateClaimInteractor
    {
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

        public void UpdateStatus(Guid claimId, Guid statusId)
        {
            var claim = ClaimRepo.GetById(claimId);
            var newStatus = StatusRepo.GetById(statusId);

            claim.Status = newStatus;

            ClaimRepo.Update(claim);
        }
    }
}