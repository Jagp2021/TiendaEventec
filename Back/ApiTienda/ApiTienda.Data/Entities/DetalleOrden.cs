namespace ApiTienda.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetalleOrden")]
    public partial class DetalleOrden
    {
        [Key]
        public int IdDetalle { get; set; }

        public int IdOrden { get; set; }

        public int IdProducto { get; set; }

        public int Cantidad { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Valor { get; set; }

        public virtual Orden Orden { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
