using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class InfoController : Controller
    {
        // GET api/status
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "WebAPI up and running" };
        }
    }
}
