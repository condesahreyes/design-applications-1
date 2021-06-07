using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades_Datos
{
    public class Entidad_DuplaUsuarioContrasenia
    {
        private static int ultimoIdAsignado = 0;

        public int Id { set; get; }
        public string NombreUsuario { get; set; }

        public string Contrasenia { get; set ; }

        public string NombreSitioApp { get; set ; }

        public string TipoSitioOApp { get; set; }

        public string Nota { get; set ; }

        public Entidad_Categoria Categoria { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }

        public int NivelSeguridadContrasenia { get; set; }


        public Entidad_DuplaUsuarioContrasenia() 
        {
            this.Id = ultimoIdAsignado++;
        }


        public Entidad_DuplaUsuarioContrasenia(string unNombreUsuario, string unaContrasenia,
            string unSitio, string laNota, Entidad_Categoria laCategoria, int nivelSeguridadContrasenia)
        {
            Id = ultimoIdAsignado++;
            NombreUsuario = unNombreUsuario;
            Contrasenia = unaContrasenia;
            NombreSitioApp = unSitio;
            Nota = laNota;
            Categoria = laCategoria;
            FechaUltimaModificacion = DateTime.Today;
            this.NivelSeguridadContrasenia = nivelSeguridadContrasenia;
        }
    }
}
