using ApiChallenge.Models;
using ApiChallenge.Services;
using Xunit;

namespace ApiChallenge.Tests
{
    public class BookServiceTests
    {
        private readonly IBooksService _booksService;
        private object _carSrvice;
        private BooksService _BooksService;

        public BookServiceTests()
        {
            _booksService = new BooksService();
        }
        [Fact]
        public void AddBook_ShouldAddBook()
        {
            var book = new Book
            {
                titre = "Test",
                auteur = "auteur",
                isbn = "1234567",
                prix = 40.4 
            };
            _booksService.AddBook(book);
            var result = _booksService.GetBookById(1);
            Assert.NotNull(result);
            Assert.Equal("Teste", result.titre);

        }
    }
}
