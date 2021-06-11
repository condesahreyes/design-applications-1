using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades_Datos
{
    public class EntidadCategoria
    {
        public string NombreCategoria { set; get; }

        public EntidadUsuario Usuario { set; get; }

        public string UsuarioNombre { set; get; }

        public EntidadCategoria() 
        {
        }

        public EntidadCategoria(string nombre, EntidadUsuario usuario)
        {
            this.NombreCategoria = nombre;
            this.UsuarioNombre = usuario.Nombre;
        }
    }
}
