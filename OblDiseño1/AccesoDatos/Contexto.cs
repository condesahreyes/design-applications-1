using AccesoDatos.Entidades_Datos;
using OblDiseño1;
using System.Data.Entity;

namespace AccesoDatos
{
    public class Contexto : DbContext
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
            modelBuilder.Entity<EntidadCategoria>().HasKey(c => new { c.NombreCategoria, c.UsuarioNombre} );
            modelBuilder.Entity<EntidadContraseña>().HasKey(c => new { c.Contrasenia, c.CredencialNombre});
            modelBuilder.Entity<EntidadCredencial>().HasKey(c => new { c.NombreUsuario, c.NombreSitioApp, c.UsuarioGestorNombre });
            modelBuilder.Entity<EntidadTarjeta>().HasKey(c => new { c.Numero, c.UsuarioGestorNombre });
            modelBuilder.Entity<EntidadUsuario>().HasKey(c => new {c.Nombre});

            modelBuilder.Entity<EntidadCategoria>().HasRequired<EntidadUsuario>(c => c.Usuario).WithMany(u => u.categorias).HasForeignKey<string>(s => s.UsuarioNombre);
            modelBuilder.Entity<EntidadCredencial>().HasRequired<EntidadUsuario>(c => c.UsuarioGestor).WithMany(u => u.credenciales).HasForeignKey<string>(s => s.UsuarioGestorNombre);
            modelBuilder.Entity<EntidadTarjeta>().HasRequired<EntidadUsuario>(c => c.UsuarioGestor).WithMany(u => u.tarjetas).HasForeignKey<string>(s => s.UsuarioGestorNombre);
            modelBuilder.Entity<EntidadContraseña>().HasRequired<EntidadCredencial>(c => c.Credencial).WithRequiredPrincipal(s => s.Contrasenia);

            


        }



    }
}
