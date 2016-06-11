using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RL.DataProcessing.Contract.Infrastructure;
using RL.Entity.Own;
using RL.OwnData.Contract.Infrastructure;
using RL.RemoteData.Contract.Infrastructure;
using RL.RemoteData.Contract.RemoteModels;

namespace RL.DataProcessing.Implementation.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IGoogleRepository _googleRepository;
        private readonly IDatabaseUnitOfWork _databaseUnitOfWork;

        public UnitOfWork(IGoogleRepository googleRepository, IDatabaseUnitOfWork databaseUnitOfWork)
        {
            _googleRepository = googleRepository;
            _databaseUnitOfWork = databaseUnitOfWork;
        }

        public BookDto GetBook(string id)
        {
            var book = _googleRepository.GetBook(id);
            return book;
        }

        public IEnumerable<BookDto> FindBooks(string term)
        {
            var searchResult = _googleRepository.GetBooks(term);

            return searchResult;
        }

        public void Update<TData>(TData entity) where TData : OwnEntityAggregation
        {
            var databaseUnitOfWork = _databaseUnitOfWork.HardRemoveRepository<TData>();
            databaseUnitOfWork.Update(entity);
        }

        public void UpdateUser(User user)
        {
            _databaseUnitOfWork.UserRepository.Update(user);
            _databaseUnitOfWork.UserRepository.Save();
        }

        public User GetUser(string id)
        {
            return _databaseUnitOfWork.UserRepository.GetUser(id);
        }

        public void SafeRemove<TData>(TData entity) where TData : SafeRemoveAggregation
        {
            _databaseUnitOfWork.SafeRemoveRepository<TData>().Delete(entity.Id);
        }

        public void HardRemove<TData>(TData entity) where TData : OwnEntityAggregation
        {
            _databaseUnitOfWork.HardRemoveRepository<TData>().Delete(entity.Id);
        }

        public TData Get<TData>(int id) where TData : OwnEntityAggregation
        {
            return _databaseUnitOfWork.HardRemoveRepository<TData>().Get(id);
        }

        public IEnumerable<TData> Get<TData>(Expression<Func<TData, bool>> query) where TData : OwnEntityAggregation
        {
            return _databaseUnitOfWork.HardRemoveRepository<TData>().Get(query);
        }

        public void Save()
        {
            _databaseUnitOfWork.Save();
        }

        public void Insert<TData>(TData entity) where TData : OwnEntityAggregation
        {
            _databaseUnitOfWork.HardRemoveRepository<TData>().Insert(entity);
        }
    }
}
