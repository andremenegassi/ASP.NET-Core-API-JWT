using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExemploWebAPIJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class TodoController : ControllerBase
    {
        List<Models.TodoItem> _dados = new List<Models.TodoItem>() {
            new Models.TodoItem(1, "Todo Item 1", true),
            new Models.TodoItem(2, "Todo Item 2", true),
            new Models.TodoItem(3, "Todo Item 3", true),
            new Models.TodoItem(4, "Todo Item 4", false),
            new Models.TodoItem(5, "Todo Item 5", false),
            new Models.TodoItem(6, "Todo Item 6", true)
        };

        [HttpGet]
        public IEnumerable<Models.TodoItem> Get()
        {
            return _dados;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Models.TodoItem t = _dados.Where(item => item.Id == id).FirstOrDefault();

            if (t != null)
                return Ok(t);

            return NotFound();
        }

        [HttpGet("[action]/{status}")]
        //ou [HttpGet("status/{status}")]
        public IActionResult GetByStatus(bool status)
        {
            //http://localhost:60491/api/todo/status/false
            IEnumerable<Models.TodoItem> items = _dados.Where(i => i.Pendente == status).ToList();

            if (items.Count() > 0)
                return Ok(items);

            return NotFound();
        }

        //ou

        [HttpGet]
        [Route("GetByStatus2/{status}")]
        public IActionResult GetByStatus2(bool status)
        {
            //http://localhost:60491/api/todo/GetAtivos/false
            IEnumerable<Models.TodoItem> items = _dados.Where(i => i.Pendente == status).ToList();

            if (items.Count() > 0)
                return Ok(items);

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post(Models.TodoItem newItem)
        {
            //add at list...

            return Ok(newItem);

        }

        [HttpPost("[action]")]
        public IActionResult Post2([FromBody] Dictionary<string, string> dados)
        {
            //add at list...

            return Ok(dados);

        }


        [HttpPut]
        public IActionResult Put(Models.TodoItem updateItem)
        {
            //update item at list...

            return Ok(updateItem);

        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            //delete at list...

            return Ok(id);

        }


        [HttpDelete]
        public IActionResult Delete2([FromBody]  Dictionary<string, string> dados)
        {
            //delete at list...

            return Ok(dados);

        }







    }
}