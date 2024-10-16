using BibliotecaAPI.ORM;

namespace BibliotecaAPI.Model
{
    public class CategoriaDto
    {
        public string Nome { get; set; } = null!;

        public string Descricao { get; set; } = null!;

        public virtual ICollection<TbLivro> TbLivros { get; set; } = new List<TbLivro>();
    }
}
