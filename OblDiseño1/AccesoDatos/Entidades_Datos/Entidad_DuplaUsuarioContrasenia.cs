using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades_Datos
{
    public class Entidad_DuplaUsuarioContrasenia
    {
        public int Id { set; get; }
        public string NombreUsuario { get; set; }

        public string Contrasenia { get; set ; }

        public string NombreSitioApp { get; set ; }

        public string TipoSitioOApp { get; set; }

        public string Nota { get; set ; }

        public Entidad_Categoria Categoria { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }

        public int NivelSeguridadContrasenia { get; set; }
    }
}
