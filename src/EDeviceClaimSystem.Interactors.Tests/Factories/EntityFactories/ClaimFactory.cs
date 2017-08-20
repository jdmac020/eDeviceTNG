using System;
using EDeviceClaims.Entities;

namespace EDeviceClaimSystem.Interactors.Tests.Factories.EntityFactories
{
    public static class ClaimFactory
    {
        /// <summary>
        /// Returns a new ClaimEntity with new Guids for Id, PolicyId, and StatusId
        /// </summary>
        public static ClaimEntity Create()
        {
            return new ClaimEntity {Id = Guid.NewGuid(), PolicyId = Guid.NewGuid(), StatusId = Guid.NewGuid()};
        }

        /// <summary>
        /// Returns a new ClaimEntity with passed Guid for Id and new Guids for PolicyId and StatusId
        /// </summary>
        public static ClaimEntity Create(Guid claimId)
        {
            return new ClaimEntity { Id = claimId, PolicyId = Guid.NewGuid(), StatusId = Guid.NewGuid() };
        }

        /// <summary>
        /// Returns a new ClaimEntity with passed Guid for PolicyId and new Guids for Id and StatusId
        /// </summary>
        public static ClaimEntity CreateCustomPolicy(Guid policyId)
        {
            return new ClaimEntity { Id = Guid.NewGuid(), PolicyId = policyId, StatusId = Guid.NewGuid() };
        }

        /// <summary>
        /// Returns a new ClaimEntity with passed Guid for StatusId and new Guids for Id and PolicyId
        /// </summary>
        public static ClaimEntity CreateCustomStatus(Guid statusId)
        {
            return new ClaimEntity { Id = Guid.NewGuid(), PolicyId = Guid.NewGuid(), StatusId = statusId };
        }

        /// <summary>
        /// Returns a new ClaimEntity with passed Guids for Id, PolicyId, and StatusId
        /// </summary>
        public static ClaimEntity Create(Guid claimId, Guid policyId, Guid statusId)
        {
            return new ClaimEntity { Id = claimId, PolicyId = policyId, StatusId = statusId };
        }
    }
}
