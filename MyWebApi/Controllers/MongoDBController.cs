using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyWebApi.Models;
using MyWebApi.Services;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MongoDBController : ControllerBase
    {
        MyMongoDBService _MyMongoDBService { get; set; }

        public MongoDBController(MyMongoDBService myMongoDBService)
        {
            _MyMongoDBService = myMongoDBService;
        }

        [HttpGet]
        [Route("getallbooks")]
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _MyMongoDBService.GetAllBooks();
        }

        [HttpGet]
        [Route("getbook")]
        public async Task<Book> GetBook(string id)
        {
            return await _MyMongoDBService.GetBook(id);
        }

        [HttpPost]
        [Route("insertbook")]
        //in Program.cs
        //  builder.Services.AddControllers()
        //     .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
        public async Task<string> InsertBook(Book book)
        {
            return await _MyMongoDBService.InsertBook(book.BookName, book.Price, book.Category, book.Author, book.PublishDate);
        }

        [HttpPatch]
        [Route("updatebookname")]
        public async Task<string> UpdateBookName(string id, string newBookName)
        {
            var result = await _MyMongoDBService.UpdateBookName(id, newBookName);

            return (result.ModifiedCount == 1) ? "Successful" : "Failed";
        }
        // UpdateResult hangs Swagger
        //public async Task<UpdateResult> UpdateBookName(string id, string newBookName)
        //{
        //    return await _MyMongoDBService.UpdateBookName(id, newBookName);
        //}

        [HttpDelete]
        [Route("deletebook")]
        public async Task<long> DeleteBook(string id)
        {
            return (await _MyMongoDBService.DeleteBook(id)).DeletedCount;
        }
    }
}
