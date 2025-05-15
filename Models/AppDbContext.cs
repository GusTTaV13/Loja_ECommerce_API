using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Loja_ECommerce_API.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Endereco> Enderecos { get; set; }

    public virtual DbSet<ItensPedido> ItensPedidos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=GusTTaV13;Database=loja_ecommerce;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__02AA0785FEE1ACEE");

            entity.Property(e => e.IdCategoria).HasColumnName("ID_Categoria");
            entity.Property(e => e.Ativo).HasDefaultValue(true);
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nome).HasMaxLength(100);
        });

        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.HasKey(e => e.IdEndereco).HasName("PK__Endereco__FDCCCFA63BA297DF");

            entity.Property(e => e.IdEndereco).HasColumnName("ID_Endereco");
            entity.Property(e => e.Bairro).HasMaxLength(100);
            entity.Property(e => e.Cep)
                .HasMaxLength(20)
                .HasColumnName("CEP");
            entity.Property(e => e.Cidade).HasMaxLength(100);
            entity.Property(e => e.Complemento).HasMaxLength(50);
            entity.Property(e => e.Estado).HasMaxLength(2);
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Logradouro).HasMaxLength(255);
            entity.Property(e => e.Numero).HasMaxLength(10);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Enderecos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Enderecos__ID_Us__6FE99F9F");
        });

        modelBuilder.Entity<ItensPedido>(entity =>
        {
            entity.HasKey(e => e.IdItemPedido).HasName("PK__ItensPed__0CD22BF0F66D8E6F");

            entity.ToTable("ItensPedido");

            entity.Property(e => e.IdItemPedido).HasColumnName("ID_ItemPedido");
            entity.Property(e => e.IdPedido).HasColumnName("ID_Pedido");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.PrecoUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Subtotal)
                .HasComputedColumnSql("([Quantidade]*[PrecoUnitario])", true)
                .HasColumnType("decimal(21, 2)");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.ItensPedidos)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItensPedi__ID_Pe__01142BA1");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.ItensPedidos)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItensPedi__ID_Pr__02084FDA");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__Pedidos__FD7680701830273A");

            entity.Property(e => e.IdPedido).HasColumnName("ID_Pedido");
            entity.Property(e => e.DataPedido)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdEndereco).HasColumnName("ID_Endereco");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pendente");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdEnderecoNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdEndereco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedidos__ID_Ende__7E37BEF6");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedidos__ID_Usua__7D439ABD");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.IdProduto).HasName("PK__Produtos__525292A100D6E5C4");

            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.Ativo).HasDefaultValue(true);
            entity.Property(e => e.IdCategoria).HasColumnName("ID_Categoria");
            entity.Property(e => e.ImagemUrl)
                .HasMaxLength(255)
                .HasColumnName("ImagemURL");
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Preco).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Produtos__ID_Cat__787EE5A0");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__DE4431C5715E6F27");

            entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D10534F31FDFC0").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Senha).HasMaxLength(255);
            entity.Property(e => e.Telefone).HasMaxLength(20);
            entity.Property(e => e.TipoUsuario)
                .HasMaxLength(50)
                .HasDefaultValue("Cliente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
