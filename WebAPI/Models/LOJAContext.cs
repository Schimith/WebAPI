using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAPI.Models
{
    public partial class LOJAContext : DbContext
    {
        public LOJAContext()
        {
        }

        public LOJAContext(DbContextOptions<LOJAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Clientepedido> Clientepedidos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Pedidoproduto> Pedidoprodutos { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=DESKTOP-V09ES4T; Database=LOJA; User ID=larissa;Password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("CLIENTE");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Nome).HasColumnName("NOME");
            });

            modelBuilder.Entity<Clientepedido>(entity =>
            {
                entity.ToTable("CLIENTEPEDIDO");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Cliente).HasColumnName("CLIENTE");

                entity.Property(e => e.Pedido).HasColumnName("PEDIDO");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.Clientepedidos)
                    .HasForeignKey(d => d.Cliente)
                    .HasConstraintName("FK_CLIENTEPEDIDO2");

                entity.HasOne(d => d.PedidoNavigation)
                    .WithMany(p => p.Clientepedidos)
                    .HasForeignKey(d => d.Pedido)
                    .HasConstraintName("FK_CLIENTEPEDIDO3");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("PEDIDO");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Datapedido)
                    .HasColumnType("datetime")
                    .HasColumnName("DATAPEDIDO");

                entity.Property(e => e.Total).HasColumnName("TOTAL");
            });

            modelBuilder.Entity<Pedidoproduto>(entity =>
            {
                entity.ToTable("PEDIDOPRODUTO");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Pedido).HasColumnName("PEDIDO");

                entity.Property(e => e.Produto).HasColumnName("PRODUTO");

                entity.HasOne(d => d.PedidoNavigation)
                    .WithMany(p => p.Pedidoprodutos)
                    .HasForeignKey(d => d.Pedido)
                    .HasConstraintName("FK_PEDIDOPRODUTO2");

                entity.HasOne(d => d.ProdutoNavigation)
                    .WithMany(p => p.Pedidoprodutos)
                    .HasForeignKey(d => d.Produto)
                    .HasConstraintName("FK_PEDIDOPRODUTO3");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("PRODUTO");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Nome).HasColumnName("NOME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
