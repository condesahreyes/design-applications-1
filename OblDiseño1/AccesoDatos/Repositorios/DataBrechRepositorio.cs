using AccesoDatos.Entidades_Datos;
using OblDiseño1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorios
{
    public class DataBrechRepositorio : IRepositorio<ChequeadorDeDataBreaches>
    {
        private readonly Mapper mapper = new Mapper();
        private Usuario usuario;

        public DataBrechRepositorio(Usuario usuarioDueñoDominio)
        {
            this.usuario = usuarioDueñoDominio;
        }

        public void Add(ChequeadorDeDataBreaches dataBreachParametro)
        {
            using (Contexto contexto = new Contexto())
            {
                EntidadDataBreach dataBreach = mapper.PasarAEntidadDataBreach(dataBreachParametro, this.usuario);
                contexto.dataBreach.Add(dataBreach);
                contexto.SaveChanges();
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Delete(ChequeadorDeDataBreaches elemento)
        {
            throw new NotImplementedException();
        }

        public bool esVacio()
        {
            throw new NotImplementedException();
        }

        public bool Existe(ChequeadorDeDataBreaches elemento)
        {
            throw new NotImplementedException();
        }

        public void Modificar(ChequeadorDeDataBreaches elementoOriginal, ChequeadorDeDataBreaches elemento)
        {
            throw new NotImplementedException();
        }

        ChequeadorDeDataBreaches IRepositorio<ChequeadorDeDataBreaches>.Get(ChequeadorDeDataBreaches elemento)
        {
            throw new NotImplementedException();
        }

        List<ChequeadorDeDataBreaches> IRepositorio<ChequeadorDeDataBreaches>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
