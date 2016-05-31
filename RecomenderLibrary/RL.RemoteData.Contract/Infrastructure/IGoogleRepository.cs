using System.Collections.Generic;
using RL.RemoteData.Contract.RemoteModels;

namespace RL.RemoteData.Contract.Infrastructure
{
    public interface IGoogleRepository
    {
        BookDto GetBook(string id);
        IEnumerable<BookDto> GetBooks(string term, bool all = true);
    }
}
