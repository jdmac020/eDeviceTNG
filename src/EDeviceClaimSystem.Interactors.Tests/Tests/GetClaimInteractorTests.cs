using System;
using EDeviceClaims.Entities;
using EDeviceClaims.Interactors;
using EDeviceClaims.Repositories;
using EDeviceClaimSystem.Interactors.Tests.Mocks;
using NUnit.Framework;
using Shouldly;

namespace EDeviceClaimSystem.Interactors.Tests.Tests
{
    /// <summary>
    /// Intermediate unit tests using in-class object factories
    /// </summary>
    [TestFixture]
    public class GetClaimInteractorTests
    {
        private ClaimEntity CreateNewClaim()
        {
            return new ClaimEntity { Id = Guid.NewGuid(), PolicyId = Guid.NewGuid(), StatusId = Guid.NewGuid() };
        }

        private ClaimEntity CreateNewClaim(string statusName)
        {
            return new ClaimEntity { Id = Guid.NewGuid(), PolicyId = Guid.NewGuid(), StatusName = statusName };
        }

        private ListClaimRepository CreateMockListClaimRepo()
        {
            return new ListClaimRepository();
        }

        private GetClaimInteractor CreateInteractor(IClaimRepository repository)
        {
            return new GetClaimInteractor(repository);
        }

        private GetClaimInteractor CreateInteractor()
        {
            IClaimRepository mockRepo = new MirrorClaimRepository();

            return new GetClaimInteractor(mockRepo);
        }

        [Test]
        public void GetById_NewClaimId_RetrievedClaimHasSameId()
        {
            // Arrange
            var claim = CreateNewClaim();

            var interactor = CreateInteractor();
            
            // Run
            var result = interactor.GetById(claim.Id);

            // Assert
            result.Id.ShouldBe(claim.Id);
        }

        [Test]
        public void GetById_EmptyClaimId_ReturnsNull()
        {
            // Arrange
            var claimRepo = CreateMockListClaimRepo();
            var storedClaim = CreateNewClaim();

            claimRepo.Create(storedClaim);

            var nonexistingClaimId = Guid.Empty;

            GetClaimInteractor interactor = CreateInteractor(claimRepo);

            // Act
            var result = interactor.GetById(nonexistingClaimId);

            // Assert
            result.ShouldBe(null);

        }

        [Test]
        public void GetById_BadClaimId_ReturnsNull()
        {
            // Arrange
            var claimRepo = CreateMockListClaimRepo();
            var storedClaim = CreateNewClaim();

            claimRepo.Create(storedClaim);

            var nonexistingClaimId = Guid.NewGuid();

            GetClaimInteractor interactor = CreateInteractor(claimRepo);

            // Act
            var result = interactor.GetById(nonexistingClaimId);

            // Assert
            result.ShouldBe(null);

        }

        [Test]
        public void GetAllOpen_ThreeOpenClaims_ReturnsAllThree()
        {
            var claimRepo = CreateMockListClaimRepo();
            
            claimRepo.Create(CreateNewClaim("Open"));
            claimRepo.Create(CreateNewClaim("Open"));
            claimRepo.Create(CreateNewClaim("Open"));

            var interactor = CreateInteractor(claimRepo);

            var result = interactor.GetAllOpen();

            result.Count.ShouldBe(3);
        }

        [Test]
        public void GetAllOpen_TwoOpenClaimsOneClosed_ReturnsTwo()
        {
            var claimRepo = CreateMockListClaimRepo();

            claimRepo.Create(CreateNewClaim("Open"));
            claimRepo.Create(CreateNewClaim("Open"));
            claimRepo.Create(CreateNewClaim("NotOpen"));

            var interactor = CreateInteractor(claimRepo);

            var result = interactor.GetAllOpen();

            result.Count.ShouldBe(2);
        }
    }
}
