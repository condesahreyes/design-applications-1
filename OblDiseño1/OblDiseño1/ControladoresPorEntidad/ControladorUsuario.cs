using OblDiseño1.ControladoresPorFuncionalidad;
using System.Collections.Generic;

namespace OblDiseño1.ControladoresPorEntidad
{
    public class ControladorUsuario
    {
        private ControladorAlta crear = new ControladorAlta();
        private ControladorModificar modificar = new ControladorModificar();
        private ControladorObtener obtener = new ControladorObtener();
        private ControladorEliminar eliminar = new ControladorEliminar();

        private IRepositorio<Usuario> repositorioUsuario;
        private Usuario usuario;

        public ControladorUsuario(Usuario usuario, IRepositorio<Usuario> repositorioUsuario)
        {
            this.usuario = usuario;
            this.repositorioUsuario = repositorioUsuario;
        }

        public Usuario ObtenerUnUsuario(Usuario usuario)
        {
            return obtener.ObtenerUsuario(usuario, repositorioUsuario);
        }

        public List<Usuario> ObtenerTodosMisUsuarios()
        {
            return obtener.ObtenerUsuarios(repositorioUsuario);
        }

    }
}
