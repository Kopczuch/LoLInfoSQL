using LoLInfoSQL.Client.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoLInfoSQL.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DruzynyController : ControllerBase
    {
        private readonly lolinfoContext context;

        public DruzynyController(lolinfoContext context)
        {
            this.context = context;
        }

        //[HttpGet]

    }
}
