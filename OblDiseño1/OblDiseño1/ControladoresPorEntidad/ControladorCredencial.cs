using OblDiseño1.ControladoresPorFuncionalidad;
using System.Collections.Generic;
using OblDiseño1.Entidades;

namespace OblDiseño1.ControladoresPorEntidad
{
    public class ControladorCredencial
    {
        private ControladorAlta crear = new ControladorAlta();
        private ControladorModificar modificar = new ControladorModificar();
        private ControladorObtener obtener = new ControladorObtener();
        private ControladorEliminar eliminar = new ControladorEliminar();

        private IRepositorio<Credencial> repositorioCredencial;
        private Usuario usuario;

        public ControladorCredencial(Usuario usuario, IRepositorio<Credencial> repositorioCredencial)
        {
            this.usuario = usuario;
            this.repositorioCredencial = repositorioCredencial;
        }

        public void CrearCredencial(string nombreUsuario, string contraseñaString, string nombreSitio, string nota, Categoria categoria)
        {
            Contraseña contraseña = new Contraseña(contraseñaString);
            Credencial credencial = new Credencial(nombreUsuario, contraseña, nombreSitio, nota, categoria);

            crear.AgregarCredencial(credencial, repositorioCredencial);
        }

        public bool ObtenerSiEsContraseniaDuplicada(string unaContrasenia, Credencial credencial)
        {
            List<Credencial> credenciales = obtener.ObtenerCredenciales(repositorioCredencial);

            int cantContrasenias = 0;

            foreach (Credencial unaDupla in credenciales)
                if (unaDupla.ObtenerContraseña == unaContrasenia)
                    cantContrasenias++;

            if ((credencial == null && cantContrasenias == 0) || (credencial != null && cantContrasenias == 1))
                return false;

            return true;
        }

        public bool ObtenerSiEsContraseniaSegura(string unaContrasenia)
        {
            int seguridad = Contraseña.CalcularSeguridad(unaContrasenia);
            return seguridad == 4 || seguridad == 5 ? true : false;
        }

        public bool ObtenerSiEsContraseñaVulnerada(string contraseña, IRepositorio<ChequeadorDeDataBreaches>
            repositorioDataBreach)
        {
            List<Credencial> misCredencialesVulneradas =  ObtenerTodasLasCredencialesVulneradas(repositorioDataBreach);

            foreach (var credencial in misCredencialesVulneradas)
                if (credencial.ObtenerContraseña == contraseña)
                    return true;

            return false;
        }

        private List<Credencial> ObtenerTodasLasCredencialesVulneradas(IRepositorio<ChequeadorDeDataBreaches>
            repositorioDataBreach)
        {
            List<ChequeadorDeDataBreaches> misDataBreaches = obtener.ObtenerDataBreaches(repositorioDataBreach);

            List<Credencial> misCredencialesVulneradas = new List<Credencial>();

            foreach (var dataBreach in misDataBreaches)
                misCredencialesVulneradas.AddRange(dataBreach.CredencialesVulneradas);

            return misCredencialesVulneradas;
        }

        public void EliminarLaCredencial(Credencial credencial)
        {
            eliminar.EliminarCredencial(credencial, repositorioCredencial);
        }

        public List<Credencial> ObtenerTodasMisCredenciales()
        {
            return obtener.ObtenerCredenciales(repositorioCredencial);
        }

        public Credencial ObtenerCredencial(Credencial credencial)
        {
            return obtener.ObtenerCredencial(credencial, repositorioCredencial);
        }

        public void ModificarMiCredencial(Credencial credencialOriginal, Credencial credencialAModificar)
        {
            modificar.ModificarCredencial(credencialOriginal, credencialAModificar, repositorioCredencial);
        }
    }
}
