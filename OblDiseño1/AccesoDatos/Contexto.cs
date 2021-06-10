using AccesoDatos.Entidades_Datos;
using OblDiseño1;
using System.Data.Entity;

namespace AccesoDatos
{
    class Contexto : DbContext
    {
        public DbSet<EntidadCategoria> categorias { get; set; }
        public DbSet<EntidadCredencial> credenciales { get; set; }
        public DbSet<EntidadContraseña> contraseñas { set; get; }
        public DbSet<EntidadTarjeta> tarjetas { get; set; }
        public DbSet<EntidadUsuario> usuarios { get; set; }
        

        public Contexto() : base("BddD1")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Contexto>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntidadCategoria>().HasKey(c => c.NombreCategoria);
            modelBuilder.Entity<EntidadContraseña>().HasKey(c => c.ContraseñaId);
            modelBuilder.Entity<EntidadCredencial>().HasKey(c => new { c.CredencialId, c.NombreUsuario, c.NombreSitioApp });
            modelBuilder.Entity<EntidadTarjeta>().HasKey(c => new { c.Numero, c.EntidadTarjetaId });
            modelBuilder.Entity<EntidadUsuario>().HasKey(c => new {c.Nombre});

            modelBuilder.Entity<EntidadCategoria>().HasRequired<EntidadUsuario>(c => c.Usuario).WithMany(u => u.categorias).HasForeignKey<string>(s => s.UsuarioNombre);




        }



    }
}
