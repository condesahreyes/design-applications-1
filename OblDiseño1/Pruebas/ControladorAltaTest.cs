using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1.ControladoresPorFuncionalidad;
using System.Collections.Generic;
using OblDiseño1.Entidades;
using AccesoDatos;
using OblDiseño1;
using System;

namespace Pruebas
{
    [TestClass]
    public class ControladorAltaTest
    {
        private ControladorAlta controladorAlta;
        private Categoria categoria;
        private DateTime fecha;

        [TestInitialize]
        public void Setup()
        {
            //Borrar todos los datos de la Base antes de ejecutar los test
            controladorAlta = new ControladorAlta();
            categoria = new Categoria("Trabajo");
            fecha = new DateTime(2021, 12, 15);
        }

        [TestMethod]
        public void VerificarQueSeAgregoUsuario()
        {
            Usuario usuarioPrueba = new Usuario("Hernán", "Contraseña");
            AgregarUsuario(usuarioPrueba);

            int contidadUsuarios = 0;

            using (Contexto contexto = new Contexto())
            {
                foreach (var entidadUsuario in contexto.usuarios)
                    contidadUsuarios++; 
            }

            Assert.IsTrue(contidadUsuarios>0);
        }

        [TestMethod]
        public void VerificarContraseniaYNombreDeUsuario()
        {
            Usuario usuarioPrueba = new Usuario("Pedrito", "Contraseña");
            AgregarUsuario(usuarioPrueba);

            bool hayUsuarioConEsaContrasenia = false;

            using (Contexto contexto = new Contexto())
            {
                foreach (var entidadUsuario in contexto.usuarios)
                    if (entidadUsuario.Nombre == usuarioPrueba.Nombre 
                        && entidadUsuario.Contrasenia == usuarioPrueba.Contrasenia)
                        hayUsuarioConEsaContrasenia = true;
            }

            Assert.IsTrue(hayUsuarioConEsaContrasenia);
        }


        [TestMethod]
        public void VerificarQueSeAgregoCategoria()
        {
            Usuario usuarioPrueba = new Usuario("Juan Perez", "Contraseña");
            Categoria categoria = new Categoria("Personal");

            AgregarUsuario(usuarioPrueba);
            AgregarCategoria(categoria, usuarioPrueba);

            int contidadCategorias = 0;

            using (Contexto contexto = new Contexto())
            {
                foreach (var entidadCategoria in contexto.categorias)
                    contidadCategorias++;
            }

            Assert.IsTrue(contidadCategorias > 0);
        }

        [TestMethod]
        public void VerificarQueSeAgregoCategoriaCorrectamente()
        {
            Usuario usuarioPrueba = new Usuario("Alberto", "Contraseña");

            AgregarUsuario(usuarioPrueba);
            AgregarCategoria(categoria, usuarioPrueba);

            bool seAgregoCorrectamente = false;

            using (Contexto contexto = new Contexto())
            {
                foreach (var entidadCategoria in contexto.categorias)
                    if (entidadCategoria.UsuarioNombre == usuarioPrueba.Nombre 
                        && entidadCategoria.NombreCategoria == categoria.Nombre)
                        seAgregoCorrectamente = true;
            }

            Assert.IsTrue(seAgregoCorrectamente);
        }


        [TestMethod]
        public void VerificarQueSeAgregoTarjeta()
        {
            Usuario usuarioPrueba = new Usuario("Miguel", "ContraMiguel");


            Tarjeta tarjeta = new Tarjeta("Visas", "Tipo 1", "1234567891234567", 111, fecha, categoria, null);

            AgregarUsuario(usuarioPrueba);
            AgregarCategoria(categoria, usuarioPrueba);
            AgregarTarjeta(tarjeta, usuarioPrueba);

            int contidadTajetas = 0;

            using (Contexto contexto = new Contexto())
            {
                foreach (var entidadCategoria in contexto.categorias)
                    contidadTajetas++;
            }

            Assert.IsTrue(contidadTajetas > 0);
        }

