using System;
using EDeviceClaims.Entities;

namespace EDeviceClaimSystem.Interactors.Tests.Factories.EntityFactories
{
    public static class StatusFactory
    {
        /// <summary>
        /// Returns a new StatusEntity with a new Guid for Id and "New" for name 
        /// </summary>
        public static StatusEntity Create()
        {
            return new StatusEntity {Id = Guid.NewGuid(), Name = "New"};
        }

        /// <summary>
        /// Returns a new StatusEntity with passed Guid for Id and "New" for name
        /// </summary>
        public static StatusEntity Create(Guid id)
        {
            return new StatusEntity { Id = id, Name = "New" };
        }

        /// <summary>
        /// Returns a new StatusEntity with passed string for Name and new Guid for Id
        /// </summary>
        public static StatusEntity Create(string name)
        {
            return new StatusEntity { Id = Guid.NewGuid(), Name = name };
        }

        /// <summary>
        /// Returns a new StatusEntity with passed Guid for Id and passed string for Name
        /// </summary>
        public static StatusEntity Create(Guid id, string name)
        { 
            return new StatusEntity { Id = id, Name = name };
        }
    }
}
