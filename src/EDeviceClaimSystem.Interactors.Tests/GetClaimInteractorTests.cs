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
using NSubstitute;
using Shouldly;
using Shouldly.ShouldlyExtensionMethods;
using NSubstitute.Core;

namespace EDeviceClaimSystem.Interactors.Tests
{
    [TestFixture]
    public class GetClaimInteractorTests
    {
        [Test]
        public void GetClaimExecute_NewClaimId_RetirievedClaimHasSameId()
        {
            // Arrange
            GetClaimInteractor interactor = InteractorFactories.MirrorRepositoryInteractor();
            Guid newClaimId = Guid.NewGuid();

            // Run
            var newClaim = interactor.GetById(newClaimId);

            // Assert
            newClaim.Id.ShouldBe(newClaimId);
        }

        [Test]
        public void GetClaimExecute_EmptyClaimId_ReturnsNull()
        {
            // Arrange
            var claimRepo = RespositoryFactories.ListClaimRepoFactory();
            var storedClaim = ClaimFactories.ClaimFactoryCustomId(Guid.NewGuid());

            claimRepo.Create(storedClaim);

            var nonexistingClaimId = Guid.Empty;

            GetClaimInteractor interactor = InteractorFactories.ListRepositoryInteractor(claimRepo);

            // Act
            var result = interactor.GetById(nonexistingClaimId);

            // Assert
            result.ShouldBe(null);

        }

        [Test]
        public void GetClaimExecute_BadClaimId_ReturnsNull()
        {
            // Arrange
            var claimRepo = RespositoryFactories.ListClaimRepoFactory();
            var storedClaim = ClaimFactories.ClaimFactoryCustomId(Guid.NewGuid());

            claimRepo.Create(storedClaim);

            var nonexistingClaimId = Guid.NewGuid();

            GetClaimInteractor interactor = InteractorFactories.ListRepositoryInteractor(claimRepo);

            // Act
            var result = interactor.GetById(nonexistingClaimId);

            // Assert
            result.ShouldBe(null);

        }
    }
}
