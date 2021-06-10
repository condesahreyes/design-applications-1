using AccesoDatos;
using AccesoDatos.Entidades_Datos;

namespace OblDiseño1
{
    public class ControladorDarDeAlta
    {
        Usuario usuario;
        public ControladorDarDeAlta(Usuario usuario)
        {
            this.usuario = usuario;
        }

        public void AgregarUsuario(Usuario unUsuario)
        {
            IRepositorio<Usuario, string> repositorioUsuario = new UsuarioRepositorio();
            repositorioUsuario.Add(unUsuario);
        }

        public void AgregarCategoria(Categoria categoria)
        {
            IRepositorio<Categoria, string> repositorioUsuario = new CategoriaRepositorio(this.usuario);
            repositorioUsuario.Add(categoria);
        }

        public void AgregarCredencial(Credencial credencial)
        {
            IRepositorio<Credencial, int> repositorioUsuario = new CredencialRepositorio(this.usuario);
            repositorioUsuario.Add(credencial);
        }

        public void AgregarTarjeta(Tarjeta tarjeta)
        {
            IRepositorio<Tarjeta, int> repositorio = new TarjetaRepositorio(usuario);
            repositorio.Add(tarjeta);
        }
    }
}
