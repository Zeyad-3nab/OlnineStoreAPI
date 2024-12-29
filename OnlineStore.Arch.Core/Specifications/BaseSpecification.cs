using OnlineStore.Arch.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Arch.Core.Specifications
{
    public class BaseSpecification<TEntity, TKey> : ISpecification<TEntity, TKey> where TEntity : BaseModel<TKey>
    {
        public Expression<Func<TEntity, bool>> criateria { get; set; } = null;
        public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new List<Expression<Func<TEntity, object>>>();
        public Expression<Func<TEntity, object>> OrderBy { get; set; } = null;
        public Expression<Func<TEntity, object>> OrderByDescending { get ; set ; } = null;
        public int Skip { get ; set ; }
        public int Take { get ; set ; }
        public bool IsPaginationEnable { get; set; }

        public BaseSpecification(Expression<Func<TEntity , bool>> expression)
        {
            criateria = expression;
        }
        public BaseSpecification()
        {
                
        }


        public void ApplyPagination(int _Skip, int _Take) 
        {
            IsPaginationEnable = true;
            Take = _Take;
            Skip = _Skip;

        }
    }
}
