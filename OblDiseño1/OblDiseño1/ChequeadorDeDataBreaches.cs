using System;
using System.Collections.Generic;

namespace OblDiseño1
{
    public class ChequeadorDeDataBreaches
    {

        public Usuario Usuario { get; set; }

        private const int asciNumericoDesde = 48;
        private const int asciNumericoHasta = 57;
        private const int cantTiposObjetosVulnerables = 2;
        public ChequeadorDeDataBreaches(Usuario unUsuario)
        {
            Usuario = unUsuario;
        }

        public List<Object>[] ObtenerEntidadesVulneradas(List<string> datosDelDataBreach)
        {
            List<object>[] datosVulnerados = new List<object>[cantTiposObjetosVulnerables];
            
            datosVulnerados[0]= ObtenerTarjetasVulneradas(datosDelDataBreach);
            datosVulnerados[1] = ObtenerDuplasVulneradas(datosDelDataBreach);

            return datosVulnerados;
        }

        private List<Object> ObtenerDuplasVulneradas(List<string> datosDelDataBreach)
        {
            List<Object> duplasVulneradas = new List<Object>();

            foreach(string dato in datosDelDataBreach)
                foreach (Dupla_UsuarioContrasenia dupla in Usuario.ObtenerDuplas())
                    if (dato.Equals(dupla.Contrasenia))
                        duplasVulneradas.Add(dupla);

            return duplasVulneradas;
        }

        private List<Object> ObtenerTarjetasVulneradas(List<string> datosDelDataBreach)
        {
            List<Object> tarjetasVulneradas = new List<Object>();

            foreach (string dato in datosDelDataBreach)
                if (EsNumeroDeTarjetaValido(dato))
                    foreach (Tarjeta tarjeta in Usuario.ObtenerTarjetas())
                        if (dato == tarjeta.Numero)
                            tarjetasVulneradas.Add(tarjeta);

            return tarjetasVulneradas;
        }


        private bool EsNumeroDeTarjetaValido(string posibleNumeroDeTarjeta)
        {
            return (posibleNumeroDeTarjeta.Length == 16) ? true : false;
        }

    }
}
