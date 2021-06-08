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
   
        public int Id { set; get; }
        
        [Key]
        public string Nombre { set; get; }

        public EntidadCategoria() 
        {
        }

        public EntidadCategoria(string nombre)
        {
            this.Nombre = nombre;
        }
    }
}
