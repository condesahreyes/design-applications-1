
using System.Collections.Generic;

namespace OblDiseño1
{
    public class Sistema
    {

        List<Usuario> usuarios = new List<Usuario>();

        public Usuario AgregarUsuario(string nombreUsuario, string contrasenia)
        {
            Usuario existeUsuario = DevolverUsuario(nombreUsuario);

            if(existeUsuario != null)
                throw new ExepcionObjetosRepetidos("Ya existe el usuario");

            Usuario nuevoUsuario = new Usuario(nombreUsuario, contrasenia);
            usuarios.Add(nuevoUsuario);

            return nuevoUsuario;

        }

        public List<Usuario> ObtenerUsuarios()
        {
            return this.usuarios;
        }

        public Usuario DevolverUsuario(string nombreUsuario)
        {
            Usuario usuario = null;

            foreach (Usuario us in usuarios)
                if (us.Nombre.Equals(nombreUsuario))
                    usuario = us;

            return usuario;
        }

    }
}
