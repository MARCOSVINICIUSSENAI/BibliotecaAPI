using BibliotecaAPI.Model;
using BibliotecaAPI.ORM;

namespace BibliotecaAPI.Repositorio
{
    public class CategoriaRepositorio
    {
        private BdBibliotecaContext _context;
        public CategoriaRepositorio(BdBibliotecaContext context)
        {
            _context = context;
        }
        public void Add(Categoria categoria, IFormFile documento)
        {
            // Verifica se uma foto foi enviada
            byte[] documentoBytes = null;
            if (documento != null && documento.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    documento.CopyTo(memoryStream);
                    documentoBytes = memoryStream.ToArray();
                }
            }

            // Cria uma nova entidade do tipo tbCliente a partir do objeto Funcionario recebido
            var tbCategoria = new TbCategoria()
            {
                Nome = categoria.Nome,
               Descricao = categoria.Descricao,
              
            };

            // Adiciona a entidade ao contexto
            _context.TbCategorias.Add(tbCategoria);

            // Salva as mudanças no banco de dados
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbCategoria = _context.TbCategorias.FirstOrDefault(c => c.Id == id);

            // Verifica se a entidade foi encontrada
            if (tbCategoria != null)
            {
                // Remove a entidade do contexto
                _context.TbCategorias.Remove(tbCategoria);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Funcionário não encontrado.");
            }
        }
        public List<Categoria> GetAll()
        {
            List<Categoria> listCli = new List<Categoria>();

            var listTb = _context.TbCategorias.ToList();

            foreach (var item in listTb)
            {
                var cliente = new Categoria
                {
                    Nome = item.Nome,
                    Descricao = item.Descricao
                };

                listCli.Add(cliente);
            }

            return listCli;
        }
        public Categoria GetById(int id)
        {
            // Busca o cliente pelo ID no banco de dados
            var item = _context.TbCategorias.FirstOrDefault(c => c.Id == id);

            // Verifica se o cliente foi encontrado
            if (item == null)
            {
                return null; // Retorna null se não encontrar
            }

            // Mapeia o objeto encontrado para a classe Funcionario
            var cliente = new Categoria
            {
                Nome = item.Nome,
                Descricao = item.Descricao,
            };

            return cliente; // Retorna o cliente encontrado
        }
        public void Update(Categoria categoria)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbCategoria = _context.TbCategorias.FirstOrDefault(c => c.Id == categoria.Id);

            // Verifica se a entidade foi encontrada
            if (tbCategoria != null)
            {
                // Atualiza os campos da entidade com os valores do objeto Funcionario recebido
                tbCategoria.Nome = categoria.Nome;
                tbCategoria.Descricao = categoria.Descricao;

                // Atualiza as informações no contexto
                _context.TbCategorias.Update(tbCategoria);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
                else
            {
                throw new Exception("Funcionário não encontrado.");
            }
        }
    }
}
