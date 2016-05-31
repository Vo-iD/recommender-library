using System;
using System.Linq;
using System.Linq.Expressions;
using RL.Entity.Own;

namespace RL.OwnData.Contract.Infrastructure
{
    public interface IHardRemoveRepository<TDataType> where TDataType : OwnEntityAggregation
    {
        IQueryable<TDataType> Get(Expression<Func<TDataType, bool>> query);
        TDataType Get(int id);
        void Insert(TDataType data);
        void Update(TDataType data);
        void Delete(int id);
        void Save();
    }
}
