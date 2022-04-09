using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
