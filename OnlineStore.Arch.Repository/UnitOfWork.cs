using OnlineStore.Arch.Core.IRepositories;
using OnlineStore.Arch.Core.Models;
using OnlineStore.Arch.Repository.Data.Contexts;
using OnlineStore.Arch.Repository.Repositories;
using System.Collections;

namespace OnlineStore.Arch.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        private Hashtable _Repositories;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            _Repositories = new Hashtable();
        }
        public async Task<int> CompleteAsync() => await context.SaveChangesAsync();

        public IGenaricRepository<T, TKey> Repository<T, TKey>() where T : BaseModel<TKey>
        {
            var type=typeof(T).Name;
            if (!_Repositories.ContainsKey(type)) 
            {
                var repository = new GenaricRepository<T, TKey>(context);
                _Repositories.Add(type, repository);
            }


            return _Repositories[type] as IGenaricRepository<T , TKey>;

        }
    }
}
