using System;

namespace AccesoDatos.Entidades_Datos
{
    public class EntidadDataBrechTarjeta
    {

        public int DataBrechId { get; set; }

        public EntidadDataBreach dataBreach { get; set; }

        public int TarjetaId { get; set; }

        public string Numero { get; set; }

        public string UsuarioGestorNombre { set; get; }

        public string NotaOpcional { set; get; }

        public string Nombre { get; set; }

        public string Tipo { get; set; }

        public int CodigoSeguridad { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public string Categoria { get; set; }

        public EntidadDataBrechTarjeta(int tarjetaId, string numero, string nombreUsuario, 
            string nota, string nombreTarjeta, string tipo, int codigoSeguridad, DateTime fecha,
            string categoria)
        {
            this.TarjetaId = tarjetaId;
            this.Numero = numero;
            this.UsuarioGestorNombre = nombreUsuario;
            this.NotaOpcional = nota;
            this.Nombre = nombreTarjeta;
            this.Tipo = tipo;
            this.CodigoSeguridad = codigoSeguridad;
            this.FechaVencimiento = fecha;
            this.Categoria = categoria;
        }
    }
}
