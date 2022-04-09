using MongoDB.Driver;
using MyWebApi.Models;

namespace MyWebApi.Services
{
    public interface IMyMongoDBService
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBook(string id);
        Task<string> InsertBook(string bookName, decimal price, string category, string author, string publishDate);
        Task<UpdateResult> UpdateBookName(string id, string bookName);
        Task<DeleteResult> DeleteBook(string id);
    }
}
