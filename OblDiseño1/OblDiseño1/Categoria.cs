namespace OblDiseño1
{
    public class Categoria
    {
        private string nombre;
        public Categoria(string nombre)
        {
            if (nombre.Length > 15 || nombre.Length < 3)
                throw new InvalidCategoriaDataException("El nombre debe tener entre 3 y 15 caracteres");
            else
                this.nombre = nombre;
        }
        public string Nombre { get => nombre; private set => setNombre(value);}
        
        public void setNombre(string nombre)
        {
            if (nombre.Length > 15 || nombre.Length < 3)
                throw new InvalidCategoriaDataException("El nombre debe tener entre 3 y 15 caracteres");
            else
                this.nombre = nombre;
        }

        public override string ToString()
        {
            return "" + this.Nombre;
        }

        public override bool Equals(object obj)
        {
            Categoria aComparar = (Categoria)obj;
            return Nombre.Equals(aComparar.Nombre) ? true : false;
        }

    }
}