using Google.Apis.Books.v1.Data;

namespace RL.RemoteData.Contract.Infrastructure
{
    public interface IGoogleRepository
    {
        Volume GetBook(string id);
        Volumes GetBooks(string term, bool conditionOr, bool all = true);
    }
}
