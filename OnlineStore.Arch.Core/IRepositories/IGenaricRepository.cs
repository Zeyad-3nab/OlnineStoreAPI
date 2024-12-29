using OnlineStore.Arch.Core.Models;
using OnlineStore.Arch.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Arch.Core.IRepositories
{
    public interface IGenaricRepository<T , TKey> where T : BaseModel<TKey>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(TKey id);

        Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T , TKey> specification);
        Task<T> GetByIdWithSpecAsync(ISpecification<T, TKey> specification);
        Task<int> GetCountAsync(ISpecification<T , TKey> spec);

        Task AddAsync(T model);
        void Update(T model);
        void Delete(T model);

    }
}
