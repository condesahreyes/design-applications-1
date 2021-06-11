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
        public string Numero { get; set; }
        public EntidadUsuario UsuarioGestor { set; get; }
        public string UsuarioGestorNombre { set; get; }
        public string NotaOpcional { set; get; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }

        public int CodigoSeguridad { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public EntidadCategoria Categoria { get; set; }


        public EntidadTarjeta() 
        {
        }
        public EntidadTarjeta(string nota, string nombre, string tipo, string numero, int codigoSeguridad, DateTime fecha, EntidadCategoria categoria)
        {
            this.Nombre = nombre;
            this.NotaOpcional = nota;
            this.Tipo = tipo;
            this.Numero = numero;
            this.CodigoSeguridad = codigoSeguridad;
            this.FechaVencimiento = fecha;
            this.Categoria = categoria;
        }
    }
}
