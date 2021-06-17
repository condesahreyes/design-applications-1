using System.Collections.Generic;

namespace AccesoDatos.Entidades_Datos
{
    public class EntidadCategoria
    {
        public int CategoriaId { get; set; }

        public string NombreCategoria { set; get; }

        public EntidadUsuario Usuario { set; get; }

        public virtual ICollection<EntidadTarjeta> Tarjetas { set; get; }

        public virtual ICollection<EntidadCredencial> Credenciales { set; get; }

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