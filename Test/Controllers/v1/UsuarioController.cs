using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;

namespace Test.v1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public UsuarioController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Este endpoint deve consultar as interessadas cadastradas
        /// </summary>
        /// <returns>
        /// Retorna a lista com todas as interessadas cadastradas
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> ConsultarTodos()
        {
            var usuarios = await _appDbContext.Usuarios
                .AsNoTracking()
                .ToListAsync();

            return Ok(usuarios);
        }

        /// <summary>
        /// Este endpoint deve consultar o cadastro através do nome e e-mail
        /// </summary>
        /// <returns>
        /// Retorna 2xx caso sucesso
        /// Retorna 4xx caso erro
        /// </returns>
        [HttpGet]
        [Route("consultar/{nome}/{email}")]
        public IActionResult ConsultarPorEmail(string nome, string email)
        {
            var usuario = _appDbContext.Usuarios
                .Where(m => m.Nome == nome && m.Email == email)
                .AsNoTracking()
                .FirstOrDefault();

              return Ok(usuario);
        }

        /// <summary>
        ///  Este endpoint deve realizar a inclusao
        /// </summary>
        /// <returns>
        /// Retorna 2xx caso sucesso
        /// Retorna 4xx caso erro
        /// </returns>
        [HttpPost]
        [Route("incluir")]
        public IActionResult Adicionar([FromBody]Usuario model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos");

            var usuarioExiste = _appDbContext.Usuarios.Any(m => m.Email == model.Email);
            if (usuarioExiste)
                return BadRequest("E-mail já cadastrado");

            var usuario = new Usuario
            {
                Nome = model.Nome,
                Email = model.Email
            };

            _appDbContext.Usuarios.Add(usuario);
            _appDbContext.SaveChanges();

            return Ok("Dados cadastrados com sucesso!");
        }

        /// <summary>
        /// Este endpoint deve atualizar os dados cadastrados
        /// </summary>
        /// <returns>
        /// Retorna 2xx caso sucesso
        /// Retorna 4xx caso erro
        /// </returns>
        [HttpPut]
        [Route("atualizar")]
        public IActionResult Atualizar([FromBody]Usuario model)
        {
            if(!ModelState.IsValid)
               return BadRequest("Dados inválidos");

            var usuario = _appDbContext.Usuarios.Where(m => m.Id == model.Id).FirstOrDefault();
            if (usuario == null)
                return BadRequest("Usuário não encontrado");

            usuario.Email = model.Email;
            usuario.Nome = model.Nome;

            _appDbContext.SaveChanges();

            return Ok("Dados atualizados com sucesso!");
        }

        /// <summary>
        /// Este endpoint deve excluir um cadastro através do e-mail informado
        /// </summary>
        /// <returns>
        /// Retorna 2xx caso sucesso
        /// Retorna 4xx caso erro
        /// </returns>
        [HttpDelete]
        [Route("excluir/{email}")]
        public IActionResult Excluir(string email)
        {
            var usuario = _appDbContext.Usuarios.Where(m =>m.Email == email).FirstOrDefault();
            if(usuario == null)
                return BadRequest("Usuário não encontrado");

            _appDbContext.Usuarios.Remove(usuario);
            _appDbContext.SaveChanges();

            return Ok("Usuário excluído com sucesso");
        }
    }
}