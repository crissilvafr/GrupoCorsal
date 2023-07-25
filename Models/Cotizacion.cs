using System.ComponentModel.DataAnnotations;

namespace GrupoCorsal.Models
{
    public class Cotizacion
    {
        [Key]
        public int id { get; set; }
        public int folio { get; set; }
        public DateTime fecha_cotizacion { get; set; }
        public int produto_id { get; set; }
        public double monto { get; set; }
        public int anio { get; set; }
        public int persona_id { get; set; }
        public string? usuario_id { get; set; }
        public double apertura_id { get; set; }
        public double comision_asesor { get; set; }
        public DateTime fecha_contratacion { get; set; }
    }
}