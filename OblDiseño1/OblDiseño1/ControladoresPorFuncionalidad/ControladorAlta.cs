using System.Collections.Generic;
using System.Data;

namespace OblDiseño1.ControladoresPorFuncionalidad
{
    class ControladorAlta
    {
        public ControladorAlta()
        {
        }

        public void AgregarUsuario(Usuario usuario, IRepositorio<Usuario, string> repositorioUsuario)
        {
            repositorioUsuario.Add(usuario);
        }

        public void AgregarCategoria(Categoria categoria, IRepositorio<Categoria, string> repositorioCategoria)
        {
            repositorioCategoria.Add(categoria);
        }


        public void AgregarTarjeta(Tarjeta tarjetaAgregar, IRepositorio<Tarjeta, string> repositorioTarjeta)
        {
            repositorioTarjeta.Add(tarjetaAgregar);
        }

        public void AgregarCredencial(Credencial credencialAgregar, IRepositorio<Credencial, string> repositorioCredencial)
        {
            repositorioCredencial.Add(credencialAgregar);
        }
    }
}
