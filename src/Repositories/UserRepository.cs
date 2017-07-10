using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Core;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Repositories
{

    public interface IUserRepository : IEfRepository<AuthorizedUser,string>
    {
        
    }
   public class UserRepository : EfRepository<AuthorizedUser, string> , IUserRepository
    {
        public UserRepository() : base(new EDeviceClaimsUnitOfWork())
        {
            
        }

        public UserRepository(IEfUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
    }
}
