
using System.Collections.Generic;
using System.Data;

namespace OblDiseño1
{
    public class Sistema
    {

        List<Usuario> usuarios = new List<Usuario>();

        public Usuario AgregarUsuario(string nombreUsuario, string contrasenia)
        {

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
            foreach (Usuario us in usuarios)
                if (us.Nombre.Equals(nombreUsuario))
                    return us;
            
                throw new ObjectNotFoundException();
        }

        public bool PuedoIngresarAlSistema(string unNombreUsuario, string unaContrasenia)
        {
            Usuario unUsuario = DevolverUsuario(unNombreUsuario);

            if (unUsuario == null)
                return false;

            string contraseniaDelUsuairo = unUsuario.Contrasenia;

            if (contraseniaDelUsuairo != unaContrasenia)
                return false;

            return true;
        }

    }
}
