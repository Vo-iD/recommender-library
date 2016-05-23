using RL.Entity.Own;

namespace RL.OwnData.Contract.Infrastructure
{
    public interface IUnitOfWork
    {
        void Save();

        void Dispose(bool disposing);

        IHardRemoveRepository<TData> HardRemoveRepository<TData>() where TData : OwnEntityAggregation;

        ISafeRemoveRepository<TData> SafeRemoveRepository<TData>() where TData : SafeRemoveAggregation;
    }
}
