

using Microsoft.EntityFrameworkCore;
using TdocSpider.Application.Models.Entities;

namespace TdocSpider.Application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Documento> Documento { get; set; }

    }
}
