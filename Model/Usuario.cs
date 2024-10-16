namespace BibliotecaAPI.Model
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Login { get; set; } = null!;

        public string Senha { get; set; } = null!;
    }
}
