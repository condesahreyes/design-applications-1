using OblDiseño1;
using OblDiseño1.Entidades;
using System.Data.Entity;

namespace AccesoDatos
{
    class Contexto : DbContext
    {
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Dupla_UsuarioContrasenia> duplas { get; set; }
        public DbSet<Tarjeta> tarjetas { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        

        public Contexto() : base("BddD1")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Contexto, AccesoDatos.Migrations.Configuration>());
        }

    

    }
}
