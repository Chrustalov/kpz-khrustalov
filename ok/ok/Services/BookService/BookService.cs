using ok.Models;
using SQLite;
using ok.Services.Database;

namespace ok.Services.BookService {
  public class BookService : IBookRepository {
    public SQLiteAsyncConnection _database;

    public BookService() {
      _ = Task.Run(async () =>
        {
          _database = await ConnectionService.GetDatabaseConnectionAsync();
        });
    }

    public async Task<bool> AddUpdateBookAsync(Book book) {
      if (book.Id > 0) {
        await _database.UpdateAsync(book);
      } else {
        await _database.InsertAsync(book);
      }

      return await Task.FromResult(true);
    }
    public async Task<bool> DeleteBookAsync(int bookId) {
      await _database.DeleteAsync<Book>(bookId);
      return await Task.FromResult(true);
    }
    public async Task<IEnumerable<Book>> getBooksAsync() {
      return await Task.FromResult(await _database.Table<Book>().ToListAsync());
    }
    public async Task<Book> GetBookAsync(int bookId) {
      return await _database.Table<Book>().Where(p => p.Id == bookId).FirstOrDefaultAsync();
    }
  }
}
