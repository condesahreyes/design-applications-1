using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblDiseño1.ControladoresPorFuncionalidad
{
    class ControladorObtener
    {
        public ControladorObtener()
        {
        }

        public void ObtenerUsuario(Usuario usuario, IRepositorio<Usuario> repositorioUsuario)
        {
            repositorioUsuario.Get(usuario);
        }

        public void ObtenerCategoria(Categoria categoria, IRepositorio<Categoria> repositorioCategoria)
        {
            repositorioCategoria.Get(categoria);
        }


        public void ObtenerTarjeta(Tarjeta tarjetaAgregar, IRepositorio<Tarjeta> repositorioTarjeta)
        {
            repositorioTarjeta.Get(tarjetaAgregar);
        }

        public void ObtenerCredencial(Credencial credencialAgregar, IRepositorio<Credencial> repositorioCredencial)
        {
            repositorioCredencial.Get(credencialAgregar);
        }
    }
}
