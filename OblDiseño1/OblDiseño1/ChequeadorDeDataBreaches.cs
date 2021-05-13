using System;
using System.Collections.Generic;

namespace OblDiseño1
{
    public class ChequeadorDeDataBreaches
    {

        public Usuario usuario { get; set; }

        private const int cant_caracteres_en_numero_tarjeta = 16;
        private const int cant_tipos_de_entidades_vulneradas = 2;
        public ChequeadorDeDataBreaches(Usuario unUsuario)
        {
            usuario = unUsuario;
        }

        public List<Object>[] ObtenerEntidadesVulneradas(List<string> datosDelDataBreach)
        {
            List<object>[] entidadesVulneradas = new List<object>[cant_tipos_de_entidades_vulneradas];

            entidadesVulneradas[0]= ObtenerTarjetasVulneradas(datosDelDataBreach);
            entidadesVulneradas[1] = ObtenerDuplasVulneradas(datosDelDataBreach);

            return entidadesVulneradas;
        }

        private List<Object> ObtenerTarjetasVulneradas(List<string> datosDelDataBreach)
        {
            List<Object> tarjetasVulneradas = new List<Object>();

            foreach (string dato in datosDelDataBreach) 
                if (Tarjeta.ValidarLargoNumeroDeTarjeta(dato) && this.usuario.RevisarSiLaTarjetaEsMia(dato))
                    tarjetasVulneradas.Add(this.usuario.ObtenerTarjetaDeNumero(dato));

            return tarjetasVulneradas;
        }

        private List<Object> ObtenerDuplasVulneradas(List<string> datosDelDataBreach)
        {
            List<Object> duplasVulneradas = new List<Object>();

            foreach (string dato in datosDelDataBreach)
                if (this.usuario.RevisarSiLaContraseniaEsMia(dato))
                    duplasVulneradas.AddRange(this.usuario.ObtenerDuplasConLaContrasenia(dato));

            return duplasVulneradas;
        }
    }
}
