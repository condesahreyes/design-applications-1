using System.Collections.Generic;
using AccesoDatos;

namespace OblDiseño1.ControladoresPorEntidad
{
    public class ControladorCategoria
    {
        private IRepositorio<Categoria> repositorioCategoria;
        private Usuario usuario;

        public ControladorCategoria(Usuario usuario)
        {
            this.usuario = usuario;
            this.repositorioCategoria = new CategoriaRepositorio(this.usuario);
        }

        public Categoria CrearCategoria(string nombre)
        {
            Categoria categoria = new Categoria(nombre);
            repositorioCategoria.Add(categoria);

            return categoria;
        }

        public void ModificarCategoria(ref Categoria categoriaOriginal, string nombre)
        {
            Categoria nuevaCategoira = new Categoria(nombre);
            repositorioCategoria.Modificar(categoriaOriginal, nuevaCategoira);
            categoriaOriginal.Nombre = nombre;
        }

        public Categoria ObtenerCategoria(string nombreCategoria)
        {
            Categoria categoria = new Categoria(nombreCategoria);
            return repositorioCategoria.Get(categoria);
        }

        public List<Categoria> ObtenerCategorias()
        {
            return repositorioCategoria.GetAll();
        }
    }
}
