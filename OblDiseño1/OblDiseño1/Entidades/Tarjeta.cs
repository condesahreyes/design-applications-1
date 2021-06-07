using System.Linq;
using System;

namespace OblDiseño1
{

    public class Tarjeta : IComparable<Tarjeta>
    {
        private const int largo_valido_de_numero_tarjeta = 16;
        private const int anio_MIN = 1960;
        private const int anio_MAX = 2090;
        private const int largo_MAX = 25;
        private const int largo_MIN = 3;
        private const int dia_MAX = 31;
        private const int dia_MIN = 1;
        private const int mes_MAX = 12;
        private const int mes_MIN = 1;

        private string nombre;
        private string numero;
        private string tipo;

        private int codigoSeguridad;

        private DateTime fechaVencimiento;
        private Categoria categoria;

        public Tarjeta(string unNombre, string unTipo, string unNumero, int unCodigoseguridad
            , DateTime unaFechaVencimiento, Categoria unaCategoria, string unaNota)
        {
            Nombre = unNombre;
            Tipo = unTipo;
            Numero = unNumero;
            CodigoSeguridad = unCodigoseguridad;
            FechaVencimiento = unaFechaVencimiento;
            Categoria = unaCategoria;
            NotaOpcional = unaNota;
        }

        public string NotaOpcional { set; get; }

        public string Nombre { get => nombre; set => SetNombre(value); }

        public string Tipo { get => tipo; set => SetTipo(value); }

        public string Numero {

            get => numero;

            set {
                string numeroAString = "" + value;
                if (numeroAString.Length != 16 || !numeroAString.All(char.IsDigit))
                    throw new ExepcionTarjetaIncorrecta("El numero de la tarjeta debe contener 16 digitos númericos");
                else
                    this.numero = value;
            }
        }

        public int CodigoSeguridad {
            get => codigoSeguridad;
            set {
                string codigoAString = "" + value;

                if (codigoAString.Length != 3 && codigoAString.Length != 4)
                    throw new ExepcionTarjetaIncorrecta("El codigo de seguridad debe contener 3 digitos");
                else
                    this.codigoSeguridad = value;
            }
        }

        public DateTime FechaVencimiento {
            get => fechaVencimiento;
            set {
                int year = value.Year;
                int month = value.Month;
                int day = value.Day;
                if ((year < anio_MIN || year > anio_MAX) || (month < mes_MIN || month > mes_MAX) 
                    || (day < dia_MIN || day > dia_MAX))
                    throw new ExepcionTarjetaIncorrecta("No puede ingresar un campo vacio");
                else
                    this.fechaVencimiento = value;
            }
        }

        public Categoria Categoria {
            get => categoria;
            set {
                if (value == null)
                    throw new ExepcionTarjetaIncorrecta("No puede ingresar un campo vacio");
                else
                    this.categoria = value;
            }
        }

        public void BorrarTarjeta(Tarjeta tarjeta)
        {
            tarjeta = null;
            GC.Collect();
        }

        private void SetNombre(string unNombre)
        {
            if ((unNombre != null) && (unNombre.Length >= largo_MIN) && (unNombre.Length <= largo_MAX))
                this.nombre = unNombre;
            else
                throw new ExepcionTarjetaIncorrecta("El campo no puede ser vacio");
        }

        public static bool ValidarLargoNumeroDeTarjeta(string posibleNumeroDeTarjeta)
        {
            return (posibleNumeroDeTarjeta.Length == largo_valido_de_numero_tarjeta) ? true : false;
        }

        private void SetTipo(string unTipo)
        {
            if ((unTipo != null) && (unTipo.Length >= largo_MIN) && (unTipo.Length <= largo_MAX))
                this.tipo = unTipo;
            else
                throw new ExepcionTarjetaIncorrecta("El campo no puede ser vacio");
        }

        public override bool Equals(object obj)
        {
            Tarjeta tarjetaAComparar = (Tarjeta)obj;
            if ((Numero.Equals(tarjetaAComparar.Numero)))
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return ("Nombre : " + this.Nombre + " Tipo: " + this.Tipo +
                " Numero: " + this.Numero + " Codigo de Seguridad: " +
                this.CodigoSeguridad + " Fecha de Vencimiento: " +
                this.FechaVencimiento + "Categoria: " + this.Categoria +
                "Nota: " + this.NotaOpcional);
        }

        public int CompareTo(Tarjeta unaTarjeta)
        {
            return this.Categoria.Nombre.CompareTo(unaTarjeta.Categoria.Nombre);
        }
    }
}