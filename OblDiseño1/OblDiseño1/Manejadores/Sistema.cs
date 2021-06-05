using System.Collections.Generic;
using System.Data;

namespace OblDiseño1
{
    public class Sistema
    {

        private List<Usuario> usuarios = new List<Usuario>();
        
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

        public Usuario DevolverUsuario(string nombreUsuario)
        {
            foreach (Usuario us in usuarios)
                if (us.Nombre.Equals(nombreUsuario))
                    return us;

            throw new ObjectNotFoundException();
        }

        public List<Dupla_UsuarioContrasenia> ObtenerDataBreachesCredenciales(ref Usuario usuario, List<string> datosDataBreaches)
        {
            ChequeadorDeDataBreaches dataBreaches = new ChequeadorDeDataBreaches(usuario);
            
            return dataBreaches.ObtenerCredencialesVulneradas(datosDataBreaches);
        }

        public List<Tarjeta> ObtenerDataBreachesTarjetas(ref Usuario usuario, List<string> datosDataBreaches)
        {
            ChequeadorDeDataBreaches dataBreaches = new ChequeadorDeDataBreaches(usuario);

            return dataBreaches.ObtenerTarjetasVulneradas(datosDataBreaches);
        }

    }
}
