using System;

namespace AccesoDatos.Entidades_Datos
{
    public class EntidadDataBrechCredencial
    {
        public int DataBrechId { get; set; }

        public EntidadDataBreach dataBreach { get; set; }

        public int IdCredencial { get; set; }

        public string NombreUsuario { get; set; }

        public string Contrasenia { get; set; }

        public string NombreSitioApp { get; set; }

        public string UsuarioGestorNombre { set; get; }

        public string Nota { get; set; }

        public string Categoria { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }

        public EntidadDataBrechCredencial(int idCredencial, string nombreUsuario, string contraseña, 
            string nombreSitio, string usuarioDueño, string nota, string categoria, DateTime fechaVencimiento)
        {
            this.IdCredencial = idCredencial;
            this.NombreUsuario = nombreUsuario;
            this.Contrasenia = contraseña;
            this.NombreSitioApp = nombreSitio;
            this.UsuarioGestorNombre = usuarioDueño;
            this.Nota = nota;
            this.Categoria = categoria;
            this.FechaUltimaModificacion = fechaVencimiento;
        }

    }
}
