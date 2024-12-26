using ApiChallenge.Models;

namespace ApiChallenge.Services
{
    public interface IBooksService
    {
        ICollection<Book> GetBook();
        ICollection<Book> GetBookByIdAndTitre(int id, string titre);
        Book GetBookById(int id);
        void Add(Book book);
        void Remove(int id);
        void Update(Book book);
        void AddBook(Book book);
    }
}
