using OblDiseño1.ControladoresPorFuncionalidad;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace OblDiseño1
{
    public class ChequeadorDeDataBreaches
    {
        public Usuario usuario { get; set; }

        public DateTime Fecha { get; set; }

        public List<Tarjeta> TarjetasVulneradas { get; set; }

        public List<Credencial> CredencialesVulneradas { get; set; }

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

        public List<Tarjeta> ObtenerTarjetasVulneradasDesdeArchivoTxt(string pathDelArchivo)
        {
            List<string> infoBreachada;
            using (StreamReader lector = new StreamReader(pathDelArchivo))
            {
                string infoBrachadaEnUnSoloString = lector.ReadLine();
                infoBreachada = infoBrachadaEnUnSoloString.Split('\t').ToList();
            }
            return ObtenerTarjetasVulneradas(infoBreachada);
        }

        public List<Credencial> ObtenerCredencialesVulneradasDesdeArchivoTxt(string pathDelArchivo)
        {
            List<string> infoBreachada;
            using (StreamReader lector = new StreamReader(pathDelArchivo))
            {
                string infoBrachadaEnUnSoloString = lector.ReadLine();
                infoBreachada = infoBrachadaEnUnSoloString.Split('\t').ToList();
            }
            return ObtenerCredencialesVulneradas(infoBreachada);
        }
    }
}
