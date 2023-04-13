using ECO.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Repositories
{
    public interface IWriteRepository<T, TKey> : IRepository<T, TKey> where T : BaseEntity<TKey>
    {
        Task<bool> AddAsync(T model);        
        bool Remove(T datas);    
        Task<bool> RemoveAsync(string id);
        Task<bool> RemoveAsync(int id);  
        bool Update(T model);
        Task<int> SaveAsync();
    }
}
