using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyWasteAPI.Models
{
    public partial class MyWasteDBContext : DbContext
    {
        public MyWasteDBContext()
        {
        }

        public MyWasteDBContext(DbContextOptions<MyWasteDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Balance> Balances { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<CategoriaSubCategorium> CategoriaSubCategoria { get; set; }
        public virtual DbSet<CostosFijo> CostosFijos { get; set; }
        public virtual DbSet<Egreso> Egresos { get; set; }
        public virtual DbSet<FormasDePago> FormasDePagos { get; set; }
        public virtual DbSet<Gasto> Gastos { get; set; }
        public virtual DbSet<Ingreso> Ingresos { get; set; }
        public virtual DbSet<MontosCostosFijo> MontosCostosFijos { get; set; }
        public virtual DbSet<Pasivo> Pasivos { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<SubCategoria> SubCategorias { get; set; }
        public virtual DbSet<TiposIngreso> TiposIngresos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-UPD9JA9;database=MyWasteDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Balance>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Balance1).HasColumnName("balance");

                entity.Property(e => e.IdEgreso).HasColumnName("idEgreso");

                entity.Property(e => e.IdIngreso).HasColumnName("idIngreso");

                entity.HasOne(d => d.IdEgresoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdEgreso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Balances_Egresos");

                entity.HasOne(d => d.IdIngresoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdIngreso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Balances_Ingresos");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.Descp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descp");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CategoriaSubCategorium>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.IdSubCategoria).HasColumnName("idSubCategoria");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoriaSubCategoria_Categorias");

                entity.HasOne(d => d.IdSubCategoriaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSubCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoriaSubCategoria_SubCategorias");
            });

            modelBuilder.Entity<CostosFijo>(entity =>
            {
                entity.HasKey(e => e.IdCostoFijo);

                entity.Property(e => e.IdCostoFijo).HasColumnName("idCostoFijo");

                entity.Property(e => e.Concepto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("concepto");

                entity.Property(e => e.IdEgreso).HasColumnName("idEgreso");

                entity.Property(e => e.IdFormaDePago).HasColumnName("idFormaDePago");

                entity.HasOne(d => d.IdEgresoNavigation)
                    .WithMany(p => p.CostosFijos)
                    .HasForeignKey(d => d.IdEgreso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CostosFijos_Egresos");

                entity.HasOne(d => d.IdFormaDePagoNavigation)
                    .WithMany(p => p.CostosFijos)
                    .HasForeignKey(d => d.IdFormaDePago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CostosFijos_FormasDePago");
            });

            modelBuilder.Entity<Egreso>(entity =>
            {
                entity.HasKey(e => e.IdEgreso);

                entity.Property(e => e.IdEgreso).HasColumnName("idEgreso");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Mes)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mes");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("year");

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany(p => p.Egresos)
                    .HasForeignKey(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Egresos_Usuarios");
            });

            modelBuilder.Entity<FormasDePago>(entity =>
            {
                entity.HasKey(e => e.IdFormaDePago);

                entity.ToTable("FormasDePago");

                entity.Property(e => e.IdFormaDePago).HasColumnName("idFormaDePago");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Gasto>(entity =>
            {
                entity.HasKey(e => e.IdGasto)
                    .HasName("PK_Gasto");

                entity.Property(e => e.IdGasto).HasColumnName("idGasto");

                entity.Property(e => e.Concepto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("concepto");

                entity.Property(e => e.IdPasivo).HasColumnName("idPasivo");

                entity.Property(e => e.IdSubCategoria).HasColumnName("idSubCategoria");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.HasOne(d => d.IdPasivoNavigation)
                    .WithMany(p => p.Gastos)
                    .HasForeignKey(d => d.IdPasivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gastos_Pasivos");

                entity.HasOne(d => d.IdSubCategoriaNavigation)
                    .WithMany(p => p.Gastos)
                    .HasForeignKey(d => d.IdSubCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gastos_SubCategorias");
            });

            modelBuilder.Entity<Ingreso>(entity =>
            {
                entity.HasKey(e => e.IdIngreso);

                entity.Property(e => e.IdIngreso).HasColumnName("idIngreso");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdTipoIngreso).HasColumnName("idTipoIngreso");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany(p => p.Ingresos)
                    .HasForeignKey(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingresos_Usuarios");

                entity.HasOne(d => d.IdTipoIngresoNavigation)
                    .WithMany(p => p.Ingresos)
                    .HasForeignKey(d => d.IdTipoIngreso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingresos_TiposIngreso");
            });

            modelBuilder.Entity<MontosCostosFijo>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IdCostoFijo).HasColumnName("idCostoFijo");

                entity.Property(e => e.Mes)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mes");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("year");

                entity.HasOne(d => d.IdCostoFijoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCostoFijo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MontosCostosFijos_CostosFijos");
            });

            modelBuilder.Entity<Pasivo>(entity =>
            {
                entity.HasKey(e => e.IdPasivo);

                entity.Property(e => e.IdPasivo).HasColumnName("idPasivo");

                entity.Property(e => e.Cuotas).HasColumnName("cuotas");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.IdEgreso).HasColumnName("idEgreso");

                entity.Property(e => e.IdFormaDePago).HasColumnName("idFormaDePago");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Pasivos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pasivos_Categorias");

                entity.HasOne(d => d.IdEgresoNavigation)
                    .WithMany(p => p.Pasivos)
                    .HasForeignKey(d => d.IdEgreso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pasivos_Egresos");

                entity.HasOne(d => d.IdFormaDePagoNavigation)
                    .WithMany(p => p.Pasivos)
                    .HasForeignKey(d => d.IdFormaDePago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pasivos_FormasDePago");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPresona);

                entity.Property(e => e.IdPresona).HasColumnName("idPresona");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<SubCategoria>(entity =>
            {
                entity.HasKey(e => e.IdSubCategoria);

                entity.Property(e => e.IdSubCategoria).HasColumnName("idSubCategoria");

                entity.Property(e => e.Descp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descp");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TiposIngreso>(entity =>
            {
                entity.HasKey(e => e.IdTipoIngreso);

                entity.ToTable("TiposIngreso");

                entity.Property(e => e.IdTipoIngreso).HasColumnName("idTipoIngreso");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Personas");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
