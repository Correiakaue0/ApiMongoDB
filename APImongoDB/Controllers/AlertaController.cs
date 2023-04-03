using APImongoDB.Models;
using APImongoDB.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace APImongoDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlertaController : ControllerBase
    {
        private readonly ILogger<AlertaController> _logger;
        private readonly IRepositorioAlerta _RepositorioAlerta;

        public AlertaController(ILogger<AlertaController> logger, IRepositorioAlerta repAlerta)
        {
            _logger = logger;
            _RepositorioAlerta = repAlerta;
        }

        [HttpGet]
        public IEnumerable<Alerta> Get()
        {
            return _RepositorioAlerta.Listar();
        }

        [HttpPost]
        public void Post(Alerta alerta)
        {
            _RepositorioAlerta.Persistir(alerta);
        }

    }
}
