using System.Collections.Generic;
using System.Linq;
using RL.Business.Contract;
using RL.DataProcessing.Contract.Infrastructure;
using RL.RemoteData.Contract.RemoteModels;

namespace RL.Business.Iimplementation
{
    public class RecommenderCore : IRecommenderCore
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecommenderCore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<BookDto> GetRecommendations(string userId, int count = 10)
        {
            var user = _unitOfWork.GetUser(userId);
            var importantBooks = user.Books.OrderByDescending(x => x.Mark).Take(20);
            var booksFromGoogle = new List<BookDto>();
            foreach (var bookMark in importantBooks)
            {
                var book = _unitOfWork.GetBook(bookMark.BookId);
                book.Mark = bookMark.Mark;
                booksFromGoogle.Add(book);
            }

            var categoryMatrix = GetCategoryMatrix(booksFromGoogle);
            var authorMatrix = GetAuthorMatrix(booksFromGoogle);

            var commonMatrix = GetCommonMatrix(new List<IDictionary<string, int?>>
            {
                categoryMatrix,
                authorMatrix
            });

            var list = new List<BookDto>();
            foreach (var searchTerm in commonMatrix)
            {
                var books = _unitOfWork.FindBooks(searchTerm.Key, count/4).ToList();
                foreach (var favoriteBook in user.Books)
                {
                    books.Remove(books.FirstOrDefault(x => x.Id == favoriteBook.BookId));
                }

                list.AddRange(books);
                if (list.Count >= count)
                {
                    break;
                }
            }

            return list;
        }

        private IDictionary<string, int?> GetCommonMatrix(IEnumerable<IDictionary<string, int?>> matrixes)
        {
            var commonMatrix = new Dictionary<string, int?>();
            commonMatrix = matrixes.Aggregate(commonMatrix,
                (current, matrix) => current.Concat(matrix).ToDictionary(x => x.Key, x => x.Value));

            commonMatrix = commonMatrix.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return commonMatrix;
        }

        private IDictionary<string, int?> GetCategoryMatrix(IEnumerable<BookDto> books)
        {
            var matrix = new Dictionary<string, int?>();

            var categories = new List<string>();
            foreach (var bookDto in books)
            {
                categories.AddRange(bookDto.Categories);
            }

            categories = categories.Distinct().ToList();

            foreach (var category in categories)
            {
                var marksWithThisCategory = books.Where(x => x.Categories.Contains(category)).Sum(b => b.Mark);
                matrix.Add(category, marksWithThisCategory);
            }

            return matrix;
        }

        private IDictionary<string, int?> GetAuthorMatrix(IEnumerable<BookDto> books)
        {
            var matrix = new Dictionary<string, int?>();

            var authors = new List<string>();
            foreach (var bookDto in books)
            {
                authors.AddRange(bookDto.Authors);
            }

            authors = authors.Distinct().ToList();

            foreach (var author in authors)
            {
                var markWithThisAuthor = books.Where(x => x.Authors.Contains(author)).Sum(b => b.Mark);
                matrix.Add(author, markWithThisAuthor);
            }

            return matrix;
        }
    }
}
