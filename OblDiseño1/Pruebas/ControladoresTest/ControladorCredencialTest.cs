using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1.ControladoresPorEntidad;
using AccesoDatos.Entidades_Datos;
using System.Collections.Generic;
using OblDiseño1.Manejadores;
using OblDiseño1.Entidades;
using AccesoDatos;
using System.Linq;
using OblDiseño1;
using System;

namespace Pruebas.ControladoresTest
{
    [TestClass]
    public class UnitTest2
    {
        private const string usuarioCredencial = "Usuario insta";
        private static string contraseña = "Mi contraseña";
        private const string categoriaNombre = "Personal";
        private const string credencialSitio = "Facebook";
        private const string usuarioGestor = "Hernán";
        private const string credencialNota = "Nota ";

        private static Usuario usuario;
        private ControladorCredencial controladorCredencial;
        private Categoria categoria;

        private DateTime fecha;

        [TestInitialize]
        public void Setup()
        {
            EliminarDatosBD();
            usuario = new Usuario(usuarioGestor, contraseña);
            controladorCredencial = new ControladorCredencial(usuario);
            categoria = new Categoria(categoriaNombre);
            fecha = new DateTime(2021, 12, 15);
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

        [TestMethod]
        public void ObtenerTodasMisCredenciales()
        {
            AgregarUnRegistroEnCadaTabla();
            List<Credencial> credenciales = controladorCredencial.ObtenerTodasMisCredenciales();
            Assert.IsTrue(credenciales.Count == 1);
        }

        [TestMethod]
        public void ObtenerCredencial()
        {
            AgregarUnRegistroEnCadaTabla();
            Categoria categoria = new Categoria(categoriaNombre);
            string contraseñaEncriptada = EncriptarContraseña(contraseña);
            Contraseña contraseñaDominio = new Contraseña(contraseñaEncriptada);

            Credencial credencial = new Credencial(usuarioCredencial, contraseñaDominio,
                 credencialSitio, credencialNota, categoria);

            Credencial credencialObtenida = controladorCredencial.ObtenerCredencial(credencial);

            Assert.IsNotNull(credencialObtenida);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionIntentoDeObtencionDeObjetoInexistente))]
        public void QuererObtenerCredencialInexistente()
        {
            AgregarUnRegistroEnCadaTabla();
            Categoria categoria = new Categoria(categoriaNombre);
            Contraseña contraseñaDominio = new Contraseña(contraseña);
            Credencial credencial = new Credencial("noExiste", contraseñaDominio,
                credencialSitio, credencialNota, categoria);

            Credencial credencialObtenida = controladorCredencial.ObtenerCredencial(credencial);

        }

