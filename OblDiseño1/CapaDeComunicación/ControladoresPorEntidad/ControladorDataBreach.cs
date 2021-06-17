using AccesoDatos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblDiseño1.ControladoresPorEntidad
{
    public class ControladorDataBreach
    {

        private IRepositorio<ChequeadorDeDataBreaches> repositorioDataBreach;
        private Usuario usuario;
        public ChequeadorDeDataBreaches chequeadorDeDataBreaches;

        public ControladorDataBreach(Usuario usuario)
        {
            this.usuario = usuario;
            this.repositorioDataBreach = new DataBrechRepositorio(this.usuario);
            this.chequeadorDeDataBreaches = new ChequeadorDeDataBreaches(usuario);
        }

        public List<ChequeadorDeDataBreaches> ObtenerTodosMisDataBreaches()
        {
            return repositorioDataBreach.GetAll();
        }

        public void AgregarRegistroDataBreach(List<string> listaDatos)
        {
            chequeadorDeDataBreaches.CredencialesVulneradas = chequeadorDeDataBreaches.ObtenerCredencialesVulneradas(listaDatos);
            chequeadorDeDataBreaches.TarjetasVulneradas = chequeadorDeDataBreaches.ObtenerTarjetasVulneradas(listaDatos);
            chequeadorDeDataBreaches.Fecha = DateTime.Now;

            repositorioDataBreach.Add(this.chequeadorDeDataBreaches);
        }

        public List<Tarjeta> ObtenerTarjetasVulneradas()
        {
            return chequeadorDeDataBreaches.TarjetasVulneradas;
        }

        public List<Credencial> ObenerCredencialesVulneradas()
        {
            return chequeadorDeDataBreaches.CredencialesVulneradas;
        }

        public List<Credencial> ObtenerDataBreachesCredencialesMedianteRuta(ref Usuario usuario, string rutaDatosBreachados)
        {
            chequeadorDeDataBreaches.usuario = this.usuario;

            return chequeadorDeDataBreaches.ObtenerCredencialesVulneradasDesdeArchivoTxt(rutaDatosBreachados);
        }

        public List<Tarjeta> ObtenerDataBreachesTarjetassMedianteRuta(ref Usuario usuario, string rutaDatosBreachados)
        {
            ChequeadorDeDataBreaches dataBreaches = new ChequeadorDeDataBreaches(usuario);

            return dataBreaches.ObtenerTarjetasVulneradasDesdeArchivoTxt(rutaDatosBreachados);
        }
    }
}
