using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Core;

namespace EDeviceClaims.Domain.Models
{
    public class ProfileDomainModel
    {
        public ProfileDomainModel(IProfile user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.UserName;
        }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}
