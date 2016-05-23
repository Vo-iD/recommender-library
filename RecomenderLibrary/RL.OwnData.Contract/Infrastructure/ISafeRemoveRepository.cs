using RL.Entity.Own;

namespace RL.OwnData.Contract.Infrastructure
{
    public interface ISafeRemoveRepository<TData> : IHardRemoveRepository<TData>
        where TData : SafeRemoveAggregation
    {
    }
}
