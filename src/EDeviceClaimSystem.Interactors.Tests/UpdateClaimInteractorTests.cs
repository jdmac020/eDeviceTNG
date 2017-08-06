using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using EDeviceClaims.Interactors;
using EDeviceClaims.Repositories;
using EDeviceClaimSystem.Interactors.Tests.Mocks;
using Shouldly;
using Shouldly.ShouldlyExtensionMethods;

namespace EDeviceClaimSystem.Interactors.Tests
{
    [TestFixture]
    public class UpdateClaimInteractorTests
    {
        private UpdateClaimInteractor InteractorFactory()
        {
            IClaimRepository mirrorClaimRepo = new MirrorClaimRepository();
            IStatusRepository mirrorStatusRepo = new MirrorStatusRepository();

            var interactor = new UpdateClaimInteractor(mirrorClaimRepo, miStatusRepo);
            
            return interactor;
        }

        [Test]
        public void Execute_NewClaimId_RetirievedClaimHasSameId()
        {
            // Arrange
            GetClaimInteractor interactor = InteractorFactory();
            Guid newClaimId = Guid.NewGuid();

            // Run
            var newClaim = interactor.Execute(newClaimId);

            // Assert
            newClaim.Id.ShouldBe(newClaimId);
        }
    }
}
