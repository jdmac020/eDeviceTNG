using EDeviceClaims.Entities;
using EDeviceClaimSystem.Interactors.Tests.Factories.EntityFactories;
using EDeviceClaimSystem.Interactors.Tests.Factories.InteractorFactories;
using NUnit.Framework;
using Shouldly;

namespace EDeviceClaimSystem.Interactors.Tests.Tests
{
    [TestFixture]
    public class UpdateClaimInteractorTests
    {

        [Test]
        public void UpdateStatus_NewClaimIdAndStatusId_UpdatedClaimHasNewStatusId()
        {
            // Arrange
            var interactor = UpdateClaimInteractorFactory.Create();
            ClaimEntity claimToUpdate = ClaimFactory.Create();
            StatusEntity newStatus = StatusFactory.Create("Closed");

            // Run
            var result = interactor.UpdateStatus(claimToUpdate, newStatus);

            // Assert
            result.StatusId.ShouldBe(newStatus.Id);
        }
    }
}
