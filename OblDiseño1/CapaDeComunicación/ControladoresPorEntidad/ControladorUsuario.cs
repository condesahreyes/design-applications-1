using AccesoDatos;
using System.Collections.Generic;

namespace OblDiseño1.ControladoresPorEntidad
{
    public class ControladorUsuario
    {

        private IRepositorio<Usuario> repositorioUsuario;

        public ControladorUsuario()
        {
            this.repositorioUsuario = new UsuarioRepositorio();
        }

        public Usuario ObtenerUnUsuario(Usuario usuario)
        {
            return repositorioUsuario.Get(usuario);
        }

        public List<Usuario> ObtenerTodosMisUsuarios()
        {
            return repositorioUsuario.GetAll();
        }

    }
}
