using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades_Datos
{
    public class EntidadCredencial
    {

        public string NombreUsuario { get; set; }

        public EntidadContraseña Contrasenia { get; set ; }

        public string NombreSitioApp { get; set ; }

        public EntidadUsuario UsuarioGestor { set; get; }

        public string UsuarioGestorNombre { set; get; }

        public string TipoSitioOApp { get; set; }

        public string Nota { get; set ; }

        public EntidadCategoria Categoria { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }

        
        public EntidadCredencial() 
        {
        }


        public EntidadCredencial(string unNombreUsuario, EntidadContraseña unaContrasenia,
            string unSitio, string laNota, EntidadCategoria laCategoria, EntidadUsuario miUsuario)
        {
            NombreUsuario = unNombreUsuario;
            Contrasenia = unaContrasenia;
            NombreSitioApp = unSitio;
            Nota = laNota;
            Categoria = laCategoria;
            FechaUltimaModificacion = DateTime.Today;
            this.UsuarioGestor = miUsuario;
        }
    }
}
