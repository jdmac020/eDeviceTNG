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
    /// Basic unit tests using in-test object creation
    /// </summary>

    [TestFixture]
    public class GetPolicyInteractorTests
    {
        [Test]
        public void GetPolicyById_EmptyGuidId_ReturnsNull() // NameOfMethodTesting_TestConditionUsed_ExpectedResult
        {
            // ARRANGE (set up the test)

                // Create mock repository to avoid using the actual database
                IPolicyRepository fakeRepo = new MirrorPolicyRepository();

                // Create interactor to test and inject mock repository
                // Your production code may not need a constructor that calls for a repo as a paramter,
                // so you may need to add it strictly for testing purposes.
                IGetPolicyInteractor interactor = new GetPolicyInteractor(fakeRepo);

                // Create value to test with
                var newGuid = Guid.Empty;

            // ACT (run the test)

                // Perform the unit of work needing to be tested
                var result = interactor.GetById(newGuid);

            // ASSERT (declare what should have happened and check it)

                // There is no policy with that Guid, so no policy should be returned
                result.ShouldBe(null);
        }

        [Test]
        public void GetPolicyById_NewTestPolicy_ReturnsTestId()
        {
            // Arrange

                // Create mock repo and insert a new policy
                IPolicyRepository fakeRepo = new MirrorPolicyRepository();
                var testPolicy = new Policy {Id = Guid.NewGuid()};
            
                // Create interactor to test and insert the mock repository
                IGetPolicyInteractor interactor = new GetPolicyInteractor(fakeRepo);
            
            // Act

                // using testPolicy's Id, try to get the test policy
                var result = interactor.GetById(testPolicy.Id);

            // Assert

                // Since the test policy exists, the interactor should return it and it should be the same
                // as the testPolicy object
                result.Id.ShouldBe(testPolicy.Id);
        }
    }
}

