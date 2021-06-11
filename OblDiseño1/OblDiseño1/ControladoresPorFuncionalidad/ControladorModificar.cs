using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblDiseño1.ControladoresPorFuncionalidad
{
    class ControladorModificar
    {
        public ControladorModificar()
        {
        }

        public void ModificarUsuario(Usuario usuario, IRepositorio<Usuario, string> repositorioUsuario)
        {
            repositorioUsuario.Modificar(usuario);
        }

        public void ModificarCategoria(Categoria categoria, IRepositorio<Categoria, string> repositorioCategoria)
        {
            repositorioCategoria.Modificar(categoria);
        }

        public void ModificarTarjeta(Tarjeta tarjetaAgregar, IRepositorio<Tarjeta, string> repositorioTarjeta)
        {
            repositorioTarjeta.Modificar(tarjetaAgregar);
        }

        public void ModificarCredencial(Credencial credencialAgregar, IRepositorio<Credencial, string> repositorioCredencial)
        {
            repositorioCredencial.Modificar(credencialAgregar);
        }
    }
}
