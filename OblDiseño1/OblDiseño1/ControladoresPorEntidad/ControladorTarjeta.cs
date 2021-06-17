using OblDiseño1.ControladoresPorFuncionalidad;
using System;
using System.Collections.Generic;

namespace OblDiseño1.ControladoresPorEntidad
{
    public class ControladorTarjeta
    {
        private ControladorAlta crear = new ControladorAlta();
        private ControladorModificar modificar = new ControladorModificar();
        private ControladorObtener obtener = new ControladorObtener();
        private ControladorEliminar eliminar= new ControladorEliminar();

        private IRepositorio<Tarjeta> repositorioTarjeta;
        private Usuario usuario;

        public ControladorTarjeta(Usuario usuario, IRepositorio<Tarjeta> repositorioTarjeta)
        {
            this.usuario = usuario;
            this.repositorioTarjeta = repositorioTarjeta;
        }

        public void CrearTarjeta(string nombreTarjeta, string tipoTarjeta,
                string numeroTarjeta, int codigoSeguridad, DateTime fecha,
                Categoria categoria, string notaOpcional)
        {
            Tarjeta nuevaTarjeta = new Tarjeta(nombreTarjeta, tipoTarjeta,
                numeroTarjeta, codigoSeguridad, fecha, categoria, notaOpcional);

            crear.AgregarTarjeta(nuevaTarjeta, repositorioTarjeta);
        }

        public bool ExisteEsteNumeroTarjeta(string numeroTarjeta)
        {
            Tarjeta tarjeta = new Tarjeta();
            tarjeta.Numero = numeroTarjeta;

            return obtener.ExisteTarjeta(tarjeta, repositorioTarjeta);
        }

        public bool EsElMismoNumeroTarjeta(string numeroTarjeta1, string numeroTarjeta2)
        {
            return numeroTarjeta1 == numeroTarjeta2;
        }

        public void ModificarTarjeta(Tarjeta tarjetaOriginal, Tarjeta nuevaTarjeta)
        {

            modificar.ModificarTarjeta(tarjetaOriginal, nuevaTarjeta, repositorioTarjeta);
        }

        public void EliminarLaTarjeta(Tarjeta tarjeta)
        {
            eliminar.EliminarTarjeta(tarjeta, repositorioTarjeta);
        }

        public List<Tarjeta> ObtenerTodasMisTarjetas()
        {
            return obtener.ObtenerTarjetas(repositorioTarjeta);
        }
    }
}
