using ok.Models;

namespace ok.Services.BookService {
  public interface IBookRepository {
    Task<bool> AddUpdateBookAsync(Book book);
    Task<bool> DeleteBookAsync(int bookId);
    Task<Book> GetBookAsync(int bookId);
    Task<IEnumerable<Book>> getBooksAsync();
  }
}
