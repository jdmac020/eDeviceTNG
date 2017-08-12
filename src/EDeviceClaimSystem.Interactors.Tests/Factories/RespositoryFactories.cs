using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaimSystem.Interactors.Tests.Mocks;

namespace EDeviceClaimSystem.Interactors.Tests.Factories
{
    public static class RespositoryFactories
    {
        public static MirrorClaimRepository MirrorClaimRepoFactory()
        {
            return new MirrorClaimRepository();
        }

        public static ListClaimRepository ListClaimRepoFactory()
        {
            return new ListClaimRepository();
        }

        public static MirrorStatusRepository MirorStatusRepoFactory()
        {
            return new MirrorStatusRepository();
        }
    }
}
