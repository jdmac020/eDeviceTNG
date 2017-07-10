using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Core;
using EDeviceClaims.Repositories;

namespace EDeviceClaims.Interactors
{
    public interface IGetProfileInteractor
    {
        IProfile GetProfileById(string id);
    }
    public class GetProfileInteractor : IGetProfileInteractor
    {
        private IProfileRepository _repo;

        private IProfileRepository Repo
        {
            get { return _repo ?? (_repo = new ProfileRepository()); }
            set { _repo = value; }
        }


        public IProfile GetProfileById(string id)
        {
            return Repo.GetById(id);
        }
    }
}
