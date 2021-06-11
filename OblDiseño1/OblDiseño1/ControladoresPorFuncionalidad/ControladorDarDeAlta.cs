using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OblDiseño1.ControladoresPorEntidades
{
    public class ControladorCategoria
    {
        Usuario usuario;
        IRepositorio<Categoria, string> repositorio;
        public ControladorCategoria(IRepositorio<Categoria, string> repositorio, Usuario usuario)
        {
            this.repositorio = repositorio;
            this.usuario = usuario;
        }

        public void AgregarCategoria(Categoria categoria, IRepositorio<Usuario, string> repositorioUsuario)
        {
            List<Categoria> categorias = repositorioUsuario.ObtenerMisCategorias(usuario.Nombre);
            foreach (Categoria cat in categorias)
                if (cat.Nombre.ToLower() == categoria.Nombre.ToLower())
                    throw new DuplicateNameException();

            repositorio.Add(categoria);
        }

        public void EliminarCategoria(Categoria categoria)
        {
            //this.categorias.Remove(categoria);
        }

        public List<string> ListarToStringDeMisCategorias()
        {
            /* List<string> categoriasString = new List<string>();

             for (int i = 0; i < this.ObtenerCategorias().Count; i++)
                 categoriasString.Add(this.ObtenerCategorias()[i].ToString());

             return categoriasString;*/
            return null;
        }
    }
}
