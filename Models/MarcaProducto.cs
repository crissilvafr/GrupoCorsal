using System.ComponentModel.DataAnnotations;

namespace GrupoCorsal.Models{

    public class MarcaProducto{

        [Key]
        public int id { get; set; }
        public int marca_id { get; set; }
        public int producto_id { get; set; }
        public int version_id { get; set; }
        public bool activo { get; set; }

    }
    
}