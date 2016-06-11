using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RL.Business.Contract;
using RL.DataProcessing.Contract.Infrastructure;
using RL.RemoteData.Contract.RemoteModels;

namespace RL.Web.Controllers
{
    public class RecommendationController : BaseController
    {
        private readonly IRecommenderCore _recommenderCore;
        public RecommendationController(IUnitOfWork unitOfWork, IRecommenderCore recommenderCore) : base(unitOfWork)
        {
            _recommenderCore = recommenderCore;
        }

        [HttpGet]
        public ActionResult GetMyRecommendations()
        {
            var reccomendations = _recommenderCore.GetRecommendations(User.Identity.GetUserId());
            return View(reccomendations);
        }

        //private IEnumerable<BookDto> GetBookList()
        //{
        //    var books = new List<BookDto>();
        //    var ids = new List<string>
        //    {
        //        "WLjpMgEACAAJ",
        //        "HzQXlPS48PQC",
        //        "lG8dzWV28jsC",
        //        "emNF_wqvNSwC",
        //        "jqoFnG0-qt8C",
        //        "CKRrAAAAMAAJ"
        //    };

        //    ids.ForEach(id => books.Add(_unitOfWork.GetBook(id)));

        //    return books;
        //}
    }
}