using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AccesoDatos.Entidades_Datos
{
    public class EntidadTarjeta
    {
        public int TarjetaId { get; set; }
        public string Numero { get; set; }
        public EntidadUsuario UsuarioGestor { set; get; }
        public string UsuarioGestorNombre { set; get; }
        public string NotaOpcional { set; get; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }

        public int CodigoSeguridad { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public EntidadCategoria Categoria { get; set; }

        public int IdCategoria { get; set; }

        public string UsuarioGestorNombreCategoria { set; get; }

        public EntidadTarjeta()
        {
        }
        public EntidadTarjeta(string nota, string nombre, string tipo, string numero,
            int codigoSeguridad, DateTime fecha, int categoria, string usuario)
        {
            this.Nombre = nombre;
            this.NotaOpcional = nota;
            this.Tipo = tipo;
            this.Numero = numero;
            this.CodigoSeguridad = codigoSeguridad;
            this.FechaVencimiento = fecha;
            this.UsuarioGestorNombre = usuario;
            this.UsuarioGestorNombreCategoria = usuario;
            this.IdCategoria = categoria;
        }
    }
}