using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using RL.RemoteData.Contract.Infrastructure;

namespace RL.RemoteData.Implementation.Infrastructure
{
    public class GoogleRepository : IGoogleRepository
    {
        private BooksService _service;

        public Volume GetBook(string id)
        {
            InitService();
            return _service.Volumes.Get(id).Execute();
        }

        public Volumes GetBooks(string term, bool conditionOr, bool all = true)
        {
            var volumes = _service.Volumes.List(term).Execute();
            return volumes;
        }

        private void InitService()
        {
            if (_service == null)
            {
                _service = new BooksService(new BaseClientService.Initializer
                {
                    ApplicationName = "Recommender Library",
                    ApiKey = "AIzaSyAxrbWN4jv4QkxPg2qjz99H5oYPPCgU_Pk"
                });
            }
        }
    }
}
