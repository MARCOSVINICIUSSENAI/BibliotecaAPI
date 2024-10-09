namespace BibliotecaAPI.Model
{
    public class LivroDto
    {
        public string Titulo { get; set; } = null!;

        public string Autor { get; set; } = null!;

        public string AnoPublicacao { get; set; } = null!;

        public int FkCategoria { get; set; }

    }
}
