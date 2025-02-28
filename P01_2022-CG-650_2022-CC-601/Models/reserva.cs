using System.ComponentModel.DataAnnotations;
namespace P01_2022_CG_650_2022_CC_601.Models
{
    public class reserva
    {
        [Key]
        public int id { get; set; }
        public int? idespacio { get; set; }
        public int? idsucursal { get; set; }
        public DateOnly fecha { get; set; }

    }
}
