using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblDiseño1
{
    public class ChequeadorDeDataBreaches
    {
        //IMPORTANTE: Cuando este en fase de refracteo, tengo que cambiar los "Breacheados" por "Vulnerados"

        private Usuario usuario;


        public Usuario Usuario { get => usuario; }

        public ChequeadorDeDataBreaches(Usuario unUsuario)
        {
            this.usuario = unUsuario;
        }

        public List<Object> ObtenerEntidadesVulneradas(List<string> datosDelDataBreach)
        {
            List<Object> datosVulnerados = new List<Object>();
            List<Object> tarjetasVulneradas = ObtenerTarjetasVulneradas(datosDelDataBreach);
            List<Object> duplasVulneradas = ObtenerDuplasVulneradas(datosDelDataBreach);

            if (tarjetasVulneradas != null) datosVulnerados.AddRange(tarjetasVulneradas);
            if (duplasVulneradas != null) datosVulnerados.AddRange(duplasVulneradas);
            return datosVulnerados;
        }


        public List<Object> ObtenerTarjetasVulneradas(List<string> datosDelDataBreach)
        {
            List<Object> tarjetasVulneradas = new List<Object>();
            foreach(string dato in datosDelDataBreach)
            {
                if (EsNumeroDeTarjetaValido(dato))
                {
                    foreach(Tarjeta tarjeta in usuario.getTarjetas()) 
                    {
                        string numeroDeLaTarjetaAString = "" + tarjeta.Numero;
                        if (dato.Equals(numeroDeLaTarjetaAString))
                        {
                            tarjetasVulneradas.Add(tarjeta);
                        }
                    }
                }
            }
            return tarjetasVulneradas;
        }

        public List<Object> ObtenerDuplasVulneradas(List<string> datosDelDataBreach)
        {
            List<Object> duplasVulneradas = new List<Object>();
            foreach(string dato in datosDelDataBreach)
            {
                foreach (Dupla_UsuarioContrasenia dupla in Usuario.getDuplas())
                {
                    if (dato.Equals(dupla.PssDupla))
                    {
                        duplasVulneradas.Add(dupla);
                    }
                }
            }
            return duplasVulneradas;
        }


        public bool EsNumeroDeTarjetaValido(string posibleNumeroDeTarjeta)
        {
            bool esValido = true;
            if (!(posibleNumeroDeTarjeta.Length == 16))
            {
                esValido = false;
            }
            else
            {
                for (int i = 0; i < posibleNumeroDeTarjeta.Length && esValido; i++)
                {
                    int codigoASCII = (int)posibleNumeroDeTarjeta[i];
                    if (codigoASCII < 48 || codigoASCII > 57)
                    {
                        esValido = false;
                    }
                }
            }
            return esValido;
        }

        /*  public void agregarBreach(List<string> listaInfoBreacheada)
          {
              List<string> 
              if ()
              {
                  agregarYReviar
                  this.infoBreacheada.AddRange(listaInfoBreacheada);
              }      
          }

          public void agregarDatoBreachado(string datoBreachado)
          {
              this.infoBreacheada.Add(datoBreachado);
          }
        */
    }
    /*
        struct ContraseniaVulnerada
        {
            string contrasenia;
            Dupla_UsuarioContrasenia dupla;

            public ContraseniaVulnerada(string contra, Dupla_UsuarioContrasenia dupla)
            {
                this.contrasenia = contra;
                this.dupla = dupla;
            }

            public bool SigueSiendoVulnerable()
            {
                return this.contrasenia.Equals(dupla.PssDupla);
            }
        }

        struct NumeroTajetaVulnerada
        {
            double numero;
            Tarjeta tarjeta;

            public NumeroTajetaVulnerada(double num, Tarjeta tarjeta)
            {
                this.numero = num;
                this.tarjeta = tarjeta;
            }

            public bool SigueSiendoVulnerable()
            {
                return this.numero == tarjeta.Numero;
            }
        }
    */
}
