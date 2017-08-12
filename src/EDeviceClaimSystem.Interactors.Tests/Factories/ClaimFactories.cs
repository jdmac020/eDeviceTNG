using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Entities;

namespace EDeviceClaimSystem.Interactors.Tests.Factories
{
    public static class ClaimFactories
    {
        /// <summary>
        /// Returns a new ClaimEntity with new Guids for Id, PolicyId, and StatusId
        /// </summary>
        public static ClaimEntity ClaimFactory()
        {
            return new ClaimEntity {Id = Guid.NewGuid(), PolicyId = Guid.NewGuid(), StatusId = Guid.NewGuid()};
        }

        /// <summary>
        /// Returns a new ClaimEntity with passed Guid for Id and new Guids for PolicyId and StatusId
        /// </summary>
        public static ClaimEntity ClaimFactoryCustomId(Guid id)
        {
            return new ClaimEntity { Id = id, PolicyId = Guid.NewGuid(), StatusId = Guid.NewGuid() };
        }

        /// <summary>
        /// Returns a new ClaimEntity with passed Guid for PolicyId and new Guids for Id and StatusId
        /// </summary>
        public static ClaimEntity ClaimFactoryCustomPolicy(Guid policyId)
        {
            return new ClaimEntity { Id = Guid.NewGuid(), PolicyId = policyId, StatusId = Guid.NewGuid() };
        }

        /// <summary>
        /// Returns a new ClaimEntity with passed Guid for StatusId and new Guids for Id and PolicyId
        /// </summary>
        public static ClaimEntity ClaimFactoryCustomStatus(Guid statusId)
        {
            return new ClaimEntity { Id = Guid.NewGuid(), PolicyId = Guid.NewGuid(), StatusId = statusId };
        }

        /// <summary>
        /// Returns a new ClaimEntity with passed Guids for Id, PolicyId, and StatusId
        /// </summary>
        public static ClaimEntity ClaimFactoryCustom(Guid id, Guid policyId, Guid statusId)
        {
            return new ClaimEntity { Id = id, PolicyId = policyId, StatusId = statusId };
        }
    }
}
