using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades_Datos
{
    public class Entidad_Usuario
    {


        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }

        public virtual ICollection<Entidad_DuplaUsuarioContrasenia> duplas { set; get; }
        public virtual ICollection<Entidad_Tarjeta> tarjetas { set; get; }
        public virtual ICollection<Entidad_Categoria> categorias { set; get; }


        public Entidad_Usuario() 
        {
        }
        public Entidad_Usuario(string nombre, string contrasenia)
        {
            this.Nombre = nombre;
            this.Contrasenia = contrasenia;
        }
    }
}
