using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.ORM;

public partial class BdBibliotecaContext : DbContext
{
    public BdBibliotecaContext()
    {
    }

    public BdBibliotecaContext(DbContextOptions<BdBibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCategoria> TbCategorias { get; set; }

    public virtual DbSet<TbEmprestimo> TbEmprestimos { get; set; }

    public virtual DbSet<TbFuncionario> TbFuncionarios { get; set; }

    public virtual DbSet<TbLivro> TbLivros { get; set; }

    public virtual DbSet<TbMembro> TbMembros { get; set; }

    public virtual DbSet<TbReserva> TbReservas { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAB205_10\\SQLEXPRESS;Database=Bd_Biblioteca;User Id=admin;Password=admin;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCategoria>(entity =>
        {
            entity.ToTable("TB_CATEGORIAS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<TbEmprestimo>(entity =>
        {
            entity.ToTable("TB_EMPRESTIMOS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataDevolucao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dataDevolucao");
            entity.Property(e => e.DataEmprestimo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dataEmprestimo");
            entity.Property(e => e.FkLivro).HasColumnName("fk_livro");
            entity.Property(e => e.FkMembro).HasColumnName("fk_membro");

            entity.HasOne(d => d.FkLivroNavigation).WithMany(p => p.TbEmprestimos)
                .HasForeignKey(d => d.FkLivro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_EMPRESTIMOS_TB_LIVROS");

            entity.HasOne(d => d.FkMembroNavigation).WithMany(p => p.TbEmprestimos)
                .HasForeignKey(d => d.FkMembro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_EMPRESTIMOS_TB_MEMBROS");
        });

        modelBuilder.Entity<TbFuncionario>(entity =>
        {
            entity.ToTable("TB_FUNCIONARIO");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cargo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cargo");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Telefone).HasColumnName("telefone");
        });

        modelBuilder.Entity<TbLivro>(entity =>
        {
            entity.ToTable("TB_LIVROS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnoPublicacao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("anoPublicacao");
            entity.Property(e => e.Autor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("autor");
            entity.Property(e => e.Disponibilidade)
                .HasMaxLength(50)
                .HasColumnName("disponibilidade");
            entity.Property(e => e.FkCategoria).HasColumnName("fk_categoria");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.FkCategoriaNavigation).WithMany(p => p.TbLivros)
                .HasForeignKey(d => d.FkCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_LIVROS_TB_CATEGORIAS");
        });

        modelBuilder.Entity<TbMembro>(entity =>
        {
            entity.ToTable("TB_MEMBROS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataCadastro).HasColumnName("dataCadastro");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Telefone).HasColumnName("telefone");
        });

        modelBuilder.Entity<TbReserva>(entity =>
        {
            entity.ToTable("TB_RESERVAS");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DataReserva)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dataReserva");
            entity.Property(e => e.FkLivro).HasColumnName("fk_livro");
            entity.Property(e => e.FkMembro).HasColumnName("fk_membro");

            entity.HasOne(d => d.FkLivroNavigation).WithMany(p => p.TbReservas)
                .HasForeignKey(d => d.FkLivro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_RESERVAS_TB_LIVROS");

            entity.HasOne(d => d.FkMembroNavigation).WithMany(p => p.TbReservas)
                .HasForeignKey(d => d.FkMembro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_RESERVAS_TB_MEMBROS");
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.ToTable("TB_USUARIO");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Senha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("senha");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
