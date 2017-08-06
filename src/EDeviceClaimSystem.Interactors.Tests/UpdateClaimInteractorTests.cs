using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Entities;
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

            var interactor = new UpdateClaimInteractor(mirrorClaimRepo, mirrorStatusRepo);
            
            return interactor;
        }

        private StatusEntity StatusFactory()
        {
            return new StatusEntity {Id = Guid.NewGuid(), Name = "Irrelevant"};
        }

        private ClaimEntity ClaimFactory()
        {
            return new ClaimEntity {Id = Guid.NewGuid(), PolicyId = Guid.NewGuid(), StatusId = Guid.NewGuid()};
        }

        [Test]
        public void UpdateStatus_NewClaimIdAndStatusId_UpdatedClaimHasNewStatusId()
        {
            // Arrange
            UpdateClaimInteractor interactor = InteractorFactory();
            ClaimEntity claimToUpdate = ClaimFactory();
            StatusEntity newStatus = StatusFactory();
            var testValue = claimToUpdate.StatusId;

            // Run
            var updatedClaim = interactor.UpdateStatus(claimToUpdate, newStatus);

            // Assert
            updatedClaim.StatusId.ShouldNotBe(testValue);
        }
    }
}
