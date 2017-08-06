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
    public class GetClaimInteractorTests
    {
        private GetClaimInteractor InteractorFactory()
        {
            IClaimRepository mirrorClaimRepo = new MirrorClaimRepository();

            var interactor = new GetClaimInteractor(mirrorClaimRepo);
            
            return interactor;
        }

        [Test]
        public void Execute_NewClaimId_RetirievedClaimHasSameId()
        {
            // Arrange
            GetClaimInteractor interactor = InteractorFactory();
            Guid newClaimId = Guid.NewGuid();

            // Run
            var newClaim = interactor.GetById(newClaimId);

            // Assert
            newClaim.Id.ShouldBe(newClaimId);
        }
    }
}
