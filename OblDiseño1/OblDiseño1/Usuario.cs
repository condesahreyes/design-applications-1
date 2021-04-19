using System.Collections.Generic;

namespace OblDiseño1
{

    public class Usuario
    {

        private string nombre;
        private string contrasenia;
        private const string mnsjUsuarioError = "El nombre de usuario debe tener entre 1 y 25 caracteres";
        private const string mnsjContraseniaError = "La contraseña debe tener entre 5 y 25 caracteres";

        private const int LARGO_NOMBRE_MIN = 1;
        private const int LARGO_NOMBRE_MAX = 25;
        private const int LARGO_CONTRASENIA_MIN = 5;
        private const int LARGO_CONTRASENIA_MAX = 25;

        private List<Dupla_UsuarioContrasenia> duplas;
        private List<Tarjeta> tarjetas;
        private List<Categoria> categorias;

        public string Nombre { get => nombre; set => setNombre(value); }
        public string Contrasenia { get => contrasenia; set => setContrasenia(value); }

        public Usuario(string nombre, string contrasenia) { 
            Nombre = nombre;
            Contrasenia = contrasenia;
            this.categorias = new List<Categoria>();
            this.tarjetas = new List<Tarjeta>();
            this.duplas = new List<Dupla_UsuarioContrasenia>();
            }

        public List<Tarjeta> getTarjetas()
        {
            return this.tarjetas;
        }

        public List<Dupla_UsuarioContrasenia> getDuplas()
        {
            return this.duplas;
        }

        public List<Categoria> getCategorias()
        {
            return this.categorias;
        }

        private bool nombreInvalido(string unNombre)
        {
            if (unNombre.Length < LARGO_NOMBRE_MIN || unNombre.Length > LARGO_NOMBRE_MAX)
                return true;
            return false;
        }

        public void setNombre(string unNombre)
        {
            if (nombreInvalido(unNombre))
                throw new InvalidUsuarioDataException(mnsjUsuarioError);
            else
                this.nombre = unNombre;
        }

        private bool contraseniaInvalida(string contrasenia)
        {
            if (contrasenia.Length < LARGO_CONTRASENIA_MIN || contrasenia.Length > LARGO_CONTRASENIA_MAX)
                return true;
            return false;
        }

        public void setContrasenia(string unaContrasenia)
        {
            if (contraseniaInvalida(unaContrasenia))
                throw new InvalidUsuarioDataException(mnsjContraseniaError);
            else
                this.contrasenia = unaContrasenia;
        }

        public void agregarTarjeta(Tarjeta tarjeta)
        {
            this.tarjetas.Add(tarjeta);
        }

        public void eliminarTarjeta(Tarjeta tarjeta)
        {
            this.tarjetas.Remove(tarjeta);
        }

        public void agregarDupla(Dupla_UsuarioContrasenia dupla)
        {
            this.duplas.Add(dupla);
        }

        public void eliminarDupla(Dupla_UsuarioContrasenia dupla)
        {
            this.duplas.Remove(dupla);
        }


        public void agregarCategoria(Categoria categoria)
        {
            this.categorias.Add(categoria);
        }

        public void eliminarCategoria(Categoria categoria)
        {
            this.categorias.Remove(categoria);
        }

    }
}
