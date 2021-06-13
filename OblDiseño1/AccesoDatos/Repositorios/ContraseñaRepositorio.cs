using AccesoDatos.Entidades_Datos;
using OblDiseño1;
using OblDiseño1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ContraseñaRepositorio : IRepositorio<Contraseña>
    {
        private readonly Mapper mapper = new Mapper();

        public EntidadUsuario usuario;
        public ContraseñaRepositorio(Usuario usuarioDueñoDominio)
        {
            this.usuario = mapper.PasarAEntidad(usuarioDueñoDominio);
        }
        public void Add(Contraseña contraseña)
        {
            using (Contexto contexto = new Contexto())
            {
                EntidadContraseña miContraseña = new EntidadContraseña(contraseña.Contrasenia,
                contraseña.NivelSeguridadContrasenia);
                miContraseña.CredencialId = contexto.credenciales.Count();
                contexto.contraseñas.Add(miContraseña);
                contexto.SaveChanges();
            }
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Contraseña contraseña)
        {
            throw new System.NotImplementedException();
        }

        public bool esVacio()
        {
            throw new System.NotImplementedException();
        }

        public bool Existe(Contraseña contraseña)
        {
            using (Contexto contexto = new Contexto())
            {
                if (contexto.contraseñas.Any(contra => contra.Contrasenia == contraseña.Contrasenia))
                    return true;
                else
                    return false;
            }
        }

        public Contraseña Get(Contraseña contraseña)
        {
            throw new System.NotImplementedException();
        }

        public List<Contraseña> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Modificar(Contraseña elemento)
        {
            throw new NotImplementedException();
        }

        public List<Categoria> ObtenerMisCategorias(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
