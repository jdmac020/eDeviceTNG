using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.Interactors;

namespace EDeviceClaims.Domain.Services
{

    public interface IClaimService
    {
        ClaimDomainModel StartClaim(Guid policyId); //This is just Id in the video... // I like knowing whether I'm passing a policy or user or claim ID at a glance
        ClaimDomainModel ViewClaim(Guid policyId); //This too
        ClaimDomainModel GetById(Guid id);

        List<ClaimDomainModel> GetAllOpen();
    }

    public class ClaimService : IClaimService
    {
        private IGetPolicyInteractor _getPolicyInteractor;

        private IGetPolicyInteractor GetPolicyInteractor
        {
            get { return _getPolicyInteractor ?? (_getPolicyInteractor = new GetPolicyInteractor()); }
            set { _getPolicyInteractor = value; }
        }

        private IGetClaimInteractor _getClaimInteractor;

        private IGetClaimInteractor GetClaimInteractor
        {
            get { return _getClaimInteractor ?? (_getClaimInteractor = new GetClaimInteractor()); } //Video 4b 18:00, named wrong //named correctly--we need both a CreateClaim and a GetClaim interactor in this class. in the video the getpolicy and getclaim interactors are collapsed and you only see the CreateClaim one, which was missing before I added it. 
            set { _getClaimInteractor = value; }
        }

        // This entire interactor was missing--the part that triggers the entire thing. The UI layer was reaching into the service and never triggering the rest of the process, because there was no CreateClaimInteractor wired up

        private ICreateClaimInteractor _createClaimInteractor;

        private ICreateClaimInteractor CreateClaimInteractor
        {
            get { return _createClaimInteractor ?? (_createClaimInteractor = new CreateClaimInteractor()); } 
            set { _createClaimInteractor = value; }
        }

        // did a total overhaul on this, I don't think it matches the video
        public ClaimDomainModel StartClaim(Guid policyId)
        {
            var policy = GetPolicyInteractor.GetById(policyId);

            if (policy == null) throw new ArgumentException("There is no policy for that ID.");

            // Check for existing claim
            var existingClaimEntity = GetClaimInteractor.Execute(policyId);

            // if there's an existing claim, return it. If not, create one.
            if (existingClaimEntity != null)
            {
                return new ClaimDomainModel(existingClaimEntity);
            }
            else
            {
                var newClaimEntity = CreateClaimInteractor.Excute(policyId);
                return new ClaimDomainModel(newClaimEntity);
            }
            
        }

        public ClaimDomainModel ViewClaim(Guid policyId)
        {
            var policy = GetPolicyInteractor.GetById(policyId);

            if (policy == null) throw new ArgumentException("There is no policy for that ID.");

            var existingClaim = GetClaimInteractor.Execute(policyId);

            // returns new claim model regardless
            // will eventually need to return existing claim data or error handle
            return new ClaimDomainModel(existingClaim);
        }

        public ClaimDomainModel GetById(Guid id)
        {
            var claim = GetClaimInteractor.Execute(id);
            if(claim == null) throw new ArgumentException("Claim does not exist");

            return new ClaimDomainModel(claim);
        }

        public List<ClaimDomainModel> GetAllOpen()
        {
            var openClaims = _getClaimInteractor.GetAllOpen();

            // LINQ does this "foreach" action
            return openClaims
                .Select(claim => new ClaimDomainModel(claim))
                .ToList();
        }
    }
}
