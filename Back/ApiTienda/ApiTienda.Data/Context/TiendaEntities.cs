namespace ApiTienda.Data.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ApiTienda.Data.Entities;

    public partial class TiendaEntities : DbContext
    {
        public TiendaEntities()
            : base("name=TiendaEntities")
        {
        }

        public virtual DbSet<DetalleOrden> DetalleOrden { get; set; }
        public virtual DbSet<Orden> Orden { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleOrden>()
                .Property(e => e.Valor)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Orden>()
                .Property(e => e.CustomerName)
                .IsUnicode(false);

            modelBuilder.Entity<Orden>()
                .Property(e => e.CustomerEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Orden>()
                .Property(e => e.CustomerMobile)
                .IsUnicode(false);

            modelBuilder.Entity<Orden>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Orden>()
                .HasMany(e => e.DetalleOrden)
                .WithRequired(e => e.Orden)
                .HasForeignKey(e => e.IdOrden)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.NombreProducto)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Valor)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.DetalleOrden)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);
        }
    }
}
