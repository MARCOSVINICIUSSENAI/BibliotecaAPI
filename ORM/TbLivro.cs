using System;
using System.Collections.Generic;

namespace BibliotecaAPI.ORM;

public partial class TbLivro
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Autor { get; set; } = null!;

    public string AnoPublicacao { get; set; } = null!;

    public int FkCategoria { get; set; }

    public byte[] Disponibilidade { get; set; } = null!;

    public virtual TbCategoria FkCategoriaNavigation { get; set; } = null!;

    public virtual ICollection<TbEmprestimo> TbEmprestimos { get; set; } = new List<TbEmprestimo>();

    public virtual ICollection<TbReserva> TbReservas { get; set; } = new List<TbReserva>();
}
