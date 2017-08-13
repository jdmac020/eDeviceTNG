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
        public static GetClaimInteractor GetClaimInteractorMirrorRepository()
        {
            IClaimRepository mirrorClaimRepo = new MirrorClaimRepository();

            var interactor = new GetClaimInteractor(mirrorClaimRepo);

            return interactor;
        }

        /// <summary>
        /// Instantiate a GetClaimInteractor with a mock repository that stores a list of claims to test against
        /// </summary>
        public static GetClaimInteractor GetClaimInteractorListRepository(IClaimRepository repository)
        {
            var interactor = new GetClaimInteractor(repository);

            return interactor;
        }

        /// <summary>
        /// Instantiate a CreateClaimInteractor with a mock repository that mirrors input received
        /// </summary>
        public static CreateClaimInteractor CreateClaimInteractorMirrorRepository()
        {
            IClaimRepository mirrorClaimRepo = new MirrorClaimRepository();
            IStatusRepository mirrorStatusRepo = new MirrorStatusRepository();

            var interactor = new CreateClaimInteractor(mirrorClaimRepo, mirrorStatusRepo);

            return interactor;
        }

        /// <summary>
        /// Instantiate an UpdateClaimInteractor with a mock repository that mirrors input received
        /// </summary>
        public static UpdateClaimInteractor UpdateClaimInteractorMirrorRepository()
        {
            IClaimRepository mirrorClaimRepo = new MirrorClaimRepository();
            IStatusRepository mirrorStatusRepo = new MirrorStatusRepository();

            var interactor = new UpdateClaimInteractor(mirrorClaimRepo, mirrorStatusRepo);

            return interactor;
        }

        /// <summary>
        /// Instantiate an UpdateClaimInteractor with a mock repository that stores a list of claims to test against
        /// </summary>
        public static UpdateClaimInteractor UpdateClaimInteractorListrRepository()
        {
            IClaimRepository listClaimRepo = new ListClaimRepository();
            IStatusRepository mirrorStatusRepo = new MirrorStatusRepository();

            var interactor = new UpdateClaimInteractor(listClaimRepo, mirrorStatusRepo);

            return interactor;
        }
        
    }
    
}
