using System;
using System.Linq;
using System.Web.Mvc;
using RL.DataProcessing.Contract.Infrastructure;

namespace RL.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var term = RandomString(1);
            var books = _unitOfWork.FindBooks(term);
            return View(books);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Search(string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                return RedirectToAction("Index");
            }

            var books = _unitOfWork.FindBooks(term);
            return View(books);
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}