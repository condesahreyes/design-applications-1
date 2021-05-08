
using System.Collections.Generic;
using System.Data;

namespace OblDiseño1
{
    public class Sistema
    {

        List<Usuario> usuarios = new List<Usuario>();
        

        //1* ESTO ES PARA TESTEAR LA INTERFAZ, SACAR ANTES DE ENTREGAR
        bool hayQueCrearDatosDePrueba = true;
        public bool getHayQueCrearDatosDePrueba()
        {
            return this.hayQueCrearDatosDePrueba;
        }
        public void yaSeCrearonDatosDePruva()
        {
            this.hayQueCrearDatosDePrueba = false; 
        }
        //1* HASTA HACA
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

        public List<object>[] ObtenerDataBreaches(ref Usuario usuario, List<string> datosDataBreaches)
        {
            ChequeadorDeDataBreaches dataBreaches = new ChequeadorDeDataBreaches(usuario);
            
            return dataBreaches.ObtenerEntidadesVulneradas(datosDataBreaches);
        }

    }
}
