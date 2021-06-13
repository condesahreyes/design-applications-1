using AccesoDatos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1;
using OblDiseño1.ControladoresPorFuncionalidad;
using OblDiseño1.Entidades;
using System;
using System.Collections.Generic;

namespace Pruebas
{
    [TestClass]
    public class ControladorAltaTest
    {
        private ControladorAlta controladorAlta = new ControladorAlta();

        private static string notaCredencial;
        private static string nombreSitioCredencial;
        private static string nombresitioCredencialQueNoEsta;
        private static string nombreLargo;
        private static string contraseniaCorta;
        private static string contraseniaLarga;
        private static string contraseniaNoPresenteEnListaCredenciales;
        private static string numeroDeTarjetaNoPresenteEnListaTarjetas;

        private static string[] contrasenias = {"contrasenia123",
            "1234Contrasenia", "laContraseña"};

        private static string[] nombres = { "Hernán", "Santiago", "Rodrigo" };

        private static string[] nombresCategorias = {"Personal",
            "Trabajo", "Entretenimiento", "Estudios"};

        private static string[] nombresTarjetas = {"Visa",
            "Itau", "BBVA", "HSBC"};

        private static string[] tiposTarjetas = {"Visa gold",
            "Itau volar", "BBVA credito", "HSBC debito"};

        private static string[] numTarjetas = { "1234567891234567",
            "7894561234567894", "9876543219876543", "5462134567896543"};

        private static int[] codigosTarjetas = { 123, 321, 456, 789 };

        private List<Tarjeta> tarjetas;
        private List<Credencial> credenciales;
        private List<Categoria> categorias;

        private Usuario usuario;
        private Tarjeta tarjeta;
        private Categoria categoria;
        private Credencial credencial;
        private Contraseña contraseña;



        [TestInitialize]
        public void Setup()
        {
            notaCredencial = "";
            nombreSitioCredencial = "Instagram";
            nombresitioCredencialQueNoEsta = "Twitter";
            contraseniaCorta = "1234";
            contraseniaLarga = "contrasenia123456789012345";
            contraseniaNoPresenteEnListaCredenciales = "ContraseniaNoPrsente";
            numeroDeTarjetaNoPresenteEnListaTarjetas = "2000200020002000";
            nombreLargo = "Este es un nombre muy largo";

            credenciales = new List<Credencial>();
            tarjetas = new List<Tarjeta>();
            categorias = new List<Categoria>();

            usuario = new Usuario(nombres[0], contrasenias[0]);
            categoria = new Categoria(nombresCategorias[0]);
            tarjeta = new Tarjeta(nombresTarjetas[0], tiposTarjetas[0], numTarjetas[0],
                codigosTarjetas[0], new DateTime(2021, 12, 15), categoria, null);
            contraseña = new Contraseña(contrasenias[0]);
            credencial = new Credencial(nombres[1], contraseña,
                nombreSitioCredencial, notaCredencial, categoria);
        }

        /*
        public void AgregarUsuario(Usuario usuario, IRepositorio<Usuario> repositorioUsuario);
        public void AgregarCategoria(Categoria categoria, IRepositorio<Categoria> repositorioCategoria);
        public void AgregarTarjeta(Tarjeta tarjetaAgregar, IRepositorio<Tarjeta> repositorioTarjeta);
        public void AgregarCredencial(Credencial credencialAgregar, IRepositorio<Credencial> repositorioCredencial);
        */
        [TestMethod]
        public void VerificarQueSeAgregoUsuario()
        {
            IRepositorio<Usuario> iRepoUsuario = new UsuarioRepositorio();
            controladorAlta.AgregarUsuario(usuario, iRepoUsuario);

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
            IRepositorio<Usuario> iRepoUsuario = new UsuarioRepositorio();
            controladorAlta.AgregarUsuario(usuario, iRepoUsuario);

            bool hayUsuarioConEsaContrasenia = false;
            using (Contexto contexto = new Contexto())
            {
                foreach (var entidadUsuario in contexto.usuarios)
                    if (entidadUsuario.Nombre == usuario.Nombre && entidadUsuario.Contrasenia == usuario.Contrasenia)
                        hayUsuarioConEsaContrasenia = true;
            }
            Assert.IsTrue(hayUsuarioConEsaContrasenia);
        }


