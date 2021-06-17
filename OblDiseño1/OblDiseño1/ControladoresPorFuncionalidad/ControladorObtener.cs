using OblDiseño1.Entidades;
using System.Collections.Generic;

namespace OblDiseño1.ControladoresPorFuncionalidad
{
    public class ControladorObtener
    {
        public ControladorObtener()
        {
        }

        public Usuario ObtenerUsuario(Usuario usuario, IRepositorio<Usuario> repositorioUsuario)
        {
            return repositorioUsuario.Get(usuario);
        }

        public Categoria ObtenerCategoria(Categoria categoria, IRepositorio<Categoria> repositorioCategoria)
        {
            return repositorioCategoria.Get(categoria);
        }

        public List<Categoria> ObtenerCategorias(IRepositorio<Categoria> repositorioCategoria)
        {
            return repositorioCategoria.GetAll();
        }


        public Tarjeta ObtenerTarjeta(Tarjeta tarjetaAgregar, IRepositorio<Tarjeta> repositorioTarjeta)
        {
            return repositorioTarjeta.Get(tarjetaAgregar);
        }

        public bool ExisteTarjeta(string numeroTarjeta, IRepositorio<Tarjeta> repositorioTarjeta)
        {
            Tarjeta tarjeta = new Tarjeta();
            tarjeta.Numero = numeroTarjeta;
            return repositorioTarjeta.Existe(tarjeta);
        }

        public List<Tarjeta> ObtenerTarjetas(IRepositorio<Tarjeta> repositorioTarjeta)
        {
            return repositorioTarjeta.GetAll();
        }

        public Credencial ObtenerCredencial(Credencial credencial, IRepositorio<Credencial> repositorioCredencial)
        {
            return repositorioCredencial.Get(credencial);
        }

        public List<Credencial> ObtenerCredenciales(IRepositorio<Credencial> repositorioCredencial)
        {
            return repositorioCredencial.GetAll();
        }

        public ChequeadorDeDataBreaches ObtenerDataBreach(ChequeadorDeDataBreaches dataBreach, IRepositorio<ChequeadorDeDataBreaches> repositorioDataBreach)
        {
            return repositorioDataBreach.Get(dataBreach);
        }

        public List<ChequeadorDeDataBreaches> ObtenerDataBreaches(IRepositorio<ChequeadorDeDataBreaches> repositorioDataBreach)
        {
            return repositorioDataBreach.GetAll();
        }

        public bool ObtenerSiEsContraseniaDuplicada(string unaContrasenia, Credencial dupla,
            IRepositorio<Credencial> repositorioCredencial)
        {
            List<Credencial> credenciales = ObtenerCredenciales(repositorioCredencial);

            int cantContrasenias = 0;

            foreach (Credencial unaDupla in credenciales)
                if (unaDupla.ObtenerContraseña == unaContrasenia)
                    cantContrasenias++;

            if ((dupla == null && cantContrasenias == 0) || (dupla != null && cantContrasenias == 1))
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
            List<Credencial> misCredencialesVulneradas = ObtenerTodasLasCredencialesVulneradas(repositorioDataBreach);

            foreach (var credencial in misCredencialesVulneradas)
                if (credencial.ObtenerContraseña == contraseña)
                    return true;

            return false;
        }

        private List<Credencial> ObtenerTodasLasCredencialesVulneradas(IRepositorio<ChequeadorDeDataBreaches>
            repositorioDataBreach)
        {
            List<ChequeadorDeDataBreaches> misDataBreaches = ObtenerDataBreaches(repositorioDataBreach);

            List<Credencial> misCredencialesVulneradas = new List<Credencial>();

            foreach (var dataBreach in misDataBreaches)
                misCredencialesVulneradas.AddRange(dataBreach.CredencialesVulneradas);

            return misCredencialesVulneradas;
        }

        public List<Usuario> ObtenerUsuarios(IRepositorio<Usuario> repositorioUsuario)
        {
            return repositorioUsuario.GetAll();
        }
    }
}
