using System.Collections.Generic;

namespace OblDiseño1
{
    public class ChequeadorDeDataBreaches
    {
        public Usuario usuario { get; set; }

        public ChequeadorDeDataBreaches(Usuario unUsuario)
        {
            usuario = unUsuario;
        }

        public List<Tarjeta> ObtenerTarjetasVulneradas(List<string> datosDelDataBreach)
        {
            List<Tarjeta> tarjetasVulneradas = new List<Tarjeta>();

            foreach (string dato in datosDelDataBreach) 
                if (Tarjeta.ValidarLargoNumeroDeTarjeta(dato) && this.usuario.RevisarSiLaTarjetaEsMia(dato))
                    tarjetasVulneradas.Add(this.usuario.ObtenerTarjetaDeNumero(dato));

            return tarjetasVulneradas;
        }

        public List<Credencial> ObtenerCredencialesVulneradas(List<string> datosDelDataBreach)
        {
            List<Credencial> credencialesVulneradas = new List<Credencial>();

            foreach (string dato in datosDelDataBreach)
                if (this.usuario.RevisarSiLaContraseniaEsMia(dato))
                    credencialesVulneradas.AddRange(this.usuario.ObtenerDuplasConLaContrasenia(dato));

            return credencialesVulneradas;
        }
    }
}
