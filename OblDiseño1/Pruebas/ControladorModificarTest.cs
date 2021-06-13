using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccesoDatos;
using AccesoDatos.Entidades_Datos;
using System.Linq;
using OblDiseño1;
using OblDiseño1.ControladoresPorFuncionalidad;
using OblDiseño1.Entidades;

namespace Pruebas
{
    [TestClass]
    public class ControladorModificarTest
    {
        private ControladorModificar controladorModificar = new ControladorModificar();

        private DateTime fecha;
        private const string usuarioGestor = "Hernán";
        private const string contraseña = "Mi contraseña";
        private const string categoriaNombre = "Personal";
        private const string numeroTarjeta = "1234567891234567";
        private const string usuarioCredencial = "Usuario insta";
        private const string credencialSitio = "Facebook";
        private const string credencialNota = "Nota ";
        private const string nombreTarjeta = "Master Card";
        private const string tipoTarjeta = "Debito";

        private static Usuario usuario = new Usuario(usuarioGestor, contraseña);
        private Categoria categoria = new Categoria(categoriaNombre);
        private IRepositorio<Usuario> usuarioRepo = new UsuarioRepositorio();
        private IRepositorio<Categoria> categoriaRepo = new CategoriaRepositorio(usuario);
        private IRepositorio<Tarjeta> tarjetaRepo = new TarjetaRepositorio(usuario);
        private IRepositorio<Credencial> credencialRepo = new CredencialRepositorio(usuario);

