using OblDiseño1.ControladoresPorFuncionalidad;
using System.Collections.Generic;

namespace OblDiseño1.ControladoresPorEntidad
{
    public class ControladorCategoria
    {
        private ControladorAlta crear = new ControladorAlta();
        private ControladorModificar modificar = new ControladorModificar();
        private ControladorObtener obtener = new ControladorObtener();

        private IRepositorio<Categoria> repositorioCategoria;
        private Usuario usuario;

        public ControladorCategoria(Usuario usuario, IRepositorio<Categoria> repositorioCategoria)
        {
            this.usuario = usuario;
            this.repositorioCategoria = repositorioCategoria;
        }

        public Categoria CrearCategoria(string nombre)
        {
            Categoria categoira = new Categoria(nombre);
            crear.AgregarCategoria(categoira, repositorioCategoria);

            return categoira;
        }

        public void ModificarCategoria(ref Categoria categoriaOriginal, string nombre)
        {
            Categoria nuevaCategoira = new Categoria(nombre);
            modificar.ModificarCategoria(categoriaOriginal, nuevaCategoira, repositorioCategoria);
            categoriaOriginal.Nombre = nombre;
        }

        public Categoria ObtenerCategoria(string nombreCategoria)
        {
            Categoria categoria = new Categoria(nombreCategoria);
            return obtener.ObtenerCategoria(categoria, repositorioCategoria);
        }

        public List<Categoria> ObtenerCategorias()
        {
            return obtener.ObtenerCategorias(repositorioCategoria);
        }
    }
}