        [TestMethod]
        public void VerificarQueSeAgregoCategoria()
        {
            IRepositorio<Categoria> iRepoCategoria = new CategoriaRepositorio(usuario);
            controladorAlta.AgregarCategoria(categoria, iRepoCategoria);

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
            IRepositorio<Categoria> iRepoCategoria = new CategoriaRepositorio(usuario);
            controladorAlta.AgregarCategoria(categoria, iRepoCategoria);

            bool seAgregoCorrectamente = false;
            using (Contexto contexto = new Contexto())
            {
                foreach (var entidadCategoria in contexto.categorias)
                    if (entidadCategoria.UsuarioNombre == usuario.Nombre && entidadCategoria.NombreCategoria == categoria.Nombre)
                        seAgregoCorrectamente = true;
            }
            Assert.IsTrue(seAgregoCorrectamente);
        }


        [TestMethod]
        public void VerificarQueSeAgregoTarjeta()
        {
            IRepositorio<Tarjeta> iRepoTarjeta = new TarjetaRepositorio(usuario);
            controladorAlta.AgregarTarjeta(categoria, iRepoTarjeta);

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
            IRepositorio<Tarjeta> iRepoTarjeta = new TarjetaRepositorio(usuario);
            controladorAlta.AgregarTarjeta(tarjeta, iRepoTarjeta);

            bool seAgregoCorrectamente = false;
            using (Contexto contexto = new Contexto())
            {
                foreach (var entidadTarjeta in contexto.tarjetas)
                    if (entidadTarjeta.UsuarioGestorNombre == usuario.Nombre && entidadTarjeta.Numero == tarjeta.Numero)
                        seAgregoCorrectamente = true;
            }
            Assert.IsTrue(seAgregoCorrectamente);


        }

        [TestMethod]
        public void VerificarQueSeAgregoCredencial()
        {
            IRepositorio<Credencial> iRepoCredencial = new CredencialRepositorio(usuario);

            controladorAlta.AgregarCredencial(credencial, iRepoCredencial);

            int contidadUsuarios = 0;
            using (Contexto contexto = new Contexto())
            {
                foreach (var entidadCredencial in contexto.credenciales)
                    if (entidadCredencial.UsuarioGestorNombre == usuario.Nombre &&
                        entidadCredencial.NombreUsuario == credencial.NombreUsuario &&
                        entidadCredencial.NombreSitioApp == credencial.NombreSitioApp)
                        contidadUsuarios++;
            }
            Assert.IsTrue(contidadUsuarios > 0);
        }

        [TestMethod]
        public void VerificarQueSeAgregoLaContraseñaDeLaCredencialCorrectamente()
        {
            IRepositorio<Credencial> iRepoCredencial = new CredencialRepositorio(usuario);

            controladorAlta.AgregarCredencial(credencial, iRepoCredencial);
            bool contraseñaCorrecta = false;
            int idContraseña = 0;
            using (Contexto contexto = new Contexto())
            {
                foreach (var entidadCredencial in contexto.credenciales)
                    if (entidadCredencial.UsuarioGestorNombre == usuario.Nombre &&
                        entidadCredencial.NombreUsuario == credencial.NombreUsuario &&
                        entidadCredencial.NombreSitioApp == credencial.NombreSitioApp)
                        idContraseña = entidadCredencial.ContraseniaId;
            }

            using (Contexto contexto = new Contexto())
            {
                foreach (var entidadContraseña in contexto.contraseñas)
                    if (entidadContraseña.ContraseniaId == idContraseña)
                        contraseñaCorrecta = true;
            }
            Assert.IsTrue(contraseñaCorrecta);
        }
    }
}
