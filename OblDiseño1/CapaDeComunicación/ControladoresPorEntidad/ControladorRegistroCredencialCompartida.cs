using AccesoDatos.Repositorios;
using OblDiseño1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeComunicación.ControladoresPorEntidad
{
    public class ControladorRegistroCredencialCompartida
    {
        private IRepositorioCompartir<Credencial, Usuario> registroCredencialCompartidaRepositorio;
        private Usuario usuario;

        public ControladorRegistroCredencialCompartida(Usuario usuario)
        {
            this.usuario = usuario;
            this.registroCredencialCompartidaRepositorio = new RegistroCredencialCompartidaRepositorio(this.usuario);
        }

        public void compartirCredencial(Credencial credencialACompartir, Usuario usuarioACompartir)
        {
            this.registroCredencialCompartidaRepositorio.Add(credencialACompartir, usuarioACompartir);
        }

        public void dejarDeCompartirCredencial(Credencial credencialACompartir, Usuario usuarioACompartir)
        {
            this.registroCredencialCompartidaRepositorio.Delete(credencialACompartir, usuarioACompartir);
        }

        public List<Credencial> ObtenerTodasLasCredencialesQueComparto()
        {
            return this.registroCredencialCompartidaRepositorio.ObtenerTodasLasCredencialesQueComparto();
        }

        public List<Credencial> ObtenerTodasLasCredencialesQueMeComparten()
        {
            return this.registroCredencialCompartidaRepositorio.ObtenerTodasLasCredencialesQueMeComparten();
        }

        public List<Usuario> ObtenerUsuariosQueMeCompartenAlgunaCredencial()
        {
            return this.registroCredencialCompartidaRepositorio.ObtenerUsuariosQueMeCompartenAlgunaCredencial();
        }

        public List<Usuario> ObtenerTodosLosUsuariosALosQueCompartoUnaCredencial(Credencial credencialQueComparto)
        {
            return this.registroCredencialCompartidaRepositorio.ObtenerTodosLosUsuariosALosQueCompartoUnaCredencial(credencialQueComparto);
        }

        public List<Credencial> ObtenerCredencialesQueMeComparteElUsuario(Usuario usuarioQueMeComparte)
        {
            return this.registroCredencialCompartidaRepositorio.ObtenerCredencialesQueMeComparteUnUsuario(usuarioQueMeComparte);

        }
    }
}
