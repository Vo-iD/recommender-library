using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RL.DataProcessing.Contract.Infrastructure;
using RL.RemoteData.Contract.RemoteModels;

namespace RL.Web.Controllers
{
    public class RecommendationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public RecommendationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetMyRecommendations()
        {
            return View(GetBookList());
        }

        private IEnumerable<BookDto> GetBookList()
        {
            var books = new List<BookDto>();
            var ids = new List<string>
            {
                "WLjpMgEACAAJ",
                "HzQXlPS48PQC",
                "lG8dzWV28jsC",
                "emNF_wqvNSwC",
                "jqoFnG0-qt8C",
                "CKRrAAAAMAAJ"
            };

            ids.ForEach(id => books.Add(_unitOfWork.GetBook(id)));

            return books;
        }
    }
}