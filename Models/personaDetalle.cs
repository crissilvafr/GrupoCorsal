using System.ComponentModel.DataAnnotations;

namespace GrupoCorsal.Models{

    public class personaDetalle{

        [Key]
        public int id { get; set; }
        public int persona_id { get; set; }
        public string? domicilio { get; set; }
        public double ingresos { get; set; }
        public string? referencia1 { get; set; }
        public string? referencia2 { get; set; }
        public string? beneficiario { get; set; }
        public string? telefono { get; set; }
        public string? correo { get; set; }
        public string? observaciones { get; set; }
        public DateTime fecha { get; set; }

    }
    
}