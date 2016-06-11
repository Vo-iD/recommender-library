using System;
using System.Collections.Generic;
using RL.Business.Contract;
using RL.DataProcessing.Contract.Infrastructure;
using RL.RemoteData.Contract.RemoteModels;

namespace RL.Business.Iimplementation
{
    public class RecommenderCore : IRecommenderCore
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecommenderCore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<BookDto> GetRecommendations(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
