using System.Collections.Generic;
using System.Data;

namespace OblDiseño1.ControladoresPorFuncionalidad
{
    public class ControladorAlta
    {
        public ControladorAlta()
        {
        }

        public void AgregarUsuario(Usuario usuario, IRepositorio<Usuario> repositorioUsuario)
        {
            repositorioUsuario.Add(usuario);
        }




        public void AgregarTarjeta(Tarjeta tarjetaAgregar, IRepositorio<Tarjeta> repositorioTarjeta)
        {
            repositorioTarjeta.Add(tarjetaAgregar);
        }



        public void AgregarDataBrache(ChequeadorDeDataBreaches dataBreach, IRepositorio<ChequeadorDeDataBreaches> repositorioDataBreach)
        {
            repositorioDataBreach.Add(dataBreach);
        }

        public void AgregarRegistroCredencialCompartida(Credencial credencialACompartir, Usuario usuarioAlQueComparto, IRepositorioCompartir<Credencial,Usuario> repositorioCompartir)
        {
            repositorioCompartir.Add(credencialACompartir, usuarioAlQueComparto);
        }
    }
}
