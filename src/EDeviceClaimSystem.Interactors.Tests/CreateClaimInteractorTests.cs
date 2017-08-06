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
    public class CreateClaimInteractorTests
    {
        private CreateClaimInteractor InteractorFactory()
        {
            IClaimRepository mirrorClaimRepo = new MirrorClaimRepository();
            IStatusRepository mirrorStatusRepo = new MirrorStatusRepository();

            var interactor = new CreateClaimInteractor(mirrorClaimRepo, mirrorStatusRepo);
            
            return interactor;
        }

        [Test]
        public void Execute_NewPolicyId_InsertedClaimHasSamePolicyId()
        {
            // Arrange
            CreateClaimInteractor interactor = InteractorFactory();
            Guid newPolicyId = Guid.NewGuid();
            Guid newStatus = Guid.NewGuid();

            // Run
            var newClaim = interactor.Execute(newPolicyId, newStatus);

            // Assert
            newClaim.PolicyId.ShouldBe(newPolicyId);
        }

        [Test]
        public void Execute_NewPolicyId_InsertedClaimHasSameStatus()
        {
            // Arrange
            CreateClaimInteractor interactor = InteractorFactory();
            Guid newPolicyId = Guid.NewGuid();
            Guid newStatus = Guid.NewGuid();

            // Run
            var newClaim = interactor.Execute(newPolicyId, newStatus);

            // Assert
            newClaim.StatusId.ShouldBe(newStatus);
        }
    }
}
