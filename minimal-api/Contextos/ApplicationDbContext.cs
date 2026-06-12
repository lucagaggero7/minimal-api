using Microsoft.EntityFrameworkCore;
using minimal_api.Entidades;

namespace minimal_api.Contextos
{
    public class ApplicationDbContext : DbContext
    {
        protected ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }

    }
}
