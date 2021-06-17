using System.Collections.Generic;
using OblDiseño1.Entidades;
using AccesoDatos;
using AccesoDatos.Repositorios;

namespace OblDiseño1.ControladoresPorEntidad
{
    public class ControladorCredencial
    {
        private IRepositorio<Credencial> repositorioCredencial;
        private Usuario usuario;
        private IRepositorio<ChequeadorDeDataBreaches> repositorioDataBreach;

        public ControladorCredencial(Usuario usuario)
        {
            this.usuario = usuario;
            this.repositorioCredencial = new CredencialRepositorio(this.usuario);
            this.repositorioDataBreach = new DataBrechRepositorio(this.usuario);
        }

        public void CrearCredencial(string nombreUsuario, string contraseñaString, string nombreSitio, string nota, Categoria categoria)
        {
            Contraseña contraseña = new Contraseña(contraseñaString);
            Credencial credencial = new Credencial(nombreUsuario, contraseña, nombreSitio, nota, categoria);

            repositorioCredencial.Add(credencial);
        }

        public void AgregarCredencial(Credencial credencial)
        {
            repositorioCredencial.Add(credencial);
        }

        public bool ObtenerSiEsContraseniaDuplicada(string unaContrasenia, Credencial credencial)
        {
            List<Credencial> credenciales = repositorioCredencial.GetAll();

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

        public bool ObtenerSiEsContraseñaVulnerada(string contraseña)
        {
            List<Credencial> misCredencialesVulneradas =  ObtenerTodasLasCredencialesVulneradas();

            foreach (var credencial in misCredencialesVulneradas)
                if (credencial.ObtenerContraseña == contraseña)
                    return true;

            return false;
        }

        private List<Credencial> ObtenerTodasLasCredencialesVulneradas()
        {
            List<ChequeadorDeDataBreaches> misDataBreaches = repositorioDataBreach.GetAll();

            List<Credencial> misCredencialesVulneradas = new List<Credencial>();

            foreach (var dataBreach in misDataBreaches)
                misCredencialesVulneradas.AddRange(dataBreach.CredencialesVulneradas);

            return misCredencialesVulneradas;
        }

        public void EliminarLaCredencial(Credencial credencial)
        {
            repositorioCredencial.Delete(credencial);
        }

        public List<Credencial> ObtenerTodasMisCredenciales()
        {
            return repositorioCredencial.GetAll();
        }

        public Credencial ObtenerCredencial(Credencial credencial)
        {
            return repositorioCredencial.Get(credencial);
        }

        public void ModificarMiCredencial(Credencial credencialOriginal, Credencial credencialAModificar)
        {
            repositorioCredencial.Modificar(credencialOriginal, credencialAModificar);
        }
    }
}
