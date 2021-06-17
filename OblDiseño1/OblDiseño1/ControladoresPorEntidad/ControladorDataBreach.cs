using OblDiseño1.ControladoresPorFuncionalidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblDiseño1.ControladoresPorEntidad
{
    public class ControladorDataBreach
    {
        private ControladorAlta crear = new ControladorAlta();
        private ControladorModificar modificar = new ControladorModificar();
        private ControladorObtener obtener = new ControladorObtener();

        private IRepositorio<ChequeadorDeDataBreaches> repositorioDataBreach;
        private Usuario usuario;
        public ChequeadorDeDataBreaches chequeadorDeDataBreaches;

        public ControladorDataBreach(Usuario usuario, IRepositorio<ChequeadorDeDataBreaches> repositorioDataBreach)
        {
            this.usuario = usuario;
            this.repositorioDataBreach = repositorioDataBreach;
            this.chequeadorDeDataBreaches = new ChequeadorDeDataBreaches(usuario);
        }

        public List<ChequeadorDeDataBreaches> ObtenerTodosMisDataBreaches()
        {
            return obtener.ObtenerDataBreaches(repositorioDataBreach);
        }

        public void AgregarRegistroDataBreach(List<string> listaDatos)
        {
            chequeadorDeDataBreaches.CredencialesVulneradas = chequeadorDeDataBreaches.ObtenerCredencialesVulneradas(listaDatos);
            chequeadorDeDataBreaches.TarjetasVulneradas = chequeadorDeDataBreaches.ObtenerTarjetasVulneradas(listaDatos);
            chequeadorDeDataBreaches.Fecha = DateTime.Now;

            crear.AgregarDataBrache(this.chequeadorDeDataBreaches, this.repositorioDataBreach);
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
