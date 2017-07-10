using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.Interactors;

namespace EDeviceClaims.Domain.Services
{
    public interface IProfileService
    {
        ProfileDomainModel GetProfileById(string id);
    }

    public class ProfileService : IProfileService
    {
        private IGetUserInteractor _getUserInteractor;

        private IGetUserInteractor GetUserInteractor
        {
            get { return _getUserInteractor ?? (_getUserInteractor = new GetUserInteractor()); }
            set { _getUserInteractor = value; }
        } 

        public ProfileDomainModel GetProfileById(string id)
        {
            var user = GetUserInteractor.GetById(id);

            return new ProfileDomainModel(user);
        }
    }
}
