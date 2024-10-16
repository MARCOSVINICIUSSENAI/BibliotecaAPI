using BibliotecaAPI.ORM;

namespace BibliotecaAPI.Model
{
    public class MembroDto
    {
        public string Nome { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int Telefone { get; set; }

        public DateOnly DataCadastro { get; set; }

        public virtual ICollection<TbEmprestimo> TbEmprestimos { get; set; } = new List<TbEmprestimo>();

        public virtual ICollection<TbReserva> TbReservas { get; set; } = new List<TbReserva>();
    }
}
