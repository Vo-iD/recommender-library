using System;
using System.Data.Entity;
using System.Linq;
using RL.Entity.Own;
using RL.OwnData.Contract.Infrastructure;

namespace RL.OwnData.Implementation.Infrastructure
{
    public class SafeRemoveRepository<TData> : HardRemoveRepository<TData>, ISafeRemoveRepository<TData>
        where TData : SafeRemoveAggregation
    {
        public SafeRemoveRepository(BookContext context) : base(context)
        {
        }

        public override void Delete(int id)
        {
            var entity = Entities.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                throw new ArgumentException("Entity with this id does not exist");
            }

            entity.IsRemoved = true;
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
