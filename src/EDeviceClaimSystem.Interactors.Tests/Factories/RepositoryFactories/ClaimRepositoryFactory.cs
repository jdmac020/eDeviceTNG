using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaimSystem.Interactors.Tests.Mocks;

namespace EDeviceClaimSystem.Interactors.Tests.Factories.RepositoryFactories
{
    public static class ClaimRepositoryFactory
    {
        /// <summary>
        /// Create List Style Mock Repo
        /// </summary>
        public static MirrorClaimRepository CreateMirror()
        {
            return new MirrorClaimRepository();
        }

        /// <summary>
        /// Create List Style Mock Repo
        /// </summary>
        public static ListClaimRepository CreateList()
        {
            return new ListClaimRepository();
        }
    }
}
