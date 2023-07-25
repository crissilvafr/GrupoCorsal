using System.ComponentModel.DataAnnotations;

namespace GrupoCorsal.Models{

    public class version{

        [Key]
        public int id { get; set; }
        public string? nombre { get; set; }

    }
    
}