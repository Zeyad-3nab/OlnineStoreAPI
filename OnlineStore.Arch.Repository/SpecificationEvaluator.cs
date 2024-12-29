using Microsoft.EntityFrameworkCore;
using OnlineStore.Arch.Core.Models;
using OnlineStore.Arch.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Arch.Repository
{
    public static class SpecificationEvaluator<TEntity,TKey> where TEntity : BaseModel<TKey>
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery , ISpecification<TEntity , TKey> spec) 
        {
            var query = inputQuery;
            if (spec.criateria is not null) 
            {
                query = query.Where(spec.criateria);
            }


            if (spec.OrderBy is not null) 
            {
                query = query.OrderBy(spec.OrderBy);
            }
            if (spec.OrderByDescending is not null)
            {
                query = query.OrderByDescending(spec.OrderBy);
            }

            if (spec.IsPaginationEnable) 
            {
                query=query.Skip(spec.Skip).Take(spec.Take);
            }

            //if (spec.Includes.Count != 0) 
            //{
            //    foreach (var item in spec.Includes) 
            //    {
            //        query=query.Include(item);
            //    }
            //}

            query = spec.Includes.Aggregate(query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));




            return query;
        }
    }
}
