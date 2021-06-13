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

        public void AgregarCategoria(Categoria categoria, IRepositorio<Categoria> repositorioCategoria)
        {
            repositorioCategoria.Add(categoria);
        }


        public void AgregarTarjeta(Tarjeta tarjetaAgregar, IRepositorio<Tarjeta> repositorioTarjeta)
        {
            repositorioTarjeta.Add(tarjetaAgregar);
        }

        public void AgregarCredencial(Credencial credencialAgregar, IRepositorio<Credencial> repositorioCredencial)
        {
            repositorioCredencial.Add(credencialAgregar);
        }
    }
}
