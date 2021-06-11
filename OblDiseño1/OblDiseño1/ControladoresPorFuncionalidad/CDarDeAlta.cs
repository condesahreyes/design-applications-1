using System.Collections.Generic;
using System.Data;

namespace OblDiseño1.ControladoresPorFuncionalidad
{
    class CDarDeAlta
    {
        Usuario usuario;
        IRepositorio<Usuario, string> repositorioUsuario;
        public CDarDeAlta(IRepositorio<Usuario, string> repositorioUsuario, Usuario usuario)
        {
            this.repositorioUsuario = repositorioUsuario;
            this.usuario = usuario;
        }

        public void AgregarCategoria(Categoria categoria, IRepositorio<Categoria, string> repositorioCategoria)
        {
            List<Categoria> categorias = repositorioUsuario.ObtenerMisCategorias(usuario.Nombre);
            foreach (Categoria cat in categorias)
                if (cat.Nombre.ToLower() == categoria.Nombre.ToLower())
                    throw new DuplicateNameException();

            repositorioCategoria.Add(categoria);
        }
    }
}
