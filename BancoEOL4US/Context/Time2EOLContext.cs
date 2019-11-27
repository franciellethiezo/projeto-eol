using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BancoEOL4US.Models
{
    public partial class Time2EOLContext : DbContext
    {
        public Time2EOLContext()
        {
        }

        public Time2EOLContext(DbContextOptions<Time2EOLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anuncio> Anuncio { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Condicao> Condicao { get; set; }
        public virtual DbSet<Interesse> Interesse { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-1HADG5F\\SQLEXPRESS;Database=Time2EOL;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anuncio>(entity =>
            {
                entity.HasKey(e => e.IdAnuncio)
                    .HasName("PK__Anuncio__0BC1EC3E287DF5C3");

                entity.Property(e => e.FotoAnuncio).IsUnicode(false);

                entity.Property(e => e.StatusAnuncio).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.FkIdCondicaoNavigation)
                    .WithMany(p => p.Anuncio)
                    .HasForeignKey(d => d.FkIdCondicao)
                    .HasConstraintName("FK__Anuncio__FK_idCo__46E78A0C");

                entity.HasOne(d => d.FkIdProdutoNavigation)
                    .WithMany(p => p.Anuncio)
                    .HasForeignKey(d => d.FkIdProduto)
                    .HasConstraintName("FK__Anuncio__FK_idPr__45F365D3");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__8A3D240CE7A2BE35");

                entity.Property(e => e.MarcaCategoria).IsUnicode(false);
            });

            modelBuilder.Entity<Condicao>(entity =>
            {
                entity.HasKey(e => e.IdCondicao)
                    .HasName("PK__Condicao__EC5ECA4C6C8F0F37");

                entity.Property(e => e.AvaliacaoCondicao).IsUnicode(false);
            });

            modelBuilder.Entity<Interesse>(entity =>
            {
                entity.HasKey(e => e.IdInteresse)
                    .HasName("PK__Interess__EC19CAE5E3D0EF4D");

                entity.HasOne(d => d.FkIdAnuncioNavigation)
                    .WithMany(p => p.Interesse)
                    .HasForeignKey(d => d.FkIdAnuncio)
                    .HasConstraintName("FK__Interesse__FK_id__4AB81AF0");

                entity.HasOne(d => d.FkIdUsuarioNavigation)
                    .WithMany(p => p.Interesse)
                    .HasForeignKey(d => d.FkIdUsuario)
                    .HasConstraintName("FK__Interesse__FK_id__49C3F6B7");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK__Produto__5EEDF7C3DEBC888B");

                entity.Property(e => e.FabricanteProduto).IsUnicode(false);

                entity.Property(e => e.NomeProduto).IsUnicode(false);

                entity.HasOne(d => d.FkIdCategoriaNavigation)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.FkIdCategoria)
                    .HasConstraintName("FK__Produto__FK_idCa__412EB0B6");

                entity.HasOne(d => d.FkIdUsuarioNavigation)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.FkIdUsuario)
                    .HasConstraintName("FK__Produto__FK_idUs__4222D4EF");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__03006BFF64041034");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A6A935AFC0");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.NomeUsuario).IsUnicode(false);

                entity.Property(e => e.TelefoneUsuario).IsUnicode(false);

                entity.HasOne(d => d.FkIdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.FkIdTipoUsuario)
                    .HasConstraintName("FK__Usuario__FK_idTi__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
