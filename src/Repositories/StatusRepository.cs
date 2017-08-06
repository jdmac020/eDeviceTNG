using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Core;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Repositories
{
    public interface IStatusRepository : IEfRepository<StatusEntity, Guid>
    {
        new StatusEntity GetById(Guid id);
        StatusEntity GetByName(string name);
    }

    public class StatusRepository : EfRepository<StatusEntity, Guid>, IStatusRepository
    {
        public StatusRepository() : base(new EDeviceClaimsUnitOfWork())
        {
        }

        public StatusRepository(IEfUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public new StatusEntity GetById(Guid id)
        {
            return ObjectSet
                .FirstOrDefault(c => c.Id == id);
        }

        public StatusEntity GetByName(string name)
        {
            return ObjectSet
                .FirstOrDefault(c => c.Name == name);
        }
    }
}
