using System;
using System.Collections.Generic;

namespace OblDiseño1
{
    public class ChequeadorDeDataBreaches
    {

        public Usuario Usuario { get; set; }

        private const int asciNumericoDesde = 48;
        private const int asciNumericoHasta = 57;

        public ChequeadorDeDataBreaches(Usuario unUsuario)
        {
            Usuario = unUsuario;
        }

        public List<Object> ObtenerEntidadesVulneradas(List<string> datosDelDataBreach)
        {
            List<Object> datosVulnerados = new List<Object>();
            List<Object> tarjetasVulneradas = ObtenerTarjetasVulneradas(datosDelDataBreach);
            List<Object> duplasVulneradas = ObtenerDuplasVulneradas(datosDelDataBreach);

            if (tarjetasVulneradas != null) datosVulnerados.AddRange(tarjetasVulneradas);
            if (duplasVulneradas != null) datosVulnerados.AddRange(duplasVulneradas);

            return datosVulnerados;
        }

        private List<Object> ObtenerDuplasVulneradas(List<string> datosDelDataBreach)
        {
            List<Object> duplasVulneradas = new List<Object>();

            foreach(string dato in datosDelDataBreach)
                foreach (Dupla_UsuarioContrasenia dupla in Usuario.getDuplas())
                    if (dato.Equals(dupla.PssDupla))
                        duplasVulneradas.Add(dupla);

            return duplasVulneradas;
        }

        private List<Object> ObtenerTarjetasVulneradas(List<string> datosDelDataBreach)
        {
            List<Object> tarjetasVulneradas = new List<Object>();

            foreach (string dato in datosDelDataBreach)
                if (EsNumeroDeTarjetaValido(dato))
                    foreach (Tarjeta tarjeta in Usuario.getTarjetas())
                    {
                        string numeroDeLaTarjetaAString = "" + tarjeta.Numero;
                        if (dato.Equals(numeroDeLaTarjetaAString))
                            tarjetasVulneradas.Add(tarjeta);
                    }

            return tarjetasVulneradas;
        }


        private bool EsNumeroDeTarjetaValido(string posibleNumeroDeTarjeta)
        {
            bool esValido = true;

            if (!(posibleNumeroDeTarjeta.Length == 16))
                return false;
            else
                for (int i = 0; i < posibleNumeroDeTarjeta.Length && esValido; i++)
                {
                    int valorStringAsci = (int)posibleNumeroDeTarjeta[i];
                    if (valorStringAsci < asciNumericoDesde || valorStringAsci > asciNumericoHasta)
                        return false;
                }

            return true;
        }

    }
}
