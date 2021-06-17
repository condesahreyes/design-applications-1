using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using OblDiseño1.Exception;

namespace OblDiseño1
{
    public class ChequeadorDeDataBreaches
    {
        public int id { get; set; }
        public Usuario usuario { get; set; }

        public DateTime Fecha { get; set; }

        public List<Tarjeta> TarjetasVulneradas { get; set; }

        public List<Credencial> CredencialesVulneradas { get; set; }

        public ChequeadorDeDataBreaches(Usuario unUsuario)
        {
            usuario = unUsuario;
            CredencialesVulneradas = new List<Credencial>();
            TarjetasVulneradas = new List<Tarjeta>();

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


        public List<Tarjeta> ObtenerTarjetasVulneradasDesdeArchivo(string rutaDeArchivo)
        {
             if (VerificarQueEsTxt(rutaDeArchivo))
                 return ObtenerTarjetasVulneradasDesdeArchivoTxt(rutaDeArchivo);
             else
                 throw new ExcepcionFormatoArchivoInvalido("Tipo de archivo no soportado");
            
        }

        public List<Credencial> ObtenerCredenciakesVulneradasDesdeArchivo(string rutaDeArchivo)
        {
            if (VerificarQueEsTxt(rutaDeArchivo))
                return ObtenerCredencialesVulneradasDesdeArchivoTxt(rutaDeArchivo);
            else
                throw new ExcepcionFormatoArchivoInvalido("Tipo de archivo no soportado");
        }

        private bool VerificarQueEsTxt(string ruta)
        {
            string extencionTxt = ".txt";
            bool retorno = false;

            if (Path.HasExtension(ruta))
            {
                if (Path.GetExtension(ruta).Equals(extencionTxt))
                {
                    retorno = true;
                }
            }
            return retorno;
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
