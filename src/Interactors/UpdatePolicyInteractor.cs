using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories;


namespace EDeviceClaims.Interactors
{
    public interface IUpdatePolicyInteractor
    {
        void UpdatePolicyUserId(AuthorizedUser user, ICollection<Policy> devices);
    }

    public class UpdatePolicyInteractor : IUpdatePolicyInteractor
    {
        private IPolicyRepository _repo;

        private IPolicyRepository Repo
        {
            get { return _repo ?? (_repo = new PolicyRepository()); }
            set { _repo = value; }
        }
        
        public UpdatePolicyInteractor() { }

        public void UpdatePolicyUserId(AuthorizedUser user, ICollection<Policy> devices)
        {

            foreach (var device in devices)
            {
                device.UserId = user.Id;
                Repo.Update(device);
            }
            
        }
        
    }
}
