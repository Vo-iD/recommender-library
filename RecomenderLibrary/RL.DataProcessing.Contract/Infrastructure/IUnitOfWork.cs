using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RL.Entity.Own;
using RL.RemoteData.Contract.RemoteModels;

namespace RL.DataProcessing.Contract.Infrastructure
{
    public interface IUnitOfWork
    {
        BookDto GetBook(string id);
        IEnumerable<BookDto> FindBooks(string term);
        void Insert<TData>(TData entity) where TData : OwnEntityAggregation;
        void Update<TData>(TData entity) where TData : OwnEntityAggregation;
        void UpdateUser(User user);
        User GetUser(string id);
        void SafeRemove<TData>(TData entity) where TData : SafeRemoveAggregation;
        void HardRemove<TData>(TData entity) where TData : OwnEntityAggregation;
        TData Get<TData>(int id) where TData : OwnEntityAggregation;
        IEnumerable<TData> Get<TData>(Expression<Func<TData, bool>> query) where TData : OwnEntityAggregation;
        void Save();
    }
}
