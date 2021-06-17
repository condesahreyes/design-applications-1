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

        public void AgregarUsuario(Usuario usuario)
        {
            repositorioUsuario.Add(usuario);
        }

        public void ModificarUsuario(Usuario usuarioOriginal, Usuario nuevoUsuario)
        {
            repositorioUsuario.Modificar(usuarioOriginal, nuevoUsuario);
        }

        public Usuario ObtenerUnUsuario(Usuario usuario)
        {
            return repositorioUsuario.Get(usuario);
        }

        public List<Usuario> ObtenerTodosMisUsuarios()
        {
            return repositorioUsuario.GetAll();
        }

        public bool ExisteUsuario(Usuario usuario)
        {
            return repositorioUsuario.Existe(usuario);
        }

    }
}
