using BibliotecaAPI.ORM;

namespace BibliotecaAPI.Model
{
    public class Livro
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public string Autor { get; set; } = null!;

        public string AnoPublicacao { get; set; } = null!;

        public int FkCategoria { get; set; }

        public byte[] Disponibilidade { get; set; } = null!;
    }
}
