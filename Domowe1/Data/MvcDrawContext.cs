using Microsoft.EntityFrameworkCore;
using Domowe1.Models;
namespace Domowe1.Data
{
    public class MvcDrawContext : DbContext
    {
        public MvcDrawContext(DbContextOptions<MvcDrawContext> options)
        : base(options)
        {
        }
        public DbSet<Draw> Draw { get; set; }
    }
}