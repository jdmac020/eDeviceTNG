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
        private IGetProfileInteractor _getProfileInteractor;

        private IGetProfileInteractor GetProfileInteractor
        {
            get { return _getProfileInteractor ?? (_getProfileInteractor = new GetProfileInteractor()); }
            set { _getProfileInteractor = value; }
        } 

        public ProfileDomainModel GetProfileById(string id)
        {
            var user = GetProfileInteractor.GetProfileById(id);

            return new ProfileDomainModel(user);
        }
    }
}
