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
        public DbSet<DetalleFactura> DetalleFacturas { get; set; }
        public DbSet<EmailProveedor> EmailProveedores { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<TelefonoProveedor> TelefonoProveedores { get; set; }
        public DbSet<EmailCliente> EmailClientes { get; set; }
        public DbSet<TelefonoCliente> TelefonoClientes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Categoria>()
                .ToTable("Categoria")
                .HasKey(c => new { c.CodigoCategoria})
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

            modelBuilder.Entity<DetalleFactura>()
                .ToTable("DetalleFactura")
                .HasKey(d => new { d.CodigoDetalle })
                .Property(d => d.NumeroFactura)
                .IsRequired();

            modelBuilder.Entity<DetalleFactura>()
                .ToTable("DetalleFactura")
                .Property(d => d.CodigoProducto)
                .IsRequired();

            modelBuilder.Entity<EmailProveedor>()
                .ToTable("EmailProveedor")
                .HasKey(e => new { e.CodigoEmail })
                .Property(e => e.Email)
                .IsRequired();

            modelBuilder.Entity<EmailProveedor>()
                .ToTable("EmailProveedor")
                .Property(e => e.CodigoProveedor)
                .IsRequired();

            modelBuilder.Entity<Compra>()
                .ToTable("Compra")
                .HasKey(c => new { c.IdCompra })
                .Property(c => c.NumeroDocumento)
                .IsRequired();

            modelBuilder.Entity<Compra>()
                .ToTable("Compra")
                .Property(c => c.CodigoProveedor)
                .IsRequired();

            modelBuilder.Entity<Factura>()
                .ToTable("Factura")
                .HasKey(f => new { f.NumeroFactura })
                .Property(f => f.Nit)
                .IsRequired();

            modelBuilder.Entity<TelefonoProveedor>()
                .ToTable("TelefonoProveedor")
                .HasKey(t => new { t.CodigoTelefono })
                .Property(t => t.Numero)
                .IsRequired();

            modelBuilder.Entity<TelefonoProveedor>()
                .ToTable("TelefonoProveedor")
                .Property(t => t.CodigoProveedor)
                .IsRequired();

            modelBuilder.Entity<EmailCliente>()
                .ToTable("EmailCliente")
                .HasKey(e => new { e.CodigoEmail })
                .Property(e => e.Email)
                .IsRequired();

            modelBuilder.Entity<EmailCliente>()
                .ToTable("EmailCliente")
                .Property(e => e.Nit)
                .IsRequired();

            modelBuilder.Entity<TelefonoCliente>()
                .ToTable("TelefonoCliente")
                .HasKey(t => new { t.CodigoTelefono })
                .Property(t => t.Numero)
                .IsRequired();

            modelBuilder.Entity<TelefonoCliente>()
                .ToTable("TelefonoCliente")
                .Property(t => t.Nit)
                .IsRequired();
            
          
        }


    }
}
