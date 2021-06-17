using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1.ControladoresPorEntidad;
using AccesoDatos.Entidades_Datos;
using System.Collections.Generic;
using AccesoDatos;
using OblDiseño1;
using System;

namespace Pruebas.ControladoresTest
{
    [TestClass]
    public class UnitTest1
    {
        private const string categoriaNombre = "Personal";
        private const string usuarioGestor = "Hernán";
        private const string contraseña = "Mi contraseña";

        private Categoria categoria;
        private DateTime fecha;
        private ControladorCategoria controladorCategoria;
        private static Usuario usuario;

        [TestInitialize]
        public void Setup()
        {
            EliminarDatosBD();
            categoria = new Categoria("Personal");
            fecha = new DateTime(2021, 12, 15);
            usuario = new Usuario(usuarioGestor, contraseña);
            controladorCategoria = new ControladorCategoria(usuario);
        }

        private void EliminarDatosBD()
        {
            using (Contexto contexto = new Contexto())
            {
                contexto.dataBreachCredencial.RemoveRange(contexto.dataBreachCredencial);
                contexto.dataBreachTarjetas.RemoveRange(contexto.dataBreachTarjetas);
                contexto.dataBreach.RemoveRange(contexto.dataBreach);
                contexto.credenciales.RemoveRange(contexto.credenciales);
                contexto.contraseñas.RemoveRange(contexto.contraseñas);
                contexto.tarjetas.RemoveRange(contexto.tarjetas);
                contexto.categorias.RemoveRange(contexto.categorias);
                contexto.usuarios.RemoveRange(contexto.usuarios);
                contexto.SaveChanges();
            }
        }

        [TestMethod]
        public void VerificarQueSeAgregoCategoria()
        {
            Categoria categoria = new Categoria("Personal");

            AgregarUsuario(usuario);
            AgregarCategoria(categoria, usuario);

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
            AgregarUsuario(usuario);
            AgregarCategoria(categoria, usuario);

            bool seAgregoCorrectamente = false;

            using (Contexto contexto = new Contexto())
            {
                foreach (var entidadCategoria in contexto.categorias)
                    if (entidadCategoria.UsuarioNombre == usuario.Nombre
                        && entidadCategoria.NombreCategoria == categoria.Nombre)
                        seAgregoCorrectamente = true;
            }

            Assert.IsTrue(seAgregoCorrectamente);
        }

        [TestMethod]
        public void ObtenerTodasMisCategorias()
        {
            AgregarUnRegistroEnCadaTabla();
            List<Categoria> categorias = controladorCategoria.ObtenerCategorias();
            Assert.IsTrue(categorias.Count == 1);
        }

        [TestMethod]
        public void ObtenerCategoria()
        {
            AgregarUnRegistroEnCadaTabla();
            Categoria categoria = new Categoria(categoriaNombre);
            Categoria usuarioObtenido = controladorCategoria.ObtenerCategoria(categoria.Nombre);

            Assert.IsTrue(usuarioObtenido.Nombre == categoriaNombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionIntentoDeObtencionDeObjetoInexistente))]
        public void QuererObtenerCategoriaInexistente()
        {
            AgregarUnRegistroEnCadaTabla();
            Categoria categoriaNoExiste = new Categoria("NoExiste");
            Categoria usuarioObtenido = controladorCategoria.ObtenerCategoria(categoriaNoExiste.Nombre);
        }

        [TestMethod]
        public void VerificarCategoriaNombre()
        {
            AgregarUnRegistroEnCadaTabla();
            Categoria categoria = new Categoria(categoriaNombre);
            Categoria categoriaObtenida = controladorCategoria.ObtenerCategoria(categoria.Nombre);

            Assert.IsTrue(categoria.Nombre == categoriaObtenida.Nombre);
        }

        [TestMethod]
        public void ModificarNombreCategoria()
        {
            AgregarUnRegistroEnCadaTabla();
            string nombreModificado = "Es modificada";

            Categoria categoriaModificada = new Categoria(nombreModificado);
            controladorCategoria.ModificarCategoria(ref categoria, categoriaModificada.Nombre);

            bool mismaCategoria = false;

            using (Contexto contexto = new Contexto())
                foreach (var categoriaRecorre in contexto.categorias)
                    if (categoriaRecorre.NombreCategoria == nombreModificado && usuario.Nombre == categoriaRecorre.UsuarioNombre)
                        mismaCategoria = categoriaRecorre.NombreCategoria == nombreModificado;

            Assert.IsTrue(mismaCategoria);
        }

        private void AgregarUsuario(Usuario usuario)
        {
            ControladorUsuario controladorUsuario = new ControladorUsuario();
            controladorUsuario.AgregarUsuario(usuario);
        }

        private void AgregarCategoria(Categoria categoria, Usuario usuario)
        {
            controladorCategoria.CrearCategoria(categoria.Nombre);
        }

        private void AgregarUnRegistroEnCadaTabla()
        {
            AgregarUsuario(usuarioGestor, contraseña);
            AgregarCategoria(categoriaNombre, usuarioGestor);
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

    }
}

