using System.Linq;
using RL.Entity.Own;

namespace RL.OwnData.Contract.Infrastructure
{
    public interface IHardRemoveRepository<TDataType> where TDataType : OwnEntityAggregation
    {
        IQueryable<TDataType> Get();
        TDataType Get(int id);
        void Insert(TDataType data);
        void Update(TDataType data);
        void Delete(int id);
        void Save();
    }
}
