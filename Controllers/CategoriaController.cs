using BibliotecaAPI.Model;
using BibliotecaAPI.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaRepositorio _categoriaRepo;

        public CategoriaController(CategoriaRepositorio categoriaRepo)
        {
            _categoriaRepo = categoriaRepo;
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public ActionResult<List<Categoria>> GetAll()
        {
            var categorias = _categoriaRepo.GetAll();

            if (categorias == null || !categorias.Any())
            {
                return NotFound(new { Mensagem = "Nenhuma categoria encontrada." });
            }

            return Ok(categorias);
        }

        // GET: api/Categoria/{id}
        [HttpGet("{id}")]
        public ActionResult<Categoria> GetById(int id)
        {
            var categoria = _categoriaRepo.GetById(id);

            if (categoria == null)
            {
                return NotFound(new { Mensagem = "Categoria não encontrada." });
            }

            return Ok(categoria);
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public ActionResult<object> Post([FromForm] CategoriaDto novaCategoria)
        {
            var categoria = new Categoria
            {
                Nome = novaCategoria.Nome,
                Descricao = novaCategoria.Descricao
            };

            _categoriaRepo.Add(categoria);

            var resultado = new
            {
                Mensagem = "Categoria cadastrada com sucesso!",
                Nome = categoria.Nome,
                Descricao = categoria.Descricao
            };

            return Ok(resultado);
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public ActionResult<object> Put(int id, [FromForm] CategoriaDto categoriaAtualizada)
        {
            var categoriaExistente = _categoriaRepo.GetById(id);

            if (categoriaExistente == null)
            {
                return NotFound(new { Mensagem = "Categoria não encontrada." });
            }

            categoriaExistente.Nome = categoriaAtualizada.Nome;
            categoriaExistente.Descricao = categoriaAtualizada.Descricao;

            _categoriaRepo.Update(categoriaExistente);

            var resultado = new
            {
                Mensagem = "Categoria atualizada com sucesso!",
                Nome = categoriaExistente.Nome,
                Descricao = categoriaExistente.Descricao
            };

            return Ok(resultado);
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var categoriaExistente = _categoriaRepo.GetById(id);

            if (categoriaExistente == null)
            {
                return NotFound(new { Mensagem = "Categoria não encontrada." });
            }

            _categoriaRepo.Delete(id);

            var resultado = new
            {
                Mensagem = "Categoria excluída com sucesso!",
                Nome = categoriaExistente.Nome,
                Descricao = categoriaExistente.Descricao
            };

            return Ok(resultado);
        }
    }
}
