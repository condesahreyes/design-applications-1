using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades_Datos
{
    public class Entidad_Usuario
    {

        public Entidad_Usuario() { }

        public int UsuarioId { get; set; }
        public string Nombre { get ; set ; }
        public string Contrasenia { get ; set ; }

        public  ICollection<Entidad_DuplaUsuarioContrasenia> duplas;
        public ICollection<Entidad_Tarjeta> tarjetas;
        public ICollection<Entidad_Categoria> categorias;
    }
}
