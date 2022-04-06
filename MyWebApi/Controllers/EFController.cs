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
        public async Task<IEnumerable<string>> TestGet()
        {
            return await Task.FromResult(service.TestGet());
        }

        [HttpGet]
        [Route("testinsert")]
        public async Task<string> TestInsert()
        {
            return await service.TestInsert("new company");
        }

        [HttpGet]
        [Route("testdelete")]
        public async Task<string> TestDelete()
        {
            return await service.TestDelete();
        }

        [HttpGet]
        [Route("testupdate")]
        public async Task<string> TestUpdate()
        {
            return await service.TestUpdate();
        }

        [HttpPost]
        [Route("testpostinswagger")]
        public IActionResult TestPostInSwagger(string username, string password)
        {
            // a change to test notification.
            return Ok();
        }
    }
}
