using APImongoDB.Models;
using APImongoDB.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace APImongoDB.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IRepositorioUsuario _RepositorioUsuario;
        public UsuarioController(ILogger<UsuarioController> logger, IRepositorioUsuario repUsuario)
        {
            _logger = logger;
            _RepositorioUsuario = repUsuario;
        }

        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return _RepositorioUsuario.Listar();
        }

        [HttpGet("{id}")]
        public Usuario GetForId(int id)
        {
            return _RepositorioUsuario.ObterPorId(id);
        }

        [HttpPost]
        public void Post([FromBody] Usuario usuario)
        {
            _RepositorioUsuario.Persistir(usuario);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Usuario usuario)
        {
            _RepositorioUsuario.Atualizar(id, usuario);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _RepositorioUsuario.Excluir(id);
        }
    }
}
