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
        public int CategoriaId { get; set; }

        public string NombreCategoria { set; get; }

        public EntidadUsuario Usuario { set; get; }

        public virtual ICollection<EntidadTarjeta> Tarjetas { set; get; }

        public virtual ICollection<EntidadCredencial> Credenciales { set; get; }

        public int CredencialId { get; set; }

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