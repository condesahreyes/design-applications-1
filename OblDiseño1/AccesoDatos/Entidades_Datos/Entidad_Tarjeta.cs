using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace AccesoDatos.Entidades_Datos
{
    public class Entidad_Tarjeta
    {
       

        public int Id { get; set; }
        public string NotaOpcional { set; get; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        [Key]
        public int Numero { get; set; }
        public int CodigoSeguridad { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public Entidad_Categoria Categoria { get; set; }


        public Entidad_Tarjeta() 
        {
        }
        public Entidad_Tarjeta(string nota, string nombre, string tipo, int numero, int codigoSeguridad, DateTime fecha, Entidad_Categoria categoria)
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
