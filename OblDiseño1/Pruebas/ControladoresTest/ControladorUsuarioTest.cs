using System;
using AccesoDatos;
using AccesoDatos.Entidades_Datos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1;
using OblDiseño1.ControladoresPorEntidad;

namespace Pruebas.ControladoresTest
{
    [TestClass]
    public class ControladorUsuarioTest
    {
        private const string usuarioCredencial = "Usuario insta";
        private const string numeroTarjeta = "1234567891234567";
        private const string contraseña = "Mi contraseña";
        private const string categoriaNombre = "Personal";
        private const string credencialSitio = "Facebook";
        private const string nombreTarjeta = "Master Card";
        private const string usuarioGestor = "Hernán";
        private const string credencialNota = "Nota ";
        private const string tipoTarjeta = "Debito";

        private static Usuario usuario = new Usuario(usuarioGestor, contraseña);
        private Categoria categoria = new Categoria(categoriaNombre);


        private DateTime fecha;
        private ControladorUsuario controladorUsuario = new ControladorUsuario();

        [TestInitialize]
        public void Setup()
        {
            EliminarDatosBD();
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

            Assert.IsTrue(contidadUsuarios > 0);
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
        public void ObtenerUnUsuarioNoNull()
        {
            AgregarUnRegistroEnCadaTabla();
            Usuario usuarioObtenido = controladorUsuario.ObtenerUnUsuario(usuario);

            Assert.IsNotNull(usuarioObtenido);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionIntentoDeObtencionDeObjetoInexistente))]
        public void BuscarUsuarioInexistente()
        {
            AgregarUnRegistroEnCadaTabla();
            Usuario usaurioInexistente = new Usuario("Juancito", contraseña);
            Usuario usuarioObtenido = controladorUsuario.ObtenerUnUsuario(usaurioInexistente);
        }

        [TestMethod]
        public void VerificarNombreUsuarioGestor()
        {
            AgregarUnRegistroEnCadaTabla();
            Usuario usuario = new Usuario(usuarioGestor, contraseña);
            Usuario usuarioObtenido = controladorUsuario.ObtenerUnUsuario(usuario);

            Assert.IsTrue(usuarioObtenido.Nombre == usuarioGestor);
        }

        [TestMethod]
        public void ModificarContraseñaDelGestor()
        {
            AgregarUnRegistroEnCadaTabla();
            string contraseñaModificada = "otraContraseña";
            Usuario usuarioModificado = new Usuario(usuarioGestor, contraseñaModificada);
            controladorUsuario.ModificarUsuario(usuario, usuarioModificado);

            bool mismaContraseña = false;

            using (Contexto contexto = new Contexto())
                foreach (var usuario in contexto.usuarios)
                    mismaContraseña = usuario.Contrasenia == contraseñaModificada;

            Assert.IsTrue(mismaContraseña);
        }

        private void AgregarUsuario(Usuario usuario)
        {
            
            controladorUsuario.AgregarUsuario(usuario);
        }

        private void AgregarUnRegistroEnCadaTabla()
        {
            AgregarUsuario(usuarioGestor, contraseña);
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
    }
}
