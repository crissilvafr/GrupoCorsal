using System.ComponentModel.DataAnnotations;

namespace GrupoCorsal.Models{

    public class TipoPersona{

        [Key]
        public int id { get; set; }
        public string? nombre { get; set; }

    }
    
}