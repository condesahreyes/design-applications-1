using System;
namespace OblDiseño1
{

    public class Tarjeta : IComparable<Tarjeta>

{

    const int anio_MIN = 1960;
    const int anio_MAX = 2090;
    const int dia_MIN = 1;
    const int dia_MAX = 31;
    const int mes_MIN = 1;
    const int mes_MAX = 12;

    private string nombre;
    private string tipo;
    private int codigoSeguridad;
    private long numero;

    private DateTime fechaVencimiento;
    private Categoria categoria;

    public Tarjeta(string unNombre, string unTipo, long unNumero, int unCodigoseguridad, DateTime unaFechaVencimiento, Categoria unaCategoria, string unaNota)
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

    public long Numero {

        get => numero;

        set {
            string numeroAString = "" + value;
            if (numeroAString.Length != 16)
                throw new TarjetaIncorrectaException("El numero de la tarjeta debe contener 16 digitos");
            else
                this.numero = value;
        }
    }

    public int CodigoSeguridad {
        get => codigoSeguridad;
        set {
            string codigoAString = "" + value;
            if (this.Tipo == "American Express" && codigoAString.Length != 4)
                throw new TarjetaIncorrectaException("El codigo de seguridad debe contener 4 digitos");
            else if (codigoAString.Length != 3)
                throw new TarjetaIncorrectaException("El codigo de seguridad debe contener 3 digitos");
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
            if ((year < anio_MIN || year > anio_MAX) || (month < mes_MIN || month > mes_MAX) || (day < dia_MIN || day > dia_MAX))
                throw new TarjetaIncorrectaException("No puede ingresar un campo vacio");
            else
                this.fechaVencimiento = value;
        }
    }
    public Categoria Categoria {
        get => categoria;
        set {
            if (value == null)
                throw new TarjetaIncorrectaException("No puede ingresar un campo vacio");
            else
                this.categoria = value;
        }
    }

    private void SetNombre(string unNombre)
    {
        if (unNombre != null)
            this.nombre = unNombre;
        else
        {
            throw new TarjetaIncorrectaException("El campo no puede ser vacio");
        }
    }

    private void SetTipo(string unTipo)
    {
        if (unTipo != null)
            this.tipo = unTipo;
        else
            throw new TarjetaIncorrectaException("El campo no puede ser vacio");
    }

    public void BorrarTarjeta(Tarjeta tarjeta)
    {
        tarjeta = null;
        GC.Collect();
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