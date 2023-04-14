using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareaController : ControllerBase
    {
        ITareaService TareaService;

        public TareaController(ITareaService ITareaService)
        {
            TareaService = ITareaService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(TareaService.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] Tarea Tarea)
        {
            TareaService.Save(Tarea);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id,[FromBody] Tarea Tarea)
        {
            TareaService.Update(id,Tarea);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id,[FromBody] Tarea Tarea)
        {
            TareaService.Delete(id,Tarea);
            return Ok();
        }
    }
}