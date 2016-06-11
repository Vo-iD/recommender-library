using System.Collections.Generic;
using System.Web.Mvc;
using RL.DataProcessing.Contract.Infrastructure;
using RL.OwnData.Contract.Infrastructure;
using RL.RemoteData.Contract.RemoteModels;

namespace RL.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Book
        [HttpGet]
        public ActionResult GetMyFavoriteBooks()
        {
            var books = GetBookList();
            return View(books);
        }

        private IEnumerable<BookDto> GetBookList()
        {
            var books = new List<BookDto>();
            var ids = new List<string>
            {
                "yxv1LK5gyV4C",
                "y3CyRurE7P4C",
                "qUI8pbpCNJUC",
                "XvuoCwAAQBAJ"
            };

            ids.ForEach(id => books.Add(_unitOfWork.GetBook(id)));

            return books;
        }
    }
}