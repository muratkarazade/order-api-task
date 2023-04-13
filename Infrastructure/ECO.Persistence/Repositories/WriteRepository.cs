using ECO.Application.Repositories;
using ECO.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECO.Persistence.Context;

namespace ECO.Persistence.Repositories
{
    public class WriteRepository<T, TKey> : IWriteRepository<T, TKey> where T : BaseEntity<TKey>
    {
        protected private AppDbContext _context;

        public WriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }
        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }
        public async Task<bool> RemoveAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id.ToString() == id.ToString());
            //T model = await Table.FirstOrDefaultAsync(data => data.Id == id); //Guid.Parse(id) id de guid kullanılırsa parse edilecek
            return Remove(model);
        }
        public async Task<bool> RemoveAsync(int id)
        {

            T model = await Table.FirstOrDefaultAsync(data => data.Id.ToString() == id.ToString());
            return Remove(model);
        }
        public async Task<bool> RemoveAsync(Guid id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id.ToString() == id.ToString());
            return Remove(model);
        }
        public bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();


    }
}
