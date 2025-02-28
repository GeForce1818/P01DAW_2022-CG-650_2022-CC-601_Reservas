using System.ComponentModel.DataAnnotations;
namespace P01_2022_CG_650_2022_CC_601.Models
{
    public class sucursal
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string administrador { get; set; }
        public int nespacios { get; set; }

    }
}
