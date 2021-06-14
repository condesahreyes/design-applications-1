using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1.ControladoresPorFuncionalidad;
using AccesoDatos.Entidades_Datos;
using System.Collections.Generic;
using OblDiseño1.Entidades;
using AccesoDatos;
using System.Linq;
using OblDiseño1;
using System;

namespace Pruebas
{
    [TestClass]
    public class ControladorEliminarTest
    {
        private ControladorEliminar controladorEliminar = new ControladorEliminar();

        private DateTime fecha;

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

        private IRepositorio<Credencial> credencialRepo = new CredencialRepositorio(usuario);
        private IRepositorio<Categoria> categoriaRepo = new CategoriaRepositorio(usuario);
        private IRepositorio<Tarjeta> tarjetaRepo = new TarjetaRepositorio(usuario);
        private IRepositorio<Usuario> usuarioRepo = new UsuarioRepositorio();

        [TestInitialize]
        public void Setup()
        {
            EliminarDatosBD();
            fecha = new DateTime(2021, 12, 15);
            AgregarUnRegistroEnCadaTabla();
        }

        [TestMethod]
        public void VerificarQueSeEliminoTarjeta()
        {
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
            string numeroTarjetaInexistente = "1245551234555555";

            Categoria categoria = new Categoria(categoriaNombre);
            Tarjeta tarjeta = new Tarjeta(nombreTarjeta, tipoTarjeta,
                numeroTarjetaInexistente, 1234, fecha, categoria, credencialNota);

            EliminarTarjeta(tarjeta, usuario);
        }

        [TestMethod]
        public void VerificarQueSeEliminoLaTarjetaCorrecta()
        {
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

        [TestMethod]
        public void VerificarQueSeEliminoCredencial()
        {
            int cantidadCredencialesAgregadas = 1;

            Categoria categoria = new Categoria(categoriaNombre);
            Contraseña contraseñaDominio = new Contraseña(contraseña);
            Credencial credencial = new Credencial(usuarioCredencial, 
                contraseñaDominio, credencialSitio, credencialNota, categoria);

            EliminarCredencial(credencial, usuario);

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
            Categoria categoria = new Categoria(categoriaNombre);
            Contraseña contraseñaDominio = new Contraseña(contraseña);
            Credencial credencial = new Credencial("noExiste", contraseñaDominio, 
                credencialSitio, credencialNota, categoria);

            EliminarCredencial(credencial, usuario);
        }

        [TestMethod]
        public void VerificarQueSeEliminoLaCredencialCorrecta()
        {
            Categoria categoria = new Categoria(categoriaNombre);
            Contraseña contraseñaDominio = new Contraseña(contraseña);
            Credencial credencial = new Credencial(usuarioCredencial, contraseñaDominio, 
                credencialSitio, credencialNota, categoria);

            EliminarCredencial(credencial, usuario);

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

        private void EliminarTarjeta(Tarjeta tarjeta, Usuario usuario)
        {
            IRepositorio<Tarjeta> iRepoTarjeta = new TarjetaRepositorio(usuario);
            controladorEliminar.EliminarTarjeta(tarjeta, iRepoTarjeta);

        }

        private void EliminarCredencial(Credencial credencial, Usuario usuario)
        {
            IRepositorio<Credencial> iRepoCredencial = new CredencialRepositorio(usuario);
            controladorEliminar.EliminarCredencial(credencial, iRepoCredencial);
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
            EntidadTarjeta entidadTarjeta = new EntidadTarjeta(credencialNota, nombreTarjeta, 
                tipoTarjeta, numeroTarjeta, 1234,
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
                entidadCredencial = new EntidadCredencial(nombreUsuario, credencialSitio, credencialNota, 
                    idCategoria, usuarioDueño, idContraseña);

                contexto.credenciales.Add(entidadCredencial);
                contexto.SaveChanges();
            }
        }

        public void AgregarContraseña(string contraseña, int nivelSeguridadContrasenia)
        {
            EntidadContraseña entidadContraseña = new EntidadContraseña(contraseña, 
                nivelSeguridadContrasenia);
            using (Contexto contexto = new Contexto())
            {
                contexto.contraseñas.Add(entidadContraseña);
                contexto.SaveChanges();
            }
        }
    }
}
