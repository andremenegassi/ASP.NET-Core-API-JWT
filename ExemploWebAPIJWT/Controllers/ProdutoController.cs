using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExemploWebAPIJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        List<Models.Produto> _dados = new List<Models.Produto>() {
            new Models.Produto(1, "Produto 1", 1111, 1),
            new Models.Produto(2, "Produto 2", 2222, 2),
            new Models.Produto(3, "Produto 3", 3333, 3),
            new Models.Produto(4, "Produto 4", 4444, 4),
            new Models.Produto(5, "Produto 5", 5555, 5),
            new Models.Produto(6, "Produto 6", 6666, 6)
        };

        [HttpGet]
        public IEnumerable<Models.Produto> Get()
        {
            return _dados;
        }

    }
}