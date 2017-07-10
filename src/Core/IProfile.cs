using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDeviceClaims.Core
{
    public interface IProfile
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
    }
}