        [TestMethod]
        public void VerificarQueSeAgregoTarjetaCorrectamente()
        {
            Tarjeta tarjeta = new Tarjeta("Visas", "Tipo 1", "1234567891234567", 111, fecha, categoria, null);
            Usuario usuarioPrueba = new Usuario("Miguel Angel", "ContraMiguelAngel");

            AgregarUsuario(usuarioPrueba);
            AgregarCategoria(categoria, usuarioPrueba);
            AgregarTarjeta(tarjeta, usuarioPrueba);

            bool seAgregoCorrectamente = false;

            using (Contexto contexto = new Contexto())
            {
                foreach (var entidadTarjeta in contexto.tarjetas)
                    if (entidadTarjeta.UsuarioGestorNombre == usuarioPrueba.Nombre 
                        && entidadTarjeta.Numero == tarjeta.Numero)
                        seAgregoCorrectamente = true;
            }

            Assert.IsTrue(seAgregoCorrectamente);
        }

        [TestMethod]
        public void VerificarQueSeAgregoCredencial()
        {
            Contraseña contraseña = new Contraseña("Una contraseña");
            Credencial credencial = new Credencial("Perez", contraseña,
                "Instagram", "Nota", categoria);
            Usuario usuarioPrueba = new Usuario("Usuario", "ContraMiguelAngel");

            AgregarUsuario(usuarioPrueba);
            AgregarCategoria(categoria, usuarioPrueba);
            AgregarCredencial(credencial, usuarioPrueba);

            int contidadUsuarios = 0;

            using (Contexto contexto = new Contexto())
            {
                foreach (var entidadCredencial in contexto.credenciales)
                    if (entidadCredencial.UsuarioGestorNombre == usuarioPrueba.Nombre &&
                        entidadCredencial.NombreUsuario == credencial.NombreUsuario &&
                        entidadCredencial.NombreSitioApp == credencial.NombreSitioApp)
                        contidadUsuarios++;
            }

            Assert.IsTrue(contidadUsuarios > 0);
        }

        [TestMethod]
        public void VerificarQueSeAgregoLaContraseñaDeLaCredencialCorrectamente()
        {
            Usuario usuarioPrueba = new Usuario("Usuario pepe", "ContraMiguelAngel");
            Contraseña contraseña = new Contraseña("Una contraseña");
            Credencial credencial = new Credencial("Soy Hernán", contraseña,
                "Facebook", "Ya no se usa Facebook", categoria);

            AgregarUsuario(usuarioPrueba);
            AgregarCategoria(categoria, usuarioPrueba);
            AgregarCredencial(credencial, usuarioPrueba);

            bool contraseñaCorrecta = false;
            int idContraseña = 0;

            using (Contexto contexto = new Contexto())
            {
                foreach (var entidadCredencial in contexto.credenciales)
                    if (entidadCredencial.UsuarioGestorNombre == usuarioPrueba.Nombre &&
                        entidadCredencial.NombreUsuario == credencial.NombreUsuario &&
                        entidadCredencial.NombreSitioApp == credencial.NombreSitioApp)
                        idContraseña = entidadCredencial.ContraseniaId;

                foreach (var entidadContraseña in contexto.contraseñas)
                    if (entidadContraseña.ContraseniaId == idContraseña)
                        contraseñaCorrecta = true;
            }

            Assert.IsTrue(contraseñaCorrecta);
        }

        private void AgregarUsuario(Usuario usuario)
        {
            IRepositorio<Usuario> iRepoUsuario = new UsuarioRepositorio();
            controladorAlta.AgregarUsuario(usuario, iRepoUsuario);
        }

        private void AgregarCategoria(Categoria categoria, Usuario usuario)
        {
            IRepositorio<Categoria> iRepoCategoria = new CategoriaRepositorio(usuario);
            controladorAlta.AgregarCategoria(categoria, iRepoCategoria);
        }

        private void AgregarTarjeta(Tarjeta tarjeta, Usuario usuario)
        {
            IRepositorio<Tarjeta> iRepoTarjeta = new TarjetaRepositorio(usuario);
            controladorAlta.AgregarTarjeta(tarjeta, iRepoTarjeta);
        }

        private void AgregarCredencial(Credencial credencial, Usuario usuario)
        {
            IRepositorio<Credencial> iRepoCredencial = new CredencialRepositorio(usuario);
            controladorAlta.AgregarCredencial(credencial, iRepoCredencial);
        }
    }
}
