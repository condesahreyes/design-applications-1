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
    public class ControladorEliminarTest
    {
        private ControladorAlta controladorAlta;
        private ControladorEliminar controladorEliminar;
        private Categoria categoria;
        private DateTime fecha;

        [TestInitialize]
        public void Setup()
        {
            EliminarDatosBD();
            controladorAlta = new ControladorAlta();
            controladorEliminar = new ControladorEliminar();
            categoria = new Categoria("Trabajo");
            fecha = new DateTime(2021, 12, 15);
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

        [TestMethod]
        public void VerificarQueSeEliminoUsuario()
        {
            int cantidadUsuariosAgregados = 1;
            Usuario usuarioPrueba = new Usuario("Hernán", "Contraseña");
            AgregarUsuario(usuarioPrueba);


            EliminarUsuario(usuarioPrueba);
            int cantidadDeUsuariosAEliminar = 1;
            int cantidadDeUsuariosDespuesDeEliminar = 0;
            using (Contexto contexto = new Contexto())
            {
                foreach (var entidadUsuario in contexto.usuarios)
                    cantidadDeUsuariosDespuesDeEliminar++;
            }

            Assert.IsTrue(cantidadUsuariosAgregados == (cantidadDeUsuariosDespuesDeEliminar + cantidadDeUsuariosAEliminar));
        }

        [TestMethod]
        public void VerificarQueSeEliminoElUsuarioCorrecto()
        {
            Usuario usuarioPrueba = new Usuario("Hernán", "Contraseña");
            AgregarUsuario(usuarioPrueba);

            EliminarUsuario(usuarioPrueba);
            bool seEliminoElUsuarioCorrecto = true;
            using (Contexto contexto = new Contexto())
            {
                foreach (var entidadUsuario in contexto.usuarios)
                    if (entidadUsuario.Nombre == usuarioPrueba.Nombre
                        && entidadUsuario.Contrasenia == usuarioPrueba.Contrasenia)
                        seEliminoElUsuarioCorrecto = false;
            }


            Assert.IsTrue(seEliminoElUsuarioCorrecto);
        }


        [TestMethod]
        public void VerificarQueSeEliminoTarjeta()
        {
            int cantidadTarjetasAgregadas = 1;
            Usuario usuarioPrueba = new Usuario("Miguel", "ContraMiguel");
            Tarjeta tarjeta = new Tarjeta("Visas", "Tipo 1", "1234567891234567", 111, fecha, categoria, null);
            AgregarUsuario(usuarioPrueba);
            AgregarCategoria(categoria, usuarioPrueba);
            AgregarTarjeta(tarjeta, usuarioPrueba);


            EliminarTarjeta(tarjeta, usuarioPrueba);
            int cantidadDeTarjetasAEliminar = 1;
            int cantidadDeTarjetasDespuesDeEliminar = 0;
            using (Contexto contexto = new Contexto())
            {
                foreach (var entidadTarjetas in contexto.tarjetas)
                    cantidadDeTarjetasDespuesDeEliminar++;
            }

            Assert.IsTrue(cantidadTarjetasAgregadas == (cantidadDeTarjetasDespuesDeEliminar + cantidadDeTarjetasAEliminar));
        }

        [TestMethod]
        public void VerificarQueSeEliminoLaTarjetaCorrecta()
        {
            Usuario usuarioPrueba = new Usuario("Miguel", "ContraMiguel");
            Tarjeta tarjeta = new Tarjeta("Visas", "Tipo 1", "1234567891234567", 111, fecha, categoria, null);
            AgregarUsuario(usuarioPrueba);

            EliminarTarjeta(tarjeta, usuarioPrueba);
            bool seEliminoLaTarjetaCorrecta = true;
            using (Contexto contexto = new Contexto())
            {
                foreach (var entidadTarjeta in contexto.tarjetas)
                    if (entidadTarjeta.UsuarioGestorNombre == usuarioPrueba.Nombre
                        && entidadTarjeta.Numero == tarjeta.Numero)
                        seEliminoLaTarjetaCorrecta = false;
            }


            Assert.IsTrue(seEliminoLaTarjetaCorrecta);
        }


        [TestMethod]
        public void VerificarQueSeEliminoCredencial()
        {
            int cantidadCredencialesAgregadas = 1;
            Contraseña contraseña = new Contraseña("Una contraseña");
            Credencial credencial = new Credencial("Perez", contraseña,
                "Instagram", "Nota", categoria);
            Usuario usuarioPrueba = new Usuario("Usuario", "ContraMiguelAngel");
            AgregarUsuario(usuarioPrueba);
            AgregarCategoria(categoria, usuarioPrueba);
            AgregarCredencial(credencial, usuarioPrueba);


            EliminarCredencial(credencial, usuarioPrueba);
            int cantidadDeCredencialesAEliminar = 1;
            int cantidadDeCredencialesDespuesDeEliminar = 0;
            using (Contexto contexto = new Contexto())
            {
                foreach (var entidadTarjetas in contexto.credenciales)
                    cantidadDeCredencialesDespuesDeEliminar++;
            }

            Assert.IsTrue(cantidadCredencialesAgregadas == (cantidadDeCredencialesDespuesDeEliminar + cantidadDeCredencialesAEliminar));
        }

        [TestMethod]
        public void VerificarQueSeEliminoLaCredencialCorrecta()
        {
            Contraseña contraseña = new Contraseña("Una contraseña");
            Credencial credencial = new Credencial("Perez", contraseña,
                "Instagram", "Nota", categoria);
            Usuario usuarioPrueba = new Usuario("Usuario", "ContraMiguelAngel");
            AgregarUsuario(usuarioPrueba);
            AgregarCategoria(categoria, usuarioPrueba);
            AgregarCredencial(credencial, usuarioPrueba);

            EliminarCredencial(credencial, usuarioPrueba);
            bool seEliminoLaCredencialCorrecta = true;
            using (Contexto contexto = new Contexto())
            {
                foreach (var entidadCredencial in contexto.credenciales)
                    if (entidadCredencial.UsuarioGestorNombre == usuarioPrueba.Nombre &&
                        entidadCredencial.NombreUsuario == credencial.NombreUsuario &&
                        entidadCredencial.NombreSitioApp == credencial.NombreSitioApp)
                        seEliminoLaCredencialCorrecta = false;
            }

            Assert.IsTrue(seEliminoLaCredencialCorrecta);
        }




        private void AgregarUsuario(Usuario usuario)
        {
            IRepositorio<Usuario> iRepoUsuario = new UsuarioRepositorio();
            controladorAlta.AgregarUsuario(usuario, iRepoUsuario);
        }
        private void EliminarUsuario(Usuario usuario)
        {
            IRepositorio<Usuario> iRepoUsuario = new UsuarioRepositorio();
            controladorEliminar.EliminarUsuario(usuario, iRepoUsuario);
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
        private void EliminarTarjeta(Tarjeta tarjeta, Usuario usuario)
        {
            IRepositorio<Tarjeta> iRepoTarjeta = new TarjetaRepositorio(usuario);
            controladorAlta.EliminarTarjeta(tarjeta, iRepoTarjeta);

        }

        private void AgregarCredencial(Credencial credencial, Usuario usuario)
        {
            IRepositorio<Credencial> iRepoCredencial = new CredencialRepositorio(usuario);
            controladorAlta.AgregarCredencial(credencial, iRepoCredencial);
        }
        private void EliminarCredencial(Credencial credencial, Usuario usuario)
        {
            IRepositorio<Credencial> iRepoCredencial = new CredencialRepositorio(usuario);
            controladorAlta.EliminarCredencial(credencial, iRepoCredencial);
        }
    }
}
