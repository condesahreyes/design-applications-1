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
    public class ControladorTarjetaTest
    {
        private const string numeroTarjeta = "1234567891234567";
        private const string contraseña = "Mi contraseña";
        private const string categoriaNombre = "Personal";
        private const string nombreTarjeta = "Master Card";
        private const string usuarioGestor = "Hernán";
        private const string credencialNota = "Nota ";
        private const string tipoTarjeta = "Debito";

        private ControladorTarjeta controladorTarjeta;
        private static Usuario usuario = new Usuario(usuarioGestor, contraseña);

        private Categoria categoria;
        private DateTime fecha;

        [TestInitialize]
        public void Setup()
        {
            EliminarDatosBD();
            categoria = new Categoria(categoriaNombre);
            fecha = new DateTime(2021, 12, 15);
            controladorTarjeta = new ControladorTarjeta(usuario);
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
        public void QuererObtenerTarjetaInexistente()
        {
            string numeroTarjetaInexistente = "1245551234555555";
            bool esMismaTarjeta = controladorTarjeta.EsElMismoNumeroTarjeta(numeroTarjetaInexistente, numeroTarjeta);
            Assert.IsFalse(esMismaTarjeta);
        }

        [TestMethod]
        public void ExisteElNumeroDeTarjeta()
        {
            AgregarUnRegistroEnCadaTabla();
            Categoria categoria = new Categoria(categoriaNombre);

            bool existeTarjeta = controladorTarjeta.ExisteEsteNumeroTarjeta(numeroTarjeta);

            Assert.IsTrue(existeTarjeta);
        }

        [TestMethod]
        public void ObtenerTodasMisTarjetas()
        {
            AgregarUnRegistroEnCadaTabla();
            List<Tarjeta> tarjetas = controladorTarjeta.ObtenerTodasMisTarjetas();
            Assert.IsTrue(tarjetas.Count == 1);
        }

        [TestMethod]
        public void VerificarQueSeEliminoTarjeta()
        {
            AgregarUnRegistroEnCadaTabla();
            int cantidadTarjetasAgregadas = 1;

            Categoria categoria = new Categoria(categoriaNombre);
            Tarjeta tarjeta = new Tarjeta(nombreTarjeta, tipoTarjeta,
                numeroTarjeta, 1234, fecha, categoria, credencialNota);

            EliminarTarjeta(tarjeta, usuario);

            int cantidadDeTarjetasAEliminar = 1;
            int cantidadDeTarjetasDespuesDeEliminar = 0;

            using (Contexto contexto = new Contexto())
                foreach (var entidadTarjetas in contexto.tarjetas)
                    cantidadDeTarjetasDespuesDeEliminar++;

            Assert.IsTrue(cantidadTarjetasAgregadas ==
                (cantidadDeTarjetasDespuesDeEliminar + cantidadDeTarjetasAEliminar));
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionIntentoDeObtencionDeObjetoInexistente))]
        public void IntentarEliminarTarjetaInexistente()
        {
            AgregarUnRegistroEnCadaTabla();
            string numeroTarjetaInexistente = "1245551234555555";

            Categoria categoria = new Categoria(categoriaNombre);
            Tarjeta tarjeta = new Tarjeta(nombreTarjeta, tipoTarjeta,
                numeroTarjetaInexistente, 1234, fecha, categoria, credencialNota);

            EliminarTarjeta(tarjeta, usuario);
        }

        [TestMethod]
        public void ModificarNumeroTarjeta()
        {
            AgregarUnRegistroEnCadaTabla();
            string numeroModificado = "1234555555123111";

            Tarjeta tarjeta = new Tarjeta(nombreTarjeta, tipoTarjeta,
                numeroTarjeta, 1234, fecha, categoria, credencialNota);
            Tarjeta tarjetaModificada = new Tarjeta(nombreTarjeta, tipoTarjeta,
                "1234555555123111", 1234, fecha, categoria, credencialNota);

            controladorTarjeta.ModificarTarjeta(tarjeta, tarjetaModificada);

            bool mismoNumero = false;

            using (Contexto contexto = new Contexto())
                foreach (var unaTarjeta in contexto.tarjetas)
                    if (unaTarjeta.Numero == numeroModificado && usuario.Nombre == unaTarjeta.UsuarioGestorNombre)
                        mismoNumero = true;

            Assert.IsTrue(mismoNumero);
        }

        [TestMethod]
        public void VerificarQueSeEliminoLaTarjetaCorrecta()
        {
            AgregarUnRegistroEnCadaTabla();
            Categoria categoria = new Categoria(categoriaNombre);
            Tarjeta tarjeta = new Tarjeta(nombreTarjeta, tipoTarjeta, numeroTarjeta, 1234,
                fecha, categoria, credencialNota);

            EliminarTarjeta(tarjeta, usuario);

            bool seEliminoLaTarjetaCorrecta = true;

            using (Contexto contexto = new Contexto())
                foreach (var entidadTarjeta in contexto.tarjetas)
                    if (entidadTarjeta.UsuarioGestorNombre == usuario.Nombre
                        && entidadTarjeta.Numero == tarjeta.Numero)
                        seEliminoLaTarjetaCorrecta = false;

            Assert.IsTrue(seEliminoLaTarjetaCorrecta);
        }
        private void EliminarTarjeta(Tarjeta tarjeta, Usuario usuario)
        {
            controladorTarjeta.EliminarLaTarjeta(tarjeta);

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

        private void AgregarTarjeta(Tarjeta tarjeta, Usuario usuario)
        {
            ControladorTarjeta controladorTarjeta = new ControladorTarjeta(usuario);
            controladorTarjeta.CrearTarjeta(tarjeta);
        }

        private void AgregarUnRegistroEnCadaTabla()
        {
            AgregarUsuario(usuarioGestor, contraseña);
            AgregarCategoria(categoriaNombre, usuarioGestor);
            AgregarTarjeta(numeroTarjeta, usuarioGestor, categoriaNombre);
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
    }
}
