using OblDiseño1.ControladoresPorFuncionalidad;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace OblDiseño1
{
    public class ChequeadorDeDataBreaches
    {
        private ControladorObtener controladorObtener;

        private IRepositorio<Tarjeta> tarjetaRepositorio;
        private IRepositorio<Credencial> credencialRepositorio;

        public Usuario usuario { get; set; }

        public ChequeadorDeDataBreaches(Usuario unUsuario, IRepositorio<Tarjeta> tarjetaRepositorio, 
            IRepositorio<Credencial> credencialRepositorio)
        {
            this.usuario = unUsuario;
            this.controladorObtener = new ControladorObtener();
            this.tarjetaRepositorio = tarjetaRepositorio;
            this.credencialRepositorio = credencialRepositorio;
        }

        public List<Tarjeta> ObtenerTarjetasVulneradas(List<string> datosDelDataBreach)
        {
            List<Tarjeta> tarjetasVulneradas = new List<Tarjeta>();

            foreach (string dato in datosDelDataBreach)
                if (Tarjeta.ValidarLargoNumeroDeTarjeta(dato))
                    tarjetasVulneradas.AddRange(DevolverMisTarjetasVulneradas(dato));

            return tarjetasVulneradas;
        }

        public List<Tarjeta> DevolverMisTarjetasVulneradas(string numeroTarjeta)
        {
            List<Tarjeta> tarjetasVulneradas = new List<Tarjeta>();
            List<Tarjeta> tarjetas = controladorObtener.ObtenerTarjetas(tarjetaRepositorio);
            foreach (Tarjeta unaTarjeta in tarjetas)
                if (unaTarjeta.Numero == numeroTarjeta)
                    tarjetasVulneradas.Add(unaTarjeta);

            return tarjetasVulneradas;
        }

        public List<Credencial> ObtenerCredencialesVulneradas(List<string> datosDelDataBreach)
        {
            List<Credencial> credencialesVulneradas = new List<Credencial>();

            foreach (string dato in datosDelDataBreach)
                    credencialesVulneradas.AddRange(ObtenerCredencialVulneradas(dato));

            return credencialesVulneradas;
        }

        public List<Credencial> ObtenerCredencialVulneradas(string unaContrasenia)
        {
            List<Credencial> credencialesVulneradas = new List<Credencial>();
            List<Credencial> credenciales = controladorObtener.ObtenerCredenciales(credencialRepositorio);
            foreach (Credencial unaDupla in credenciales)
                if (unaDupla.Contraseña.Contrasenia == unaContrasenia)
                    credencialesVulneradas.Add(unaDupla);

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
