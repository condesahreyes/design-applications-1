using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblDiseño1.ControladoresPorFuncionalidad
{
    public class ControladorEliminar
    {
        public ControladorEliminar()
        {
        }
        public void EliminarUsuario(Usuario usuario, IRepositorio<Usuario> repositorioUsuario)
        {
            repositorioUsuario.Delete(usuario);
        }

        public void EliminarTarjeta(Tarjeta tarjetaAgregar, IRepositorio<Tarjeta> repositorioTarjeta)
        {
            repositorioTarjeta.Add(tarjetaAgregar);
        }

        public void EliminarCredencial(Credencial credencialAgregar, IRepositorio<Credencial> repositorioCredencial)
        {
            repositorioCredencial.Add(credencialAgregar);
        }
    }
}
