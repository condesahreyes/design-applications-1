using AccesoDatos.Entidades_Datos;
using OblDiseño1;
using System.Data.Entity;

namespace AccesoDatos
{
    class Contexto : DbContext
    {
        public DbSet<Entidad_Categoria> categorias { get; set; }
        public DbSet<Entidad_DuplaUsuarioContrasenia> duplas { get; set; }
        public DbSet<Entidad_Tarjeta> tarjetas { get; set; }
        public DbSet<Entidad_Usuario> usuarios { get; set; }
        

        public Contexto() : base("BddD1")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Contexto, AccesoDatos.Migrations.Configuration>());
        }

    

    }
}