        [TestMethod]
        public void VerificarQueSeEliminoCredencial()
        {
            AgregarUnRegistroEnCadaTabla();
            int cantidadCredencialesAgregadas = 1;

            Categoria categoria = new Categoria(categoriaNombre);
            Contraseña contraseñaDominio = new Contraseña(contraseña);
            Credencial credencial = new Credencial(usuarioCredencial,
                contraseñaDominio, credencialSitio, credencialNota, categoria);

            EliminarCredencial(credencial);

            int cantidadDeCredencialesAEliminar = 1;
            int cantidadDeCredencialesDespuesDeEliminar = 0;

            using (Contexto contexto = new Contexto())
                foreach (var entidadTarjetas in contexto.credenciales)
                    cantidadDeCredencialesDespuesDeEliminar++;

            Assert.IsTrue(cantidadCredencialesAgregadas == (
                cantidadDeCredencialesDespuesDeEliminar + cantidadDeCredencialesAEliminar));
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionIntentoDeObtencionDeObjetoInexistente))]
        public void IntentarEliminarCredencialInexistente()
        {
            AgregarUnRegistroEnCadaTabla();
            Categoria categoria = new Categoria(categoriaNombre);
            Contraseña contraseñaDominio = new Contraseña(contraseña);
            Credencial credencial = new Credencial("noExiste", contraseñaDominio,
                credencialSitio, credencialNota, categoria);

            EliminarCredencial(credencial);
        }

        [TestMethod]
        public void VerificarQueSeEliminoLaCredencialCorrecta()
        {
            AgregarUnRegistroEnCadaTabla();
            Categoria categoria = new Categoria(categoriaNombre);
            Contraseña contraseñaDominio = new Contraseña(contraseña);
            Credencial credencial = new Credencial(usuarioCredencial, contraseñaDominio,
                credencialSitio, credencialNota, categoria);

            EliminarCredencial(credencial);

            bool seEliminoLaCredencialCorrecta = true;
            using (Contexto contexto = new Contexto())
            {
                foreach (var entidadCredencial in contexto.credenciales)
                    if (entidadCredencial.UsuarioGestorNombre == usuario.Nombre &&
                        entidadCredencial.NombreUsuario == credencial.NombreUsuario &&
                        entidadCredencial.NombreSitioApp == credencial.NombreSitioApp)
                        seEliminoLaCredencialCorrecta = false;
            }

            Assert.IsTrue(seEliminoLaCredencialCorrecta);
        }


        [TestMethod]
        public void ModificarNombreUsuarioCredencial()
        {
            AgregarUnRegistroEnCadaTabla();
            string nombreUsuarioModificado = "nombreModificado";
            Contraseña contraseñaDominio = new Contraseña(contraseña);
            Credencial credencial = new Credencial(usuarioCredencial, contraseñaDominio,
                 credencialSitio, credencialNota, categoria);

            Credencial credencialModificada = new Credencial(nombreUsuarioModificado, contraseñaDominio,
                credencialSitio, credencialNota, categoria);

            controladorCredencial.ModificarMiCredencial(credencial, credencialModificada);

            bool mismoNombre = false;

            using (Contexto contexto = new Contexto())
                foreach (var unaCredencial in contexto.credenciales)
                    if (unaCredencial.NombreUsuario == nombreUsuarioModificado &&
                        usuario.Nombre == unaCredencial.UsuarioGestorNombre &&
                        unaCredencial.NombreSitioApp == credencial.NombreSitioApp)
                        mismoNombre = true;

            Assert.IsTrue(mismoNombre);
        }

        private void AgregarUnRegistroEnCadaTabla()
        {
            AgregarUsuario(usuarioGestor, contraseña);
            AgregarCategoria(categoriaNombre, usuarioGestor);
            AgregarCredencial(usuarioCredencial, categoriaNombre, usuarioGestor);
        }

        private void EliminarCredencial(Credencial credencial)
        {
            controladorCredencial.EliminarLaCredencial(credencial);
        }

        private void AgregarUsuario(Usuario usuario)
        {
            ControladorUsuario controladorUsuario = new ControladorUsuario();
            controladorUsuario.AgregarUsuario(usuario);
        }

        private void AgregarCategoria(Categoria categoria, Usuario usuario)
        {
            ControladorCategoria controladorCategoria = new ControladorCategoria(usuario);
            controladorCategoria.CrearCategoria(categoria.Nombre);
        }

        private void AgregarCredencial(Credencial credencial, Usuario usuario)
        {
            ControladorCredencial controladorCredencial = new ControladorCredencial(usuario);
            controladorCredencial.AgregarCredencial(credencial);
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
                entidadCredencial = new EntidadCredencial(nombreUsuario, credencialSitio,
                    credencialNota, idCategoria, usuarioDueño, idContraseña);

                contexto.credenciales.Add(entidadCredencial);
                contexto.SaveChanges();
            }
        }

        public void AgregarContraseña(string contraseña, int nivelSeguridadContrasenia)
        {
            EntidadContraseña entidadContraseña = new EntidadContraseña(contraseña, nivelSeguridadContrasenia);
            contraseña = EncriptarContraseña(contraseña);
            using (Contexto contexto = new Contexto())
            {
                contexto.contraseñas.Add(entidadContraseña);
                contexto.SaveChanges();
            }
        }

        private string EncriptarContraseña(string contraseña)
        {
            Encriptador encriptador = new Encriptador();

            string llave = encriptador.GenerarLlave();
            return encriptador.Encriptar(contraseña, llave);
        }
    }
}
