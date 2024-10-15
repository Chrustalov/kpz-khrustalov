using SQLite;
using ok.Models;

namespace ok.Services.Database;

public static class ConnectionService
{
    private static SQLiteAsyncConnection? _database;

    public static async Task<SQLiteAsyncConnection> GetDatabaseConnectionAsync()
    {
        if (_database != null) 
        {
          return _database;
        }

        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "book.db3");
        _database = new SQLiteAsyncConnection(dbPath);
        await _database.CreateTableAsync<Book>();
        return _database;
    }
}
