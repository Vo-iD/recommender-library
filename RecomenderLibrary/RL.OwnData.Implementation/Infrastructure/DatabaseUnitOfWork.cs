using System;
using System.Collections.Generic;
using RL.Entity;
using RL.Entity.Own;
using RL.OwnData.Contract.Infrastructure;

namespace RL.OwnData.Implementation.Infrastructure
{
    public class DatabaseUnitOfWork : IDatabaseUnitOfWork
    {
        private readonly BookContext _context;
        private bool _disposed;
        private Dictionary<string, object> _safeRemoveRepositories;
        private Dictionary<string, object> _hardRemoveRepositories;

        public DatabaseUnitOfWork(BookContext context)
        {
            _context = context;
        }

        public DatabaseUnitOfWork()
        {
            _context = new BookContext();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public ISafeRemoveRepository<TData> SafeRemoveRepository<TData>() where TData : SafeRemoveAggregation
        {
            if (_safeRemoveRepositories == null)
            {
                _safeRemoveRepositories = new Dictionary<string, object>();
            }

            var type = typeof(TData).Name;

            if (!_safeRemoveRepositories.ContainsKey(type))
            {
                var repositoryType = typeof(SafeRemoveRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TData)), _context);
                _safeRemoveRepositories.Add(type, repositoryInstance);
            }

            return (ISafeRemoveRepository<TData>) _safeRemoveRepositories[type];
        }

        public IHardRemoveRepository<TData> HardRemoveRepository<TData>() where TData : OwnEntityAggregation
        {
            if (_hardRemoveRepositories == null)
            {
                _hardRemoveRepositories = new Dictionary<string, object>();
            }

            var type = typeof(TData).Name;

            if (!_hardRemoveRepositories.ContainsKey(type))
            {
                var repositoryType = typeof(HardRemoveRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TData)), _context);
                _hardRemoveRepositories.Add(type, repositoryInstance);
            }

            return (HardRemoveRepository<TData>)_hardRemoveRepositories[type];
        }
    }
}
