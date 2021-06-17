using AccesoDatos.Entidades_Datos;
using System.Collections.Generic;
using OblDiseño1;
using System;

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
                EntidadDataBreach dataBreach = mapper.PasarAEntidadDataBreach
                    (dataBreachParametro, this.usuario);
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

        public ChequeadorDeDataBreaches Get(ChequeadorDeDataBreaches dataBreachABuscar)
        {
            using (Contexto contexto = new Contexto())
            {
                foreach (var dataBreach in contexto.dataBreach)
                    if (dataBreach.IdDataBrech == dataBreachABuscar.id && 
                        dataBreach.UsuarioNombre==this.usuario.Nombre)
                        return mapper.PasarADominioDataBreach(dataBreach, this.usuario);
            }
            return null;
        }

        public List<Tarjeta> ObtenerTarjetasVulneradas(ChequeadorDeDataBreaches chequeador)
        {
            List<Tarjeta> tarjetas = new List<Tarjeta>();
            using (Contexto contexto = new Contexto())
            {
                foreach (var tarjeta in contexto.dataBreachTarjetas)
                    if (tarjeta.DataBrechId == chequeador.id)
                        tarjetas.Add(mapper.PasarADominioTarjetaVulnerada(tarjeta));
            }
            return tarjetas;
        }

        public List<Credencial> ObtenerCredencialesVulneradas(ChequeadorDeDataBreaches chequeador)
        {
            List<Credencial> tarjetas = new List<Credencial>();
            using (Contexto contexto = new Contexto())
            {
                foreach (var credencial in contexto.dataBreachCredencial)
                    if (credencial.DataBrechId == chequeador.id)
                        tarjetas.Add(mapper.PasarADominioCredencialVulnerada(credencial));
            }
            return tarjetas;
        }

        public List<ChequeadorDeDataBreaches> GetAll()
        {
            List<ChequeadorDeDataBreaches> misDataBreaches = new List<ChequeadorDeDataBreaches>();
            using (Contexto contexto = new Contexto())
            {
                foreach (var dataBreach in contexto.dataBreach)
                    if (dataBreach.UsuarioNombre == this.usuario.Nombre)
                        misDataBreaches.Add(mapper.PasarADominioDataBreach(dataBreach, this.usuario));
            }
            return misDataBreaches;
        }
    }
}
