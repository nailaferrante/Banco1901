using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using projetoBanco1901.Models;

namespace projetoBanco1901.Controllers
{
    [Route("api/[controller]")]
    public class PostagemController : Controller
    {
        Postagem postagem = new Postagem();
        DAOPostagem dao = new DAOPostagem();

        [HttpGet]
        public IEnumerable<Postagem> Get()
        {
            return dao.Listar();
        }

        [HttpGet("{id}")]
        public Postagem Get(int id)
        {
            return dao.Listar().Where(x => x.Idpostagem == id).FirstOrDefault();
        }
        [HttpPost]
         public IActionResult Post([FromBody]Postagem postagem)
         {
             dao.Cadastrar(postagem);
             return CreatedAtRoute("NovaPostagem", new{id=postagem.Idpostagem},postagem);

         }
    }
}
