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
        private IUserRepository _repo;

        private IUserRepository Repo
        {
            get { return _repo ?? (_repo = new UserRepository()); }
            set { _repo = value; }
        }


        public IProfile GetProfileById(string id)
        {
            return Repo.GetById(id);
        }
    }
}
