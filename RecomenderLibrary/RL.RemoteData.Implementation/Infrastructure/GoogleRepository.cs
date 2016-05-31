using System.Collections.Generic;
using AutoMapper;
using Google.Apis.Books.v1;
using Google.Apis.Services;
using RL.RemoteData.Contract.Infrastructure;
using RL.RemoteData.Contract.RemoteModels;

namespace RL.RemoteData.Implementation.Infrastructure
{
    public class GoogleRepository : IGoogleRepository
    {
        private BooksService _service;

        public GoogleRepository()
        {
            InitService();
        }

        public BookDto GetBook(string id)
        {
            var volume = _service.Volumes.Get(id).Execute();
            return Mapper.Map<BookDto>(volume);
        }

        public IEnumerable<BookDto> GetBooks(string term, bool all = true)
        {
            var volumes = _service.Volumes.List(term).Execute();
            return Mapper.Map<IEnumerable<BookDto>>(volumes.Items);
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
