using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Services;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        IHelloWorldService helloWorldService; 

        public HelloWorldController( IHelloWorldService helloWorld)
        {
            helloWorldService = helloWorld;
        }

        public IActionResult Get()
        {
            return Ok(helloWorldService.GetHelloWorld());
        }
    }
}