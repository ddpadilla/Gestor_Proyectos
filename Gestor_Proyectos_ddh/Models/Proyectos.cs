using System.ComponentModel.DataAnnotations;

namespace Gestor_Proyectos_ddh.Models
{
    public class Proyectos
    {

        public int ID_PROYECTO { get; set; }
       
        [Required(ErrorMessage = "*")]
        
        public string NOMBRE_PROYECTO { get; set; }
        
        [Required(ErrorMessage = "*")]
        
        public string DESCRIPCION { get; set; }

        [Required(ErrorMessage = "*")]
        public string TAREAS { get; set; }

        [Required(ErrorMessage = "*")]
        public string MATERIALES { get; set; }

        [Required(ErrorMessage = "*")]
        public string COSTOS { get; set; }

        [Required(ErrorMessage = "*")]
        public string RESPONSABLE { get; set; }
        [Required(ErrorMessage = "* Campos Mandatorios")]
        public string FECHA_ENTREGA { get; set; }
    }
}
