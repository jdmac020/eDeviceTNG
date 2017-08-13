using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using EDeviceClaims.Interactors;
using EDeviceClaims.Repositories;
using EDeviceClaimSystem.Interactors.Tests.Mocks;
using EDeviceClaimSystem.Interactors.Tests.Factories;
using Shouldly;

namespace EDeviceClaimSystem.Interactors.Tests
{
    [TestFixture]
    public class CreateClaimInteractorTests
    {

        [Test]
        public void CreateClaimExecute_NewPolicyId_InsertedClaimHasSamePolicyId()
        {
            // Arrange
            var interactor = InteractorFactories.CreateClaimInteractorMirrorRepository();
            var newClaim = ClaimFactories.ClaimFactory();

            // Run
            var result = interactor.Execute(newClaim.PolicyId, newClaim.StatusId);

            // Assert
            result.PolicyId.ShouldBe(newClaim.PolicyId);
        }

        [Test]
        public void CreateClaimExecute_NewPolicyId_InsertedClaimHasSameStatus()
        {
            // Arrange
            var interactor = InteractorFactories.CreateClaimInteractorMirrorRepository();
            var newClaim = ClaimFactories.ClaimFactory();

            // Run
            var result = interactor.Execute(newClaim.PolicyId, newClaim.StatusId);

            // Assert
            result.StatusId.ShouldBe(newClaim.StatusId);
        }
    }
}
