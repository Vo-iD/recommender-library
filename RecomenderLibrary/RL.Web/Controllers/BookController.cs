using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using RL.DataProcessing.Contract.Infrastructure;
using RL.Entity.Own;
using RL.RemoteData.Contract.RemoteModels;
using RL.Web.Models;
using WebGrease.Css.Extensions;

namespace RL.Web.Controllers
{
    public class BookController : BaseController
    {
        public BookController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public ActionResult GetMyFavoriteBooks()
        {
            var user = CurrentUser;
            var books = new List<BookDto>();
            user.Books.ForEach(b =>
            {
                var book = UnitOfWork.GetBook(b.BookId);
                book.Mark = b.Mark;
                books.Add(book);
            });

            return View(books);
        }

        [HttpPost]
        public void AddToMyFavorites(FavoriteBookModel model)
        {
            var book = Mapper.Map<FavoriteBook>(model);
            var user = CurrentUser;
            book.User = user;
            user.Books.Add(book);
            UnitOfWork.UpdateUser(user);
        }

        [HttpPost]
        public void RemoveFromMyFavorite(string bookId)
        {
            var user = CurrentUser;
            var book = user.Books.FirstOrDefault(x => x.BookId == bookId);
            user.Books.Remove(book);
            UnitOfWork.UpdateUser(user);
        }

        [HttpPost]
        public void UpdateMyFavorite(FavoriteBookModel model)
        {
            var user = CurrentUser;
            var favoriteBook = user.Books.FirstOrDefault(x => x.BookId == model.BookId);
            if (favoriteBook != null)
            {
                favoriteBook.Mark = model.Mark;
            }
            else
            {
                var book = Mapper.Map<FavoriteBook>(model);
                book.User = user;
                user.Books.Add(book);
            }

            UnitOfWork.UpdateUser(user);
        }
    }
}