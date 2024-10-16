using BibliotecaAPI.ORM;

namespace BibliotecaAPI.Model
{
    public class ReservaDto
    {
        public string DataReserva { get; set; } = null!;

        public int FkMembro { get; set; }

        public int FkLivro { get; set; }

        public virtual TbLivro FkLivroNavigation { get; set; } = null!;

        public virtual TbMembro FkMembroNavigation { get; set; } = null!;
    }
}
