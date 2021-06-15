using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades_Datos
{
    public class EntidadDataBreach
    {
        public int IdDataBrech { get; set; }

        public DateTime fecha { get; set; }

        public EntidadUsuario Usuario { set; get; }

        public string UsuarioNombre { set; get; }

        public ICollection<EntidadDataBrechTarjeta> tarjetasVulneradas { get; set; }

        public ICollection<EntidadDataBrechCredencial> credencialVulneradas { get; set; }

        public EntidadDataBreach(DateTime fecha, string nombreUsuario)
        {
            this.fecha = fecha;
            this.UsuarioNombre = nombreUsuario;
            this.tarjetasVulneradas = new List<EntidadDataBrechTarjeta>();
            this.credencialVulneradas = new List<EntidadDataBrechCredencial>();
        }
    }
}
