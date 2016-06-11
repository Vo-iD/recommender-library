using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RL.RemoteData.Contract.RemoteModels;

namespace RL.Business.Contract
{
    public interface IRecommenderCore
    {
        IEnumerable<BookDto> GetRecommendations(string userId);
    }
}
