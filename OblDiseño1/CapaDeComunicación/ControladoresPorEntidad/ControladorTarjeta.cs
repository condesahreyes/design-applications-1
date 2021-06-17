using System.Collections.Generic;
using AccesoDatos;
using System;

namespace OblDiseño1.ControladoresPorEntidad
{
    public class ControladorTarjeta
    {

        private IRepositorio<Tarjeta> repositorioTarjeta;
        private Usuario usuario;

        public ControladorTarjeta(Usuario usuario)
        {
            this.usuario = usuario;
            this.repositorioTarjeta = new TarjetaRepositorio(this.usuario);
        }

        public void CrearTarjeta(string nombreTarjeta, string tipoTarjeta,
                string numeroTarjeta, int codigoSeguridad, DateTime fecha,
                Categoria categoria, string notaOpcional)
        {
            Tarjeta nuevaTarjeta = new Tarjeta(nombreTarjeta, tipoTarjeta,
                numeroTarjeta, codigoSeguridad, fecha, categoria, notaOpcional);

            repositorioTarjeta.Add(nuevaTarjeta);
        }

        public void CrearTarjeta(Tarjeta unaTarjeta)
        {
            repositorioTarjeta.Add(unaTarjeta);
        }

        public bool ExisteEsteNumeroTarjeta(string numeroTarjeta)
        {
            Tarjeta tarjeta = new Tarjeta();
            tarjeta.Numero = numeroTarjeta;

            return repositorioTarjeta.Existe(tarjeta);
        }

        public bool EsElMismoNumeroTarjeta(string numeroTarjeta1, string numeroTarjeta2)
        {
            return numeroTarjeta1 == numeroTarjeta2;
        }

        public void ModificarTarjeta(Tarjeta tarjetaOriginal, Tarjeta nuevaTarjeta)
        {
            repositorioTarjeta.Modificar(tarjetaOriginal, nuevaTarjeta);
        }

        public void EliminarLaTarjeta(Tarjeta tarjeta)
        {
            repositorioTarjeta.Delete(tarjeta);
        }

        public List<Tarjeta> ObtenerTodasMisTarjetas()
        {
            return repositorioTarjeta.GetAll();
        }
    }
}
