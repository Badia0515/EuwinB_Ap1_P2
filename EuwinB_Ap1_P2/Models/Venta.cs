using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuwinB_Ap1_P2.Models;

    public class Venta
    {
        [Key]
        public int VentaId { get; set; }

        [Required(ErrorMessage = "Debes de llenar el campo Fecha")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Debes de llenar el campo Observacion")]
        public string Observacion { get; set; } = string.Empty;

        public double Total { get; set; }

        [InverseProperty(nameof(VentaDetalle.Venta))]
        public ICollection<VentaDetalle> ventaDetalles { get; set; } = new List<VentaDetalle>();
    }
