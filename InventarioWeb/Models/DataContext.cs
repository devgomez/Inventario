using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace InventarioWeb.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<Detallecompra> Detallecompras { get; set; }
        public virtual DbSet<Detalleventum> Detalleventa { get; set; }
        public virtual DbSet<Especificacionesproducto> Especificacionesproductos { get; set; }
        public virtual DbSet<Multiuso> Multiusos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Proveedore> Proveedores { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=db_Inventario;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("CLIENTES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCION");

                entity.Property(e => e.Estado).HasColumnName("ESTADO");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRES");

                entity.Property(e => e.Numerodocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NUMERODOCUMENTO");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONO");

                entity.Property(e => e.Tipodocumento)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TIPODOCUMENTO");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.ToTable("COMPRAS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fechacompra)
                    .HasColumnType("date")
                    .HasColumnName("FECHACOMPRA");

                entity.Property(e => e.Idproveedor).HasColumnName("IDPROVEEDOR");

                entity.Property(e => e.Numerodocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NUMERODOCUMENTO");

                entity.Property(e => e.Tipodocumento)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TIPODOCUMENTO");

                entity.HasOne(d => d.IdproveedorNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.Idproveedor)
                    .HasConstraintName("FK__COMPRAS__IDPROVE__6383C8BA");
            });

            modelBuilder.Entity<Detallecompra>(entity =>
            {
                entity.HasKey(e => new { e.Idcompra, e.Idproducto })
                    .HasName("PK__DETALLEC__DB94CE35B77D2496");

                entity.ToTable("DETALLECOMPRA");

                entity.Property(e => e.Idcompra).HasColumnName("IDCOMPRA");

                entity.Property(e => e.Idproducto).HasColumnName("IDPRODUCTO");

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.HasOne(d => d.IdcompraNavigation)
                    .WithMany(p => p.Detallecompras)
                    .HasForeignKey(d => d.Idcompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DETALLECO__IDCOM__66603565");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Detallecompras)
                    .HasForeignKey(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DETALLECO__IDPRO__6754599E");
            });

            modelBuilder.Entity<Detalleventum>(entity =>
            {
                entity.HasKey(e => new { e.Idventa, e.Idproducto })
                    .HasName("PK__DETALLEV__2F91175886D063AF");

                entity.ToTable("DETALLEVENTA");

                entity.Property(e => e.Idventa).HasColumnName("IDVENTA");

                entity.Property(e => e.Idproducto).HasColumnName("IDPRODUCTO");

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Detalleventa)
                    .HasForeignKey(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DETALLEVE__IDPRO__6E01572D");

                entity.HasOne(d => d.IdventaNavigation)
                    .WithMany(p => p.Detalleventa)
                    .HasForeignKey(d => d.Idventa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DETALLEVE__IDVEN__6D0D32F4");
            });

            modelBuilder.Entity<Especificacionesproducto>(entity =>
            {
                entity.ToTable("ESPECIFICACIONESPRODUCTO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idproducto).HasColumnName("IDPRODUCTO");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Valor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VALOR");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Especificacionesproductos)
                    .HasForeignKey(d => d.Idproducto)
                    .HasConstraintName("FK__ESPECIFIC__IDPRO__5CD6CB2B");
            });

            modelBuilder.Entity<Multiuso>(entity =>
            {
                entity.ToTable("MULTIUSO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Estado).HasColumnName("ESTADO");

                entity.Property(e => e.Idpadre).HasColumnName("IDPADRE");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Orden).HasColumnName("ORDEN");

                entity.Property(e => e.Tipodato)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("TIPODATO");

                entity.Property(e => e.Valor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VALOR");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("PRODUCTOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CODIGO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Estado).HasColumnName("ESTADO");

                entity.Property(e => e.Fechavencimiento)
                    .HasColumnType("date")
                    .HasColumnName("FECHAVENCIMIENTO");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Preciocompra)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("PRECIOCOMPRA");

                entity.Property(e => e.Precioventa)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("PRECIOVENTA");

                entity.Property(e => e.Stock).HasColumnName("STOCK");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.ToTable("PROVEEDORES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCION");

                entity.Property(e => e.Estado).HasColumnName("ESTADO");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRES");

                entity.Property(e => e.Numerodocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NUMERODOCUMENTO");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONO");

                entity.Property(e => e.Tipodocumento)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TIPODOCUMENTO");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("VENTAS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fechaventa)
                    .HasColumnType("date")
                    .HasColumnName("FECHAVENTA");

                entity.Property(e => e.Idcliente).HasColumnName("IDCLIENTE");

                entity.Property(e => e.Numerodocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NUMERODOCUMENTO");

                entity.Property(e => e.Tipodocumento)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TIPODOCUMENTO");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Idcliente)
                    .HasConstraintName("FK__VENTAS__IDCLIENT__6A30C649");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
