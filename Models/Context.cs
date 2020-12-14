using Microsoft.EntityFrameworkCore;

namespace Publicaciones.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            :base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Seguido>().HasKey(t => new { t.A_Seguir, t.UsuarioID });
           modelBuilder.Entity<Seguidor>().HasKey(t => new { t.Un_Seguidor, t.UsuarioID });
        }
        public DbSet<Usuario> Usuario {get;set;}
        public DbSet<Seguido> Seguido {get;set;}
        public DbSet<Seguidor> Seguidor {get;set;}
        public DbSet<Publicacion> Publicacion {get;set;}
        public DbSet<Comentario> Comentario {get;set;}
        public DbSet<Respuesta> Respuesta {get;set;}
        public DbSet<Like> Like {get;set;}     
        public DbSet<PubliViewModel> PubliViewModel {get;set;}
    }
}