using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblDiseño1.ControladoresPorFuncionalidad
{
    public class ControladorObtener
    {
        public ControladorObtener()
        {
        }
        public Usuario ObtenerUsuario(Usuario usuario, IRepositorio<Usuario> repositorioUsuario)
        {
            return repositorioUsuario.Get(usuario);
        }

        public Categoria ObtenerCategoria(Categoria categoria, IRepositorio<Categoria> repositorioCategoria)
        {
            return repositorioCategoria.Get(categoria);
        }

        public List<Categoria> ObtenerCategorias(IRepositorio<Categoria> repositorioCategoria)
        {
            return repositorioCategoria.GetAll();
        }


        public Tarjeta ObtenerTarjeta(Tarjeta tarjetaAgregar, IRepositorio<Tarjeta> repositorioTarjeta)
        {
            return repositorioTarjeta.Get(tarjetaAgregar);
        }

        public bool ExisteTarjeta(string numeroTarjeta, IRepositorio<Tarjeta> repositorioTarjeta)
        {
            Tarjeta tarjeta = new Tarjeta();
            tarjeta.Numero = numeroTarjeta;
            return repositorioTarjeta.Existe(tarjeta);
        }

        public List<Tarjeta> ObtenerTarjetas(IRepositorio<Tarjeta> repositorioTarjeta)
        {
            return repositorioTarjeta.GetAll();
        }

        public Credencial ObtenerCredencial(Credencial credencialAgregar, IRepositorio<Credencial> repositorioCredencial)
        {
            return repositorioCredencial.Get(credencialAgregar);
        }

        public List<Credencial> ObtenerCredenciales(IRepositorio<Credencial> repositorioCredencial)
        {
            return repositorioCredencial.GetAll();
        }
    }
}
