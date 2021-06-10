using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades_Datos
{
    public class EntidadUsuario
    {
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }

        //public EntidadGestorContraseñasCompartidas gestorContraseñas { set; get; }

        public virtual ICollection<EntidadCredencial> credenciales { set; get; }
        public virtual ICollection<EntidadTarjeta> tarjetas { set; get; }
        public virtual ICollection<EntidadCategoria> categorias { set; get; }



        public EntidadUsuario() 
        {
        }
        public EntidadUsuario(string nombre, string contrasenia)
        {
            this.Nombre = nombre;
            this.Contrasenia = contrasenia;
        }
    }
}
