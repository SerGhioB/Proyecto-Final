using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;

namespace ProyectoFinal.Model
{
    class ProyectoFinalDataContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<TipoEmpaque> TipoEmpaques { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<DetalleCompra> DetalleCompras { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Categoria>()
                .ToTable("Categoria")
                .HasKey(c => new { c.CodigoCategoria })
                .Property(c => c.Descripcion)
                .IsRequired();
        
            modelBuilder.Entity<TipoEmpaque>()
                .ToTable("TipoEmpaque")
                .HasKey(t => new { t.CodigoEmpaque })
                .Property(t => t.Descripcion)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .ToTable("Cliente")
                .HasKey(c => new { c.Nit })
                .Property(c => c.DPI)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .ToTable("Cliente")
                .Property(c => c.Nombre)
                .IsRequired();
                           
            modelBuilder.Entity<Proveedor>()
                .ToTable("Proveedor")
                .HasKey(p => new { p.CodigoProveedor })
                .Property(p => p.Nit)
                .IsRequired();

            modelBuilder.Entity<Inventario>()
                .ToTable("Inventario")
                .HasKey (i => new {i.CodigoInventario})
                .Property(i => i.CodigoProducto)
                .IsRequired();

            modelBuilder.Entity<Producto>()
                .ToTable("Producto")
                .HasKey(p => new { p.CodigoProducto })
                .Property(p => p.CodigoCategoria)
                .IsRequired();

            modelBuilder.Entity<Producto>()
                .ToTable("Producto")
                .Property(p => p.CodigoEmpaque )
                .IsRequired();

            modelBuilder.Entity<DetalleCompra>()
                .ToTable("DetalleCompra")
                .HasKey(d => new { d.IdDetalle })
                .Property(d => d.IdCompra)
                .IsRequired();

            modelBuilder.Entity<DetalleCompra>()
                .ToTable("DetalleCompra")
                .Property(d => d.CodigoProducto)
                .IsRequired();
            
          
        }


    }
}
