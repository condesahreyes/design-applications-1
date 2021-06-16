using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblDiseño1.ControladoresPorFuncionalidad
{
    public class ControladorModificar
    {
        public ControladorModificar()
        {
        }

        public void ModificarUsuario(Usuario usuarioOriginal, Usuario usuario, IRepositorio<Usuario> repositorioUsuario)
        {
            repositorioUsuario.Modificar(usuarioOriginal, usuario);
        }

        public void ModificarCategoria(Categoria categoriaOriginal, Categoria categoria, IRepositorio<Categoria> repositorioCategoria)
        {
            repositorioCategoria.Modificar(categoriaOriginal, categoria);
        }

        public void ModificarTarjeta(Tarjeta tarjetaOriginal, Tarjeta tarjeta, IRepositorio<Tarjeta> repositorioTarjeta)
        {
            repositorioTarjeta.Modificar(tarjetaOriginal, tarjeta);
        }

        public void ModificarCredencial(Credencial credencialAgregar, Credencial credencial, IRepositorio<Credencial> repositorioCredencial)
        {
            repositorioCredencial.Modificar(credencialAgregar, credencial);
        }
    }
}
