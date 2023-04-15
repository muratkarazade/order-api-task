using ECO.Application.Repositories.Carrier;
using ECO.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Persistence.Repositories.Carrier
{
    public class CarrierReadRepository : ReadRepository<Domain.Entities.Carrier, int>, ICarrierReadRepository
    {
        public AppDbContext Context { get; }

        public CarrierReadRepository(AppDbContext context) : base(context)
        {
            Context = context;
        }
        public IQueryable<T> GetQueryable<T>() where T : class
        {
            return Context.Set<T>();
        }

        public async Task<T> GetByIdAsync<T>(int id) where T : class
        {
            return await Context.Set<T>().FindAsync(id);
        }
    }
}
