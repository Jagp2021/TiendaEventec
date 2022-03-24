namespace ApiTienda.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Orden")]
    public partial class Orden
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orden()
        {
            DetalleOrden = new HashSet<DetalleOrden>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(120)]
        public string CustomerEmail { get; set; }

        [StringLength(40)]
        public string CustomerMobile { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        [StringLength(200)]
        public string TransactionId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleOrden> DetalleOrden { get; set; }
    }
}
