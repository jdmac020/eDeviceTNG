using EDeviceClaimSystem.Interactors.Tests.Factories.EntityFactories;
using EDeviceClaimSystem.Interactors.Tests.Factories.InteractorFactories;
using NUnit.Framework;
using Shouldly;

namespace EDeviceClaimSystem.Interactors.Tests.Tests
{
    [TestFixture]
    public class CreateClaimInteractorTests
    {

        [Test]
        public void CreateClaimExecute_NewPolicyId_InsertedClaimHasSamePolicyId()
        {
            // Arrange
            var interactor = CreateClaimInteractorFactory.Create();
            var newClaim = ClaimFactory.Create();

            // Run
            var result = interactor.Execute(newClaim.PolicyId, newClaim.StatusId);

            // Assert
            result.PolicyId.ShouldBe(newClaim.PolicyId);
        }

        [Test]
        public void CreateClaimExecute_NewPolicyId_InsertedClaimHasSameStatus()
        {
            // Arrange
            var interactor = CreateClaimInteractorFactory.Create();
            var newClaim = ClaimFactory.Create();

            // Run
            var result = interactor.Execute(newClaim.PolicyId, newClaim.StatusId);

            // Assert
            result.StatusId.ShouldBe(newClaim.StatusId);
        }
    }
}
