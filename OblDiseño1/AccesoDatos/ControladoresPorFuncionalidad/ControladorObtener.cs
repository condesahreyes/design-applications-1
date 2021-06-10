using AccesoDatos.Entidades_Datos;
using OblDiseño1;
using System.Collections.Generic;

namespace AccesoDatos.Controladores
{
    public class ControladorObtener
    {
        Usuario usuario;
        public ControladorObtener(Usuario usuario)
        {
            this.usuario = usuario;
        }

        public void ObtenerUsuario(Usuario unUsuario)
        {
            //IRepositorio<Usuario, string> repositorio = new UsuarioRepositorio();
            //repositorio.Get(unUsuario.Nombre);
        }

        public EntidadUsuario ObtenerUsuarioDto(Usuario unUsuario)
        {
            IRepositorio<Usuario, string> repositorio = new UsuarioRepositorio();
            using (Contexto contexto = new Contexto())
            {
                if (repositorio.Existe(unUsuario.Nombre))
                {
                    return contexto.usuarios.Find(unUsuario.Nombre);

                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe un usuario con este nombre");
            }

        }

        public List<Categoria> ObtenerCategorias()
        {
            //IRepositorio<Categoria, string> repositorio = new CategoriaRepositorio(usuario);

            // return repositorio.GetAll();
            return null;
        }

        public void AgregarCredencial(Credencial credencial)
        {
            //IRepositorio<Credencial, int> repositorio = new CredencialRepositorio(usuario);
            //repositorio.Add(credencial);
        }

        public void AgregarTarjeta(Tarjeta tarjeta)
        {
            //IRepositorio<Tarjeta, int> repositorio = new TarjetaRepositorio(usuario);
            //repositorio.Add(tarjeta);
        }
    }
}
