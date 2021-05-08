
using System.Collections.Generic;

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
