using Google.Apis.Books.v1;
using Google.Apis.Services;

namespace RL.RemoteData.Implementation
{
    public class TestBooks
    {
        public void Test()
        {
            var service = new BooksService(new BaseClientService.Initializer
            {
                ApplicationName = "Recommender Library",
                ApiKey = "AIzaSyAxrbWN4jv4QkxPg2qjz99H5oYPPCgU_Pk"
            });
            var s = service.Volumes.List("PublishedDate=1990");
            var result = s.Execute();
            var one = service.Volumes.Get("buc0AAAAMAAJ").Execute();
        }
    }
}