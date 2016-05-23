using System;
using System.Data.Entity;
using System.Linq;
using RL.Entity.Own;
using RL.OwnData.Contract.Infrastructure;

namespace RL.OwnData.Implementation.Infrastructure
{
    public class HardRemoveRepository<TDataType> : IHardRemoveRepository<TDataType> where TDataType : OwnEntityAggregation
    {
        protected readonly BookContext Context;
        protected readonly IDbSet<TDataType> Entities;

        public HardRemoveRepository(BookContext context)
        {
            Context = context;
            Entities = context.Set<TDataType>();
        }

        public IQueryable<TDataType> Get()
        {
            return Entities;
        }

        public TDataType Get(int id)
        {
            return Entities.FirstOrDefault(e => e.Id == id);
        }

        public void Insert(TDataType data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            Entities.Add(data);
        }

        public void Update(TDataType data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            if (Entities.FirstOrDefault(e => e.Id == data.Id) == null)
            {
                throw new ArgumentException("Entity with this id does not exist");
            }

            Context.Entry(data).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            var entity = Entities.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                throw new ArgumentException("Entity with this id does not exist");
            }

            Entities.Remove(entity);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
