using System;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories;

namespace EDeviceClaimSystem.Interactors.Tests.Mocks
{
    public class MirrorStatusRepository : EfRepository<StatusEntity, Guid>, IStatusRepository
    {
        public StatusEntity GetByName(string statusName)
        {
            return new StatusEntity {Name = statusName};
        }
    }
}
