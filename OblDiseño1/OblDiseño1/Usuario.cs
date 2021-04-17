using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblDiseño1
{

    public class Usuario
    {
        private string nombre;
        private string contrasenia;

        ArrayList categorias = new ArrayList();
        ArrayList tarjetas = new ArrayList();
        ArrayList duplas = new ArrayList();

        public Usuario(string nombre, string contrasenia, ArrayList categorias, ArrayList tarjetas, ArrayList duplas)
        {
            Nombre = nombre;
            Contrasenia = contrasenia;
            this.categorias = categorias;
            this.tarjetas = tarjetas;
            this.duplas = duplas;
        }


        public string Nombre { get => nombre; set => setNombre(value); }
        public string Contrasenia { get => contrasenia; set => setContrasenia(value); }

        public ArrayList getTarjetas()
        {
            return this.tarjetas;
        }

        public ArrayList getDuplas()
        {
            return this.duplas;
        }

        public ArrayList getCategorias()
        {
            return this.categorias;
        }
        public void setNombre(string unNombre)
        {
            if (unNombre.Length < 1 || unNombre.Length > 25)
                throw new InvalidUsuarioDataException("El nombre debe tener entre 5 y 25 caracteres");
            else
                this.nombre = unNombre;
        }

        public void setContrasenia(string unaContrasenia)
        {
            if (unaContrasenia.Length < 5 || unaContrasenia.Length > 25)
                throw new InvalidUsuarioDataException("La contraseña debe tener entre 5 y 25 caracteres");
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
