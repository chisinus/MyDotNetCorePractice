using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MongoDBController : ControllerBase
    {
        [HttpGet]
        [Route("testmongodb")]
        public IActionResult TestMongoDB()
        {
            DatabaseService dbs = new DatabaseService();

            return Ok(dbs.TestMongoDB());
        }
    }
}
