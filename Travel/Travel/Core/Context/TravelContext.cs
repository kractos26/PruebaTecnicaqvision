using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Travel.Core.Entities;

#nullable disable

namespace Travel.Core.Context
{
    /// <summary>
    /// Permite el manejo a de la conexion de a la base de datos Travel
    /// </summary>
    public partial class TravelContext : DbContext
    {
        public TravelContext()
        {
        }

        public TravelContext(DbContextOptions<TravelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<AutorLibro> AutorLibros { get; set; }
        public virtual DbSet<Editorial> Editorials { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-7VA8NVM3;Initial Catalog=Travel;Integrated Security=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.ToTable("Autor");

                entity.Property(e => e.Apellido).HasMaxLength(45);

                entity.Property(e => e.Nombre).HasMaxLength(45);
            });

            modelBuilder.Entity<AutorLibro>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AutorLibro");

                entity.Property(e => e.LibroIsbn).HasColumnName("Libro_ISBN");

                entity.HasOne(d => d.Autor)
                    .WithMany()
                    .HasForeignKey(d => d.AutorId)
                    .HasConstraintName("FK_AutorLibro_Autor");

                entity.HasOne(d => d.LibroIsbnNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.LibroIsbn)
                    .HasConstraintName("FK_AutorLibro_Libro");
            });

            modelBuilder.Entity<Editorial>(entity =>
            {
                entity.ToTable("Editorial");

                entity.Property(e => e.Nombre).HasMaxLength(45);

                entity.Property(e => e.Sede).HasMaxLength(45);
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.LibroIsbn);

                entity.ToTable("Libro");

                entity.Property(e => e.LibroIsbn).HasColumnName("Libro_ISBN");

                entity.Property(e => e.Npaginas)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Sinopsis).HasColumnType("text");

                entity.Property(e => e.Titulo).HasMaxLength(45);

                entity.HasOne(d => d.Editorial)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.EditorialId)
                    .HasConstraintName("FK_Libro_Editorial");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
