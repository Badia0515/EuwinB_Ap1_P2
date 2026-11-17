using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EuwinB_Ap1_P2.Model;

namespace EuwinB_Ap1_P2.Models;

    public class VentaDetalle
    {

        [Key]
        public int DetalleId { get; set; }

        public int VentaId { get; set; }

        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public double Precio { get; set; }

        [ForeignKey(nameof(ProductoId))]
        public virtual Productos Productos { get; set; }

        [ForeignKey(nameof(VentaId))]
        public virtual Venta Venta { get; set; }
    }
