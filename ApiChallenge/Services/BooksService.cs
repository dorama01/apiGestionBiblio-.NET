using ApiChallenge.Models;
using System.Diagnostics.Metrics;

namespace ApiChallenge.Services
{
    public class BooksService : IBooksService
    {
        public ICollection<Book> Books;
        public BooksService()
        {
            this.Books = new List<Book>();
        }

        public ICollection<Book> GetBook() => this.Books;

        public Book GetBookById(int id) => this.Books.FirstOrDefault(b => b.id == id);
        public ICollection<Book> GetBookByIdAndTitre(int id, string titre)
        {
            return this.Books.Where(b => b.id == id && b.titre == titre).ToList();
        }

        public void Add(Book book)
        {
            this.Books.Add(book);
        }

        public void Remove(int id)
        {
            Book book = GetBookById(id);
            if (book != null)
            {
                this.Books.Remove(book);
            }
        }
        public void Update(Book book)
        {
            Book exitedBook = GetBookById(book.id);
            if (exitedBook != null)
            {
                exitedBook.titre = book.titre;
                exitedBook.auteur = book.auteur;
                exitedBook.isbn = book.isbn;
                exitedBook.prix = book.prix;
            }
        }

        public void AddBook(Book book)
        {
            throw new NotImplementedException();
        }
    }

}
