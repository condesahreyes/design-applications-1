using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades_Datos
{
    public class EntidadCredencial
    {

        public int CredencialId { get; set; }

        public string NombreUsuario { get; set; }

        public EntidadContraseña Contrasenia { get; set; }

        public int ContraseniaId { get; set; }

        public string NombreSitioApp { get; set; }

        public EntidadUsuario UsuarioGestor { set; get; }

        public string UsuarioGestorNombre { set; get; }

        public string TipoSitioOApp { get; set; }

        public string Nota { get; set; }

        public EntidadCategoria Categoria { get; set; }

        public int IdCategoria { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }

        public virtual ICollection<EntidadRegistroCredencialCompartida> registrosEnLosQueEstoyCompartida { set; get; }

        public EntidadCredencial()
        {
        }

        public EntidadCredencial(string unNombreUsuario, string unSitio, string laNota, int categoria, string usuario, int contraseña)
        {
            NombreUsuario = unNombreUsuario;
            NombreSitioApp = unSitio;
            Nota = laNota;
            FechaUltimaModificacion = DateTime.Today;
            IdCategoria = categoria;
            UsuarioGestorNombre = usuario;
            this.ContraseniaId = contraseña;
        }
    }
}