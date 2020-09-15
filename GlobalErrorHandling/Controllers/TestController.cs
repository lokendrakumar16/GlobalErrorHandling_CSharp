using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlobalErrorHandling.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new ArgumentException("Error from test contoller");
        }
    }
}
