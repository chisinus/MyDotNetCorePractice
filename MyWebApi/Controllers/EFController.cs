using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EFController : ControllerBase
    {
        private IEFService service;

        public EFController(IEFService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("testget")]
        public IActionResult TestGet()
        {
            return Ok(service.TestGet());
        }

        [HttpGet]
        [Route("testinsert")]
        public IActionResult TestInsert()
        {
            return Ok(service.TestInsert("new company"));
        }

        [HttpGet]
        [Route("testdelete")]
        public IActionResult TestDelete()
        {
            return Ok(service.TestDelete());
        }

        [HttpGet]
        [Route("testupdate")]
        public IActionResult TestUpdate()
        {
            return Ok(service.TestUpdate());
        }

        [HttpPost]
        [Route("testpostinswagger")]
        public IActionResult TestPostInSwagger(string username, string password)
        {
            return Ok();
        }
    }
}