        [TestInitialize]
        public void Setup()
        {
            EliminarDatosBD();
            fecha = new DateTime(2021, 12, 15);
            AgregarUnRegistroEnCadaTabla();
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ModificarContraseñaDelGestor()
        {
            string contraseñaModificada = "otraContraseña";
            Usuario usuarioModificado = new Usuario(usuarioGestor, contraseñaModificada);
            controladorModificar.ModificarUsuario(usuario, usuarioModificado, usuarioRepo);

            bool mismaContraseña = false;

            using (Contexto contexto = new Contexto())
                foreach (var usuario in contexto.usuarios)
                    mismaContraseña = usuario.Contrasenia == contraseñaModificada;

            Assert.IsTrue(mismaContraseña);
        }

        [TestMethod]
        public void ModificarNombreCategoria()
        {
            string nombreModificado = "Es modificada";

            Categoria categoriaModificada = new Categoria(nombreModificado);
            controladorModificar.ModificarCategoria(categoria, categoriaModificada, categoriaRepo);

            bool mismaCategoria = false;

            using (Contexto contexto = new Contexto())
                foreach (var categoria in contexto.categorias)
                    if(categoria.NombreCategoria == nombreModificado && usuario.Nombre== categoria.UsuarioNombre)
                    mismaCategoria = categoria.NombreCategoria == nombreModificado;

            Assert.IsTrue(mismaCategoria);
        }


        [TestMethod]
        public void ModificarNumeroTarjeta()
        {
            string numeroModificado = "1234555555123111";

            Tarjeta tarjeta = new Tarjeta(nombreTarjeta, tipoTarjeta,
                numeroTarjeta, 1234, fecha, categoria, credencialNota);
            Tarjeta tarjetaModificada = new Tarjeta(nombreTarjeta, tipoTarjeta,
                "1234555555123111", 1234, fecha, categoria, credencialNota);

            controladorModificar.ModificarTarjeta(tarjeta, tarjetaModificada, tarjetaRepo);

            bool mismoNumero = false;

            using (Contexto contexto = new Contexto())
                foreach (var unaTarjeta in contexto.tarjetas)
                    if (unaTarjeta.Numero == numeroModificado && usuario.Nombre == unaTarjeta.UsuarioGestorNombre)
                        mismoNumero = true;

            Assert.IsTrue(mismoNumero);
        }

        [TestMethod]
        public void ModificarNombreUsuarioCredencial()
        {
            string nombreUsuarioModificado = "nombreModificado";
            Contraseña contraseñaDominio = new Contraseña(contraseña);
            Credencial credencial = new Credencial(usuarioCredencial, contraseñaDominio,
                 credencialSitio, credencialNota, categoria);

            Credencial credencialModificada = new Credencial(nombreUsuarioModificado, contraseñaDominio,
                credencialSitio, credencialNota, categoria);

            controladorModificar.ModificarCredencial(credencial, credencialModificada, credencialRepo);

            bool mismoNombre = false;

            using (Contexto contexto = new Contexto())
                foreach (var unaCredencial in contexto.credenciales)
                    if (unaCredencial.NombreUsuario ==nombreUsuarioModificado && 
                        usuario.Nombre == unaCredencial.UsuarioGestorNombre && 
                        unaCredencial.NombreSitioApp == credencial.NombreSitioApp)
                        mismoNombre = true;

            Assert.IsTrue(mismoNombre);
        }

        private void AgregarUnRegistroEnCadaTabla()
        {
            AgregarUsuario(usuarioGestor, contraseña);
            AgregarCategoria(categoriaNombre, usuarioGestor);
            AgregarTarjeta(numeroTarjeta, usuarioGestor, categoriaNombre);
            AgregarCredencial(usuarioCredencial, categoriaNombre, usuarioGestor);
        }

        private void EliminarDatosBD()
        {
            using (Contexto contexto = new Contexto())
            {
                contexto.credenciales.RemoveRange(contexto.credenciales);
                contexto.contraseñas.RemoveRange(contexto.contraseñas);
                contexto.tarjetas.RemoveRange(contexto.tarjetas);
                contexto.categorias.RemoveRange(contexto.categorias);
                contexto.usuarios.RemoveRange(contexto.usuarios);
                contexto.SaveChanges();
            }
        }

        public void AgregarUsuario(string nombreUsuario, string contraseña)
        {
            EntidadUsuario entidadusuario = new EntidadUsuario(nombreUsuario, contraseña);
            using (Contexto contexto = new Contexto())
            {
                contexto.usuarios.Add(entidadusuario);
                contexto.SaveChanges();
            }
        }

        public void AgregarCategoria(string nombreCategoria, string nombreUsuario)
        {
            EntidadUsuario entidadUsuario = new EntidadUsuario(nombreUsuario, contraseña);
            EntidadCategoria entidadCategoria = new EntidadCategoria(nombreCategoria, entidadUsuario);

            using (Contexto contexto = new Contexto())
            {
                contexto.categorias.Add(entidadCategoria);
                contexto.SaveChanges();
            }
        }

        public void AgregarTarjeta(string numeroTarjeta, string nombreUsuario, string nombreCategoria)
        {
            int idCategoria = ObtenerIdCategoria(nombreCategoria, nombreUsuario);

            EntidadUsuario entidadUsuario = new EntidadUsuario(nombreUsuario, null);
            EntidadTarjeta entidadTarjeta = new EntidadTarjeta(credencialNota, nombreTarjeta, tipoTarjeta, numeroTarjeta, 1234,
                fecha, idCategoria, nombreUsuario);

            using (Contexto contexto = new Contexto())
            {
                contexto.tarjetas.Add(entidadTarjeta);
                contexto.SaveChanges();
            }
        }

        public int ObtenerIdCategoria(string nombreCategoria, string usuarioDueño)
        {
            using (Contexto contexto = new Contexto())
            {
                foreach (var categoria in contexto.categorias)
                    if (categoria.NombreCategoria == nombreCategoria && categoria.UsuarioNombre == usuarioDueño)
                        return categoria.CategoriaId;
            }
            return 0;
        }

        public void AgregarCredencial(string nombreUsuario, string nombreCategoria, string usuarioDueño)
        {
            int idCategoria = ObtenerIdCategoria(nombreCategoria, usuarioDueño);
            EntidadCredencial entidadCredencial;
            AgregarContraseña(contraseña, 0);
            using (Contexto contexto = new Contexto())
            {
                int idContraseña = contexto.contraseñas.Max(x => x.ContraseniaId);
                entidadCredencial = new EntidadCredencial(nombreUsuario, credencialSitio, credencialNota, idCategoria, usuarioDueño, idContraseña);

                contexto.credenciales.Add(entidadCredencial);
                contexto.SaveChanges();
            }
        }

        public void AgregarContraseña(string contraseña, int nivelSeguridadContrasenia)
        {
            EntidadContraseña entidadContraseña = new EntidadContraseña(contraseña, nivelSeguridadContrasenia);
            using (Contexto contexto = new Contexto())
            {
                contexto.contraseñas.Add(entidadContraseña);
                contexto.SaveChanges();
            }
        }
    }
}
