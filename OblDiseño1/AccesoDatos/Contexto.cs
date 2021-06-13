﻿using System.ComponentModel.DataAnnotations.Schema;
using AccesoDatos.Entidades_Datos;
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
            modelBuilder.Entity<EntidadUsuario>().HasKey(c => new { c.Nombre });

            modelBuilder.Entity<EntidadCategoria>().HasKey(c => new { c.CategoriaId });
            modelBuilder.Entity<EntidadCategoria>().Property(c => c.CategoriaId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<EntidadCategoria>().HasRequired<EntidadUsuario>(c => c.Usuario).WithMany(u => u.categorias).HasForeignKey<string>(s => s.UsuarioNombre);

            modelBuilder.Entity<EntidadContraseña>().HasKey(c => new { c.ContraseniaId });
            modelBuilder.Entity<EntidadContraseña>().Property(c => c.ContraseniaId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //modelBuilder.Entity<EntidadContraseña>().HasRequired<EntidadCredencial>(c => c.Credencial).WithRequiredPrincipal(s => s.Contrasenia);

            modelBuilder.Entity<EntidadCredencial>().HasKey(c => new { c.CredencialId });
            //modelBuilder.Entity<EntidadCredencial>().Property(c => c.CredencialId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<EntidadCredencial>().HasRequired<EntidadUsuario>(c => c.UsuarioGestor).WithMany(u => u.credenciales).HasForeignKey<string>(s => s.UsuarioGestorNombre).WillCascadeOnDelete(false);
            modelBuilder.Entity<EntidadCredencial>().HasRequired<EntidadCategoria>(c => c.Categoria).WithMany(u => u.Credenciales).HasForeignKey(t => new { t.IdCategoria });
            /*
            modelBuilder.Entity<ContraseñasQueMeComparten>().HasKey(c => new { c.UsuarioNombre, c.CredencialId });

            modelBuilder.Entity<ContraseñasQueComparto>().HasKey(c => new { c.UsuarioNombreDueño, c.CredencialId, c.UsuarioAlQueCompartoNombre });

            modelBuilder.Entity<ContraseñasQueComparto>().HasRequired<EntidadUsuario>(c => c.UsuarioDueño).WithMany(u => u.QueComparto).HasForeignKey(t => new { t.UsuarioNombreDueño, t.CredencialId, t.UsuarioAlQueCompartoNombre }).WillCascadeOnDelete(false);

            modelBuilder.Entity<ContraseñasQueMeComparten>().HasRequired<EntidadUsuario>(c => c.UsuarioDueño).WithMany(u => u.QueMeComparten).HasForeignKey(t => new { t.UsuarioNombre, t.CredencialId }).WillCascadeOnDelete(false);
            */

            modelBuilder.Entity<EntidadCredencial>().HasRequired<EntidadContraseña>(c => c.Contrasenia).WithOptional(u => u.Credencial);

            modelBuilder.Entity<EntidadTarjeta>().HasKey(c => new { c.TarjetaId });
            modelBuilder.Entity<EntidadTarjeta>().HasRequired<EntidadUsuario>(c => c.UsuarioGestor).WithMany(u => u.tarjetas).HasForeignKey<string>(s => s.UsuarioGestorNombre).WillCascadeOnDelete(false);
            modelBuilder.Entity<EntidadTarjeta>().HasRequired<EntidadCategoria>(c => c.Categoria).WithMany(u => u.Tarjetas).HasForeignKey(t => new { t.IdCategoria });
        }
    }
}