using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1.ControladoresPorFuncionalidad;
using OblDiseño1;
using AccesoDatos;
using AccesoDatos.Entidades_Datos;
using System.Linq;
using OblDiseño1.Entidades;

namespace Pruebas
{

    [TestClass]
    public class ControladorObtencionTest
    {
        private DateTime fecha;
        private const string usuarioGestor = "Hernán";
        private const string contraseña = "Mi contraseña";
        private const string categoriaNombre = "Personal";
        private const string numeroTarjeta = "1234567891234567";
        private const string usuarioCredencial = "Usuario insta";

        private static Usuario usuario = new Usuario(usuarioGestor, contraseña);
        private ControladorObtener controladorObtener = new ControladorObtener();
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

        private void AgregarUnRegistroEnCadaTabla()
        {
            AgregarUsuario(usuarioGestor, contraseña);
            AgregarCategoria(categoriaNombre, usuarioGestor);
            AgregarTarjeta(numeroTarjeta, usuarioGestor, categoriaNombre);
            AgregarCredencial(numeroTarjeta, categoriaNombre, usuarioGestor);
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
            EntidadUsuario entidadUsuario = new EntidadUsuario(nombreUsuario, null);
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
            EntidadTarjeta entidadTarjeta = new EntidadTarjeta(null, null, null, numeroTarjeta, 0,
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
            AgregarContraseña(null, 0);
            using (Contexto contexto = new Contexto())
            {
                int idContraseña= contexto.contraseñas.Max(x => x.ContraseniaId);
                entidadCredencial = new EntidadCredencial(nombreUsuario, null, null, idCategoria, usuarioDueño, idContraseña);
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

        [TestMethod]
        public void ObtenerUnUsuarioNoNull()
        {
            Usuario usuarioObtenido = controladorObtener.ObtenerUsuario(usuario, usuarioRepo);

            Assert.IsNotNull(usuarioObtenido);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionIntentoDeObtencionDeObjetoInexistente))]
        public void BuscarUsuarioInexistente()
        {
            Usuario usaurioInexistente = new Usuario("Juancito", contraseña);
            Usuario usuarioObtenido = controladorObtener.ObtenerUsuario(usaurioInexistente, usuarioRepo);
        }

        [TestMethod]
        public void VerificarNombreUsuarioGestor()
        {
            Usuario usuarioObtenido = controladorObtener.ObtenerUsuario(usuario, usuarioRepo);

            Assert.IsTrue(usuarioObtenido.Nombre==usuarioGestor);
        }

        [TestMethod]
        public void ObtenerCategoria()
        {
            Categoria categoria = new Categoria(categoriaNombre);
            Categoria usuarioObtenido = controladorObtener.ObtenerCategoria(categoria, usuarioRepo);

            Assert.IsTrue(usuarioObtenido.Nombre == usuarioGestor);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionIntentoDeObtencionDeObjetoInexistente))]
        public void QuererObtenerCategoriaInexistente()
        {
            Categoria categoriaNoExiste = new Categoria("NoExiste");
            Categoria usuarioObtenido = controladorObtener.ObtenerCategoria(categoriaNoExiste, usuarioRepo);
        }

        [TestMethod]
        public void VerificarCategoriaNombre()
        {
            Categoria categoria = new Categoria(categoriaNombre);
            Categoria categoriaObtenida = controladorObtener.ObtenerCategoria(categoria, usuarioRepo);

            Assert.IsTrue(categoria.Nombre == categoriaObtenida.Nombre);
        }

        [TestMethod]
        public void ObtenerTarjeta()
        {
            Categoria categoria = new Categoria(categoriaNombre);

            Tarjeta tarjeta = new Tarjeta(null, null, numeroTarjeta, 0, fecha, categoria, null);
            Tarjeta tajrteaObtenida = controladorObtener.ObtenerTarjeta(tarjeta, tarjetaRepo);

            Assert.IsNotNull(tajrteaObtenida);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionIntentoDeObtencionDeObjetoInexistente))]
        public void QuererObtenerTarjetaInexistente()
        {
            Categoria categoria = new Categoria(categoriaNombre);

            Tarjeta tarjeta = new Tarjeta(null, null, numeroTarjeta, 0, fecha, categoria, null);
            Tarjeta tajrteaObtenida = controladorObtener.ObtenerTarjeta(tarjeta, tarjetaRepo);
        }

        [TestMethod]
        public void VerificarNumeroTarjejeta()
        {
            Categoria categoria = new Categoria(categoriaNombre);

            Tarjeta tarjeta = new Tarjeta(null, null, numeroTarjeta, 0, fecha, categoria, null);
            Tarjeta tajrteaObtenida = controladorObtener.ObtenerTarjeta(tarjeta, tarjetaRepo);

            Assert.IsTrue(tajrteaObtenida.Numero == numeroTarjeta);
        }

        [TestMethod]
        public void VerificarCategoriaTarjejeta()
        {
            Categoria categoria = new Categoria(categoriaNombre);

            Tarjeta tarjeta = new Tarjeta(null, null, numeroTarjeta, 0, fecha, categoria, null);
            Tarjeta tajrteaObtenida = controladorObtener.ObtenerTarjeta(tarjeta, tarjetaRepo);

            Assert.IsTrue(tajrteaObtenida.Categoria.Nombre == categoria.Nombre);
        }

        [TestMethod]
        public void ObtenerCredencial()
        {
            Categoria categoria = new Categoria(categoriaNombre);
            Contraseña contraseñaDominio = new Contraseña(contraseña);
            Credencial credencial = new Credencial(usuarioCredencial, contraseñaDominio, null, null, categoria);

            Credencial credencialObtenida= controladorObtener.ObtenerCredencial(credencial, tarjetaRepo);

            Assert.IsNotNull(credencialObtenida);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionIntentoDeObtencionDeObjetoInexistente))]
        public void QuererObtenerCredencialInexistente()
        {
            Categoria categoria = new Categoria(categoriaNombre);
            Contraseña contraseñaDominio = new Contraseña(contraseña);
            Credencial credencial = new Credencial(usuarioCredencial, "No existe", null, null, categoria);

            Credencial credencialObtenida = controladorObtener.ObtenerCredencial(credencial, credencialRepo);

        }

        [TestMethod]
        public void ObtenerTodasMisCategorias()
        {
            List<Categoria> categorias = controladorObtener.ObtenerCategorias(categoriaRepo);
            Assert.IsTrue(categorias.Count==1);
        }

        [TestMethod]
        public void ObtenerTodasMisTarjetas()
        {
            List<Tarjeta> tarjetas = controladorObtener.ObtenerTarjetas(tarjetaRepo);
            Assert.IsTrue(tarjetas.Count == 1);
        }

        [TestMethod]
        public void ObtenerTodasMisCredenciales()
        {
            List<Credencial> credenciales = controladorObtener.ObtenerCredenciales(credencialRepo);
            Assert.IsTrue(credenciales.Count == 1);
        }

    }
}
