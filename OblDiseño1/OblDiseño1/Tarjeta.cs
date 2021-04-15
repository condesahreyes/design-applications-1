using System;
namespace OblDiseño1
{
    public class Tarjeta
    {

        private static readonly long valor;
        private static readonly int valor2;

        const int anio_MIN = 1960;
        const int anio_MAX = 2090;

        const int dia_MIN = 1;
        const int dia_MAX = 31;

        const int mes_MIN = 1;
        const int mes_MAX = 12;




        public Tarjeta()
        {

        }

        




        public string Nombre { get => nombre; private set =>  SetNombre(value); }
        public string Tipo { get => tipo; private set => SetTipo(value); }
        public long Numero { get => numero;  set {
                string numeroAString = "" + value;
                if (numeroAString.Length != 16)
                    throw new TarjetaIncorrectaException("El numero de la tarjeta debe contener 16 digitos");
                else
                    this.numero = value;
            } }
        public int CodigoSeguridad { get => codigoSeguridad;  set {
                string codigoAString = "" + value;
                if (this.Tipo == "American Express")
                {
                    if (codigoAString.Length != 4)
                        throw new TarjetaIncorrectaException("El codigo de seguridad debe contener 4 digitos");
                }
                else if (codigoAString.Length != 3)
                {
                    throw new TarjetaIncorrectaException("El codigo de seguridad debe contener 3 digitos");
                }
                else
                    this.codigoSeguridad = value;
            } }

        private DateTime fechaVencimiento;
        public DateTime FechaVencimiento { get => fechaVencimiento; set {
                int year = value.Year;
                int month = value.Month;
                int day = value.Day;
                if ((year < anio_MIN || year > anio_MAX) || (month < mes_MIN || month > mes_MAX) || (day < dia_MIN || day > dia_MAX))
                    throw new TarjetaIncorrectaException("No puede ingresar un campo vacio");
                else
                    this.fechaVencimiento = value;
            } }
        public Categoria Categoria { get => categoria;  set {
                if (value == null)
                    throw new TarjetaIncorrectaException("No puede ingresar un campo vacio");
                else
                    this.categoria = value;
            } }
       
        public string NotaOpcional { set; get; }


        private string nombre;
        private void SetNombre(string unNombre)
        {
            if (unNombre != null)
                this.nombre = unNombre;
            else
            {
                throw new TarjetaIncorrectaException("El campo no puede ser vacio");
            }
        }

        private string tipo;
        private void SetTipo(string unTipo)
        {
            if (unTipo != null)
                this.tipo = unTipo;

            else
            {
                throw new TarjetaIncorrectaException("El campo no puede ser vacio");
            }
        }

        private long numero;
        private void SetNumero(long unNumero)
        {
            string numeroAString = unNumero.ToString();
            if (numeroAString.Length != 16)
                throw new TarjetaIncorrectaException("El numero de la tarjeta debe contener 16 digitos");
            else
                this.numero = unNumero;
        }

        private int codigoSeguridad;
        private void SetCodigoSeguridad(int unCodigoSeguridad)
        {

            string codigoAString = "" + unCodigoSeguridad;
            if (this.Tipo == "American Express")
            {
                if (codigoAString.Length != 4)
                    throw new TarjetaIncorrectaException("El codigo de seguridad debe contener 4 digitos");
            }
            else if (codigoAString.Length != 3)
            {
                throw new TarjetaIncorrectaException("El codigo de seguridad debe contener 3 digitos");
            }
            else
                this.codigoSeguridad = unCodigoSeguridad;
                
        }


        private Categoria categoria;

        private void SetCategoria(Categoria unaCategoria)
        {
            if (unaCategoria == null)
                throw new TarjetaIncorrectaException("No puede ingresar un campo vacio");
            else
                this.categoria = unaCategoria;
        }


        //private DateTime fechaVencimiento;
        //private void SetFechaVencimiento(DateTime unaFecha)
        //{
        //    int year = unaFecha.Year;
        //    int month = unaFecha.Month;
        //    int day = unaFecha.Day;
        //    if ((year < anio_MIN || year > anio_MAX ) || (month < mes_MIN || month > mes_MAX) || (day < dia_MIN || day > dia_MAX))
        //        throw new TarjetaIncorrectaException("No puede ingresar un campo vacio");
        //    else
        //        this.fechaVencimiento = unaFecha;
        //}



        public Tarjeta (string unNombre, string unTipo, long unNumero, int unCodigoseguridad, DateTime unaFechaVencimiento, Categoria unaCategoria,string unaNota)
        {
            Nombre = unNombre;
            Tipo = unTipo;
            Numero = unNumero;
            CodigoSeguridad = unCodigoseguridad;
            FechaVencimiento = unaFechaVencimiento;
            Categoria = unaCategoria;
            NotaOpcional = unaNota;
        }


        public override bool Equals(object obj)
        {
            Tarjeta tarjetaAComparar = (Tarjeta)obj;
            if ((Nombre.Equals(tarjetaAComparar.nombre)) && (Numero.Equals(tarjetaAComparar.Numero)))
                return true;
            else
                return false;
        }


    }
}