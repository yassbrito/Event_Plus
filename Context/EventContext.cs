using Event_Plus.Domains;
using Microsoft.EntityFrameworkCore;

namespace Event_Plus.Context
{
    public class EventContext : DbContext
    {

        public EventContext() { }

        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {
        }


        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Evento> Evento { get; set; }

        public DbSet<Instituicao> Instiuicao { get; set; }

        public DbSet<Presenca> PresencaEventos { get; set; }

        public DbSet<TipoEvento> TipoEvento { get; set; }

        public DbSet<ComentarioEvento> ComentarioEvento { get; set; }

        public DbSet<TipoUsuario> TipoUsuario { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = NOTE31-S28\\SQLEXPRESS; DataBase = EventPlus; User Id = sa; Pwd = Senai@134; TrustServerCertificate=True;");
            }

        }
    }
}
