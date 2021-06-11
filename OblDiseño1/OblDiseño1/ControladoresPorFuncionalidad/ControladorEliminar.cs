using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblDiseño1.ControladoresPorFuncionalidad
{
    class ControladorEliminar
    {
        public ControladorEliminar()
        {
        }

        public void EliminarUsuario(Usuario usuario, IRepositorio<Usuario> repositorioUsuario)
        {
            repositorioUsuario.Delete(usuario);
        }

        public void EliminarCategoria(Categoria categoria, IRepositorio<Categoria> repositorioCategoria)
        {
            repositorioCategoria.Delete(categoria);
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
