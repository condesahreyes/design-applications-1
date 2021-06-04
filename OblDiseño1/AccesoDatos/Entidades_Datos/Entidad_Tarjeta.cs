using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades_Datos
{
    public class Entidad_Tarjeta
    {
        public int Id { get; set; }
        public string NotaOpcional { set; get; }
        public string Nombre { get ; set ; }
        public string Tipo { get ; set ; }
        public int Numero { get; set; }
        public int CodigoSeguridad { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public Entidad_Categoria Categoria { get; set; }
    }
}
