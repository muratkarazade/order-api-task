using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Repositories.Carrier
{
    public interface ICarrierReadRepository : IReadRepository<Domain.Entities.Carrier, int>
    {
        IQueryable<T> GetQueryable<T>() where T : class;
        Task<T> GetByIdAsync<T>(int id) where T : class;
    }
}
