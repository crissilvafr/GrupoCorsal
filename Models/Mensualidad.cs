using System.ComponentModel.DataAnnotations;

namespace GrupoCorsal.Models{

    public class Mensualidad{

        [Key]
        public int id { get; set; }
        public int mensualidad { get; set; }
        public int cotizacion_id { get; set; }
        public decimal monto { get; set; }
        public bool activo { get; set; }
        public int numAutorizacion { get; set; }
        public int status { get; set; }

    }
    
}