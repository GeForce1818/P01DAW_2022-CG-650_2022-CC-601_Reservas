using System.ComponentModel.DataAnnotations;
namespace P01_2022_CG_650_2022_CC_601.Models
{
    public class espacio
    {
        [Key]
        public int id { get; set; }
        public string ubicacion { get; set; }
        public int cph { get; set; }
        public string estado { get; set; }
        public int? idsucursal { get; set; }

    }
}
