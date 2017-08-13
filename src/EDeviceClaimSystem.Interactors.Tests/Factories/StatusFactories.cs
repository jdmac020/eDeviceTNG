using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Entities;

namespace EDeviceClaimSystem.Interactors.Tests.Factories
{
    public static class StatusFactories
    {
        /// <summary>
        /// Returns a new StatusEntity with a new Guid for Id and "New" for name 
        /// </summary>
        public static StatusEntity StatusFactory()
        {
            return new StatusEntity {Id = Guid.NewGuid(), Name = "New"};
        }

        /// <summary>
        /// Returns a new StatusEntity with passed Guid for Id and "New" for name
        /// </summary>
        public static StatusEntity StatusFactoryCustomId(Guid id)
        {
            return new StatusEntity { Id = id, Name = "New" };
        }

        /// <summary>
        /// Returns a new StatusEntity with passed string for Name and new Guid for Id
        /// </summary>
        public static StatusEntity StatusactoryCustomName(string name)
        {
            return new StatusEntity { Id = Guid.NewGuid(), Name = name };
        }

        /// <summary>
        /// Returns a new StatusEntity with passed Guid for Id and passed string for Name
        /// </summary>
        public static StatusEntity StatusFactoryCustom(Guid id, string name)
        { 
            return new StatusEntity { Id = id, Name = name };
        }
    }
}
