using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaimSystem.Interactors.Tests.Mocks;

namespace EDeviceClaimSystem.Interactors.Tests.Factories
{
    public static class RespositoryFactoriesClass
    {
        public static MirrorClaimRepository CreateMirrorClaimRepo()
        {
            return new MirrorClaimRepository();
        }

        public static ListClaimRepository CreateListClaimRepo()
        {
            return new ListClaimRepository();
        }

        public static MirrorStatusRepository CreateMirrorStatusRepo()
        {
            return new MirrorStatusRepository();
        }
    }
}
