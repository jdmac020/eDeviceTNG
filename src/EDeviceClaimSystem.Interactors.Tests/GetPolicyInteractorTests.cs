using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Interactors;
using NUnit.Framework;
using Shouldly;

namespace EDeviceClaimSystem.Interactors.Tests
{
    /// <summary>
    /// Basic unit tests using in-test object creation
    /// </summary>
    
    [TestFixture]
    public class GetPolicyInteractorTests
    {
        [Test]
        public void GetPolicyById_EmptyPolicyId_ReturnsNull()
        {
            // Arrange the test
            IGetPolicyInteractor interactor = new GetPolicyInteractor();
            var emptyGuid = Guid.Empty;

            // Act (run the test)
            var result = interactor.GetById(emptyGuid);

            // Assert what should happen
            result.ShouldBe(null);
        }
    }
}
