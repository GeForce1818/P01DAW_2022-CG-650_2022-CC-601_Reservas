using System.ComponentModel.DataAnnotations;
namespace P01_2022_CG_650_2022_CC_601.Models
{
    public class usuario
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string contraseña { get; set; }
        public string rol { get; set; }

    }
}
