using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_3_OOP_MAUI
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            string dbPath = Path.Combine(
                FileSystem.AppDataDirectory,
                "books.db");

            _database = new SQLiteAsyncConnection(dbPath);

            _database.CreateTableAsync<Book>().Wait();
        }

        public Task<List<Book>> GetBooksAsync()
        {
            return _database.Table<Book>().ToListAsync();
        }

        public Task<int> SaveBookAsync(Book book)
        {
            if (book.Id != 0)
                return _database.UpdateAsync(book);

            return _database.InsertAsync(book);
        }

        public Task<int> DeleteBookAsync(Book book)
        {
            return _database.DeleteAsync(book);
        }
    }
}
