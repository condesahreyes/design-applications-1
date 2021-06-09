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
        [Key]
        public int CategoriaId { set; get; }
        public string NombreCategoria { set; get; }

        public EntidadUsuario usuarioDueño { set; get; }

        public EntidadCategoria() 
        {}

        public EntidadCategoria(string nombre, EntidadUsuario usuario)
        {
            this.NombreCategoria = nombre;
            this.usuarioDueño = usuario;
        }
    }
}
