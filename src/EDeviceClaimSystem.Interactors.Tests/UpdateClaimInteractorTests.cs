using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Entities;
using NUnit.Framework;

using EDeviceClaims.Interactors;
using EDeviceClaims.Repositories;
using EDeviceClaimSystem.Interactors.Tests.Factories;
using EDeviceClaimSystem.Interactors.Tests.Mocks;
using Shouldly;

namespace EDeviceClaimSystem.Interactors.Tests
{
    [TestFixture]
    public class UpdateClaimInteractorTests
    {

        [Test]
        public void UpdateStatus_NewClaimIdAndStatusId_UpdatedClaimHasNewStatusId()
        {
            // Arrange
            var interactor = InteractorFactories.UpdateClaimInteractorMirrorRepository();
            ClaimEntity claimToUpdate = ClaimFactories.ClaimFactory();
            StatusEntity newStatus = StatusFactories.StatusactoryCustomName("Closed");

            // Run
            var result = interactor.UpdateStatus(claimToUpdate, newStatus);

            // Assert
            result.StatusId.ShouldBe(newStatus.Id);
        }
    }
}
