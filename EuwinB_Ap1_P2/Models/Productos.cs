using System.ComponentModel.DataAnnotations;

namespace EuwinB_Ap1_P2.Models;

    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Concepto { get; set; } = string.Empty;

        public double Precio { get; set; }

        public int Stock { get; set; }

        public bool Activo { get; set; } = true;
    }
