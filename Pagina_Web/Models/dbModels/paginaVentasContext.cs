using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pagina_Web.Models.dbModels
{
    public partial class paginaVentasContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public paginaVentasContext()
        {
        }

        public paginaVentasContext(DbContextOptions<paginaVentasContext> options)
            : base(options)
        {
        }

        /*public virtual DbSet<Cargo> Cargos { get; set; } = null!;*/
        public virtual DbSet<Carrito> Carritos { get; set; } = null!;
        public virtual DbSet<CategoriaProducto> CategoriaProductos { get; set; } = null!;
        public virtual DbSet<DetalleVp> DetalleVps { get; set; } = null!;
        public virtual DbSet<Direccion> Direccions { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<MarcaProducto> MarcaProductos { get; set; } = null!;
        public virtual DbSet<Municipio> Municipios { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        /*public virtual DbSet<Usuario> Usuarios { get; set; } = null!;*/
        public virtual DbSet<Ventum> Venta { get; set; } = null!;

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=paginaVentas;Trusted_Connection=True;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            /*modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.IdCargo)
                    .HasName("PK__Cargo__D3C09EC5915477D5");
            });*/

            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuarioCarrito, e.IdProdCarrito })
                    .HasName("pk_DetalleCaVP");

                entity.Property(e => e.IdUsuarioCarrito).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdProdCarritoNavigation)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.IdProdCarrito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProdCarr");

                entity.HasOne(d => d.IdUsuarioCarritoNavigation)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.IdUsuarioCarrito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UsuCarr");
            });

            modelBuilder.Entity<CategoriaProducto>(entity =>
            {
                entity.HasKey(e => e.IdCat)
                    .HasName("PK__Categori__D54686DEB23C5554");
            });

            modelBuilder.Entity<DetalleVp>(entity =>
            {
                entity.HasKey(e => new { e.IdVentaDvp, e.IdProductoDvp })
                    .HasName("pk_DetalleVP");

                entity.Property(e => e.IdVentaDvp).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdProductoDvpNavigation)
                    .WithMany(p => p.DetalleVps)
                    .HasForeignKey(d => d.IdProductoDvp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProdDVP");

                entity.HasOne(d => d.IdVentaDvpNavigation)
                    .WithMany(p => p.DetalleVps)
                    .HasForeignKey(d => d.IdVentaDvp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_VenDVP");
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.HasKey(e => e.IdDir)
                    .HasName("PK__Direccio__D5EA00D7F944A9D8");

                entity.HasOne(d => d.IdEstUsuarioNavigation)
                    .WithMany(p => p.Direccions)
                    .HasForeignKey(d => d.IdEstUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_EstUs");

                entity.HasOne(d => d.IdMunUsuarioNavigation)
                    .WithMany(p => p.Direccions)
                    .HasForeignKey(d => d.IdMunUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_MuUs");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Estado__86989FB27929A05F");
            });

            modelBuilder.Entity<MarcaProducto>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__Marca_Pr__7E43E99E37A4CAA5");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.HasKey(e => e.IdMunicipio)
                    .HasName("PK__Municipi__01C9EB9912D87159");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("fk_EstMun");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPagos)
                    .HasName("PK__Pagos__314B9344FFEC664E");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProd)
                    .HasName("PK__Producto__0DA34873F961228A");

                entity.HasOne(d => d.IdCatProdNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCatProd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TipProd");
            });

            /*modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__4E3E04AD17EB817B");

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdCargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CargUs");

                entity.HasOne(d => d.IdDirNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdDir)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DirUs");
            });*/

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PK__Venta__459533BF67752151");

                entity.HasOne(d => d.IdPagosNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdPagos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PagVen");

                entity.HasOne(d => d.IdUsuarioVentaNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdUsuarioVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ClteVen");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
