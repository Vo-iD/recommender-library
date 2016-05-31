using RL.Entity.Own;

namespace RL.OwnData.Contract.Infrastructure
{
    public interface IDatabaseUnitOfWork
    {
        void Save();

        void Dispose(bool disposing);

        IHardRemoveRepository<TData> HardRemoveRepository<TData>() where TData : OwnEntityAggregation;

        ISafeRemoveRepository<TData> SafeRemoveRepository<TData>() where TData : SafeRemoveAggregation;
    }
}
