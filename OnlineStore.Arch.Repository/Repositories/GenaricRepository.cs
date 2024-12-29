using Microsoft.EntityFrameworkCore;
using OnlineStore.Arch.Core.IRepositories;
using OnlineStore.Arch.Core.Models;
using OnlineStore.Arch.Core.Specifications;
using OnlineStore.Arch.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Arch.Repository.Repositories
{
    public class GenaricRepository<T, TKey> : IGenaricRepository<T, TKey> where T : BaseModel<TKey>
    {
        private readonly ApplicationDbContext context;

        public GenaricRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {

            if (typeof(T) == typeof(Product)) 
            {
                return (IEnumerable<T>) await context.products.Include(e=>e.ProductBrand).Include(e=>e.ProductType).ToListAsync();
            }

           return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(TKey id)
        {
            if (typeof(T) == typeof(Product))
            {
                return await context.products.Include(e => e.ProductBrand).Include(e => e.ProductType).FirstOrDefaultAsync(e => e.Id == id as int?) as T; 
            }

            return await context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T model)
        {
           await context.AddAsync(model);
        }

        public void Update(T model)
        {
            context.Update(model);
        }

        public void Delete(T model)
        {
            context.Remove(model);
        }

        public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T, TKey> specification)
        {
            return await SpecificationEvaluator<T, TKey>.GetQuery(context.Set<T>(), specification).ToListAsync();
        }

        public async Task<T> GetByIdWithSpecAsync(ISpecification<T, TKey> specification)
        {
            return await SpecificationEvaluator<T, TKey>.GetQuery(context.Set<T>(), specification).FirstOrDefaultAsync();
        }

        public async Task<int> GetCountAsync(ISpecification<T, TKey> specification)
        {
            return await SpecificationEvaluator<T, TKey>.GetQuery(context.Set<T>(), specification).CountAsync();
        }
    }
}
