﻿using System;
using System.Collections.Generic;

namespace BibliotecaAPI.ORM;

public partial class TbMembro
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Telefone { get; set; }

    public DateOnly DataCadastro { get; set; }

    public virtual ICollection<TbEmprestimo> TbEmprestimos { get; set; } = new List<TbEmprestimo>();

    public virtual ICollection<TbReserva> TbReservas { get; set; } = new List<TbReserva>();
}
