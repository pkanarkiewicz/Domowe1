using Microsoft.EntityFrameworkCore;
using Domowe1.Models;
namespace Domowe1.Data
{
    public class MvcFormattContext : DbContext
    {
        public MvcFormattContext(DbContextOptions<MvcFormattContext> options)
        : base(options)
        {
        }
        public DbSet<Formatt> Formatt { get; set; }
    }
}