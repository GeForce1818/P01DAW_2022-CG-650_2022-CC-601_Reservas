using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace P01_2022_CG_650_2022_CC_601.Models
{
    public class ResevasContext : DbContext
    {

        public ResevasContext(DbContextOptions<ResevasContext> option) : base(option)

        {

        }
    }
}
