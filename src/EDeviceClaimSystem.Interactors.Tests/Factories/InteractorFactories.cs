using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Interactors;
using EDeviceClaims.Repositories;
using EDeviceClaimSystem.Interactors.Tests.Mocks;

namespace EDeviceClaimSystem.Interactors.Tests.Factories
{
    public static class InteractorFactories
    {
        /// <summary>
        /// Instantiate a GetClaimInteractor with a mock repository that mirrors input received
        /// </summary>
        /// <returns></returns>
        public static GetClaimInteractor MirrorRepositoryInteractor()
        {
            IClaimRepository mirrorClaimRepo = new MirrorClaimRepository();

            var interactor = new GetClaimInteractor(mirrorClaimRepo);

            return interactor;
        }

        /// <summary>
        /// Instantiate a GetClaimInteractor with a mock repository that stores a list of claims to test against
        /// </summary>
        public static GetClaimInteractor ListRepositoryInteractor(IClaimRepository repository)
        {
            var interactor = new GetClaimInteractor(repository);

            return interactor;
        }
    }
    
}
