using System;

namespace OblDiseño1
{
    public class Categoria : IComparable<Categoria>
    {
        public string Nombre { get => nombre;  set => ActualizarNombre(value); }

        private string nombre;
        private readonly string msgErrorNombre = "El nombre debe tener entre 3 y 15 caracteres";

        public Categoria(string nombre)
        {
            if (!EsNombreValido(nombre))
                throw new InvalidCategoriaDataException(msgErrorNombre);
            else
                this.nombre = nombre;
        }
        
        public void ActualizarNombre(string nombre)
        {
            if (!EsNombreValido(nombre))
                throw new InvalidCategoriaDataException(msgErrorNombre);
            else
                this.nombre = nombre;
        }

        private bool EsNombreValido(string unNombre)
        {
            return (unNombre.Length > 15 || unNombre.Length < 3) ? false : true;
        }

        public override string ToString()
        {
            return this.Nombre;
        }

        public int CompareTo(Categoria otraDupla)
        {
            return this.Nombre.CompareTo(otraDupla.Nombre);
        }
    }
}