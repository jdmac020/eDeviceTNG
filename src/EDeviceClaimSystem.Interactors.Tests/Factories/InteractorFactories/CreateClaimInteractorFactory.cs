using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Repositories;
using EDeviceClaims.Interactors;
using EDeviceClaimSystem.Interactors.Tests.Mocks;

namespace EDeviceClaimSystem.Interactors.Tests.Factories.InteractorFactories
{
    public static class CreateClaimInteractorFactory
    {
        /// <summary>
        /// Instantiate a CreateClaimInteractor with a mock repository that mirrors input received
        /// </summary>
        public static CreateClaimInteractor Create()
        {
            IClaimRepository mirrorClaimRepo = new MirrorClaimRepository();
            IStatusRepository mirrorStatusRepo = new MirrorStatusRepository();

            var interactor = new EDeviceClaims.Interactors.CreateClaimInteractor(mirrorClaimRepo, mirrorStatusRepo);

            return interactor;
        }
    }
}
