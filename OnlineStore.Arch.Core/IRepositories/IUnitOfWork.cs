using OnlineStore.Arch.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Arch.Core.IRepositories
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync();

        //Create Repository<T> And Return

       IGenaricRepository<T , TKey> Repository<T , TKey>()where T :BaseModel<TKey>;
    }
}
