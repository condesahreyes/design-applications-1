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




        public Tarjeta ObtenerTarjeta(Tarjeta tarjetaAgregar, IRepositorio<Tarjeta> repositorioTarjeta)
        {
            return repositorioTarjeta.Get(tarjetaAgregar);
        }

        public bool ExisteTarjeta(Tarjeta tarjeta, IRepositorio<Tarjeta> repositorioTarjeta)
        {
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



        public ChequeadorDeDataBreaches ObtenerDataBreach(ChequeadorDeDataBreaches dataBreach, IRepositorio<ChequeadorDeDataBreaches> repositorioDataBreach)
        {
            return repositorioDataBreach.Get(dataBreach);
        }

        public List<ChequeadorDeDataBreaches> ObtenerDataBreaches(IRepositorio<ChequeadorDeDataBreaches> repositorioDataBreach)
        {
            return repositorioDataBreach.GetAll();
        }

        public List<Usuario> ObtenerUsuarios(IRepositorio<Usuario> repositorioUsuario)
        {
            return repositorioUsuario.GetAll();
        }
    }
}
