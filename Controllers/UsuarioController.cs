using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using projetoBanco1901.Models;

namespace projetoBanco1901.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        Usuario usuario = new Usuario();
        DAOUsuario dao = new DAOUsuario();

        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return dao.Listar();
        }

        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            return dao.Listar().Where(x => x.Idusuario == id).FirstOrDefault();
        }
        // [HttpPost]
        // public IActionResult Post([FromBody]Usuario usuario)
        // {
        //     dao.Cadastrar(usuario);
        //     return CreatedAtRoute("CidadeAtual", new{id=cidades.Id},cidades);

        // }
    }
}
