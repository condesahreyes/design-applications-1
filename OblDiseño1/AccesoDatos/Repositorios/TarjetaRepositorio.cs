using AccesoDatos.Entidades_Datos;
using OblDiseño1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class TarjetaRepositorio : IRepositorio<Tarjeta, int>
    {
        private readonly Mapper mapper = new Mapper();

        public EntidadUsuario usuario;
        public TarjetaRepositorio(Usuario usuarioDueñoDominio)
        {
            this.usuario = mapper.PasarAEntidad(usuarioDueñoDominio);
        }
        public void Add(Tarjeta tarjetaDominio) 
        {
            using (Contexto contexto = new Contexto())
            {
                int numeroTarjetaAInt = Int32.Parse(tarjetaDominio.Numero);
                if (Existe(numeroTarjetaAInt))
                    throw new ExepcionObjetosRepetidos("Ya existe una tarjeta con este numero");
                else
                {
                    /*
                    EntidadTarjeta tarjetaEntidad = mapper.PasarAEntidad(tarjetaDominio);
                    tarjetaEntidad.Usuario = this.usuario;
                    contexto.tarjetas.Add(tarjetaEntidad);
                    contexto.SaveChanges();
                    */
                }
            }
        }

        public bool esVacio() 
        {
            using (Contexto contexto = new Contexto())
            {
                if (contexto.tarjetas.Count() == 0)
                    return true;
                else
                    return false;
            }
        }

        public Tarjeta Get(int numero) 
        {
            using (Contexto contexto = new Contexto())
            {
                if (Existe(numero))
                {
                    EntidadTarjeta tarjetaEntidad = contexto.tarjetas.Find(numero);
                    Tarjeta tarjetaDominio = mapper.PasarADominio(tarjetaEntidad);
                    return tarjetaDominio;
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe una tarjeta con este numero");
            }
                

        }

        public List<Tarjeta> GetAll() 
        {
            using (Contexto contexto = new Contexto())
            {
                if (!esVacio())
                {
                    List<Tarjeta> tarjetasADevolver = new List<Tarjeta>();
                    foreach (var tarjetaEntidad in contexto.tarjetas)
                    {
                        Tarjeta tarjetaDominio = mapper.PasarADominio(tarjetaEntidad);
                        tarjetasADevolver.Add(tarjetaDominio);
                    }
                    return tarjetasADevolver;
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existen tarjetas en el sistema");
            }
        }

        public void Delete(int numero)
        {
            using (Contexto contexto = new Contexto())
            {
                if (Existe(numero))
                {
                    EntidadTarjeta tarjetaABorrar = contexto.tarjetas.Find(numero);
                    contexto.tarjetas.Remove(tarjetaABorrar);
                    contexto.SaveChanges();
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe una tarjeta con este numero");
            }
        }

        public void Clear()
        {
            using (Contexto contexto = new Contexto())
            {
                contexto.tarjetas.RemoveRange(contexto.tarjetas);
            }
        }

        public bool Existe(int numero)
        {
            using (Contexto contexto = new Contexto())
            {
                if (contexto.tarjetas.Any(tarjetaEntidad => tarjetaEntidad.Numero == numero))
                    return true;
                else
                    return false;
            }
        }

        public List<Categoria> ObtenerMisCategorias(string nombre)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Tarjeta elemento)
        {
            throw new NotImplementedException();
        }
    }
}
