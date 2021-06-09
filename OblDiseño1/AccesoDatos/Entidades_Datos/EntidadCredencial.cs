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
        [Key, Column(Order = 0)]
        public int CredencialId { get; set; }

        [Key, Column(Order = 1)]
        public string NombreUsuario { get; set; }

        public EntidadContraseña Contrasenia { get; set ; }

        [Key, Column(Order = 2)]
        public string NombreSitioApp { get; set ; }

        public string TipoSitioOApp { get; set; }

        public string Nota { get; set ; }

        public EntidadCategoria Categoria { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }

        
        public EntidadCredencial() 
        {
        }


        public EntidadCredencial(string unNombreUsuario, EntidadContraseña unaContrasenia,
            string unSitio, string laNota, EntidadCategoria laCategoria)
        {
            NombreUsuario = unNombreUsuario;
            Contrasenia = unaContrasenia;
            NombreSitioApp = unSitio;
            Nota = laNota;
            Categoria = laCategoria;
            FechaUltimaModificacion = DateTime.Today;
        }
    }
}
