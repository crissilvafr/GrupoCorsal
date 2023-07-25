using System.ComponentModel.DataAnnotations;

namespace GrupoCorsal.Models{

    public class Persona{

        [Key]
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? apellido1 { get; set; }
        public string? apllido2 { get; set; }
        public int tipo_persona { get; set; }
        public int folio { get; set; }
        public int sexo_id { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string? rfc { get; set; }
        public string? curp { get; set; }


    }
    
}