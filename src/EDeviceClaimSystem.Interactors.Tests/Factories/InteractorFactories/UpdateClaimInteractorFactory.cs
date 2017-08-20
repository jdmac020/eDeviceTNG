using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Interactors;
using EDeviceClaims.Repositories;
using EDeviceClaimSystem.Interactors.Tests.Mocks;

namespace EDeviceClaimSystem.Interactors.Tests.Factories.InteractorFactories
{
    public static class UpdateClaimInteractorFactory
    {
        /// <summary>
        /// Instantiate an UpdateClaimInteractor with a mock repository that mirrors input received
        /// </summary>
        public static UpdateClaimInteractor Create()
        {
            IClaimRepository mirrorClaimRepo = new MirrorClaimRepository();
            IStatusRepository mirrorStatusRepo = new MirrorStatusRepository();

            var interactor = new UpdateClaimInteractor(mirrorClaimRepo, mirrorStatusRepo);

            return interactor;
        }

        /// <summary>
        /// Instantiate an UpdateClaimInteractor with a mock repository that stores a list of claims to test against
        /// </summary>
        public static UpdateClaimInteractor Create(IClaimRepository listRepository)
        {
            IStatusRepository mirrorStatusRepo = new MirrorStatusRepository();

            var interactor = new UpdateClaimInteractor(listRepository, mirrorStatusRepo);

            return interactor;
        }
    }
}
