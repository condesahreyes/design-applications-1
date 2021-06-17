using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades_Datos
{
    public class EntidadRegistroCredencialCompartida
    {
        public string NombreUsuarioQueComparte { get; set; }
        public EntidadUsuario UsuarioQueComparte { get; set; }

        public string NombreUsuarioAlQueSeLeCompartio { get; set; }
        public EntidadUsuario UsuarioAlQueSeLeCompartio { get; set; }

        public int CredencialCompartidaId { get; set; }
        public EntidadCredencial CredencialCompartida { get; set; }


        public EntidadRegistroCredencialCompartida() { }

        public EntidadRegistroCredencialCompartida(string nombreUsuarioComparte,
            string nombreUsuarioQueRecibe, int IdCredencial)
        {
            this.NombreUsuarioQueComparte = nombreUsuarioComparte;
            this.NombreUsuarioAlQueSeLeCompartio = nombreUsuarioQueRecibe;
            this.CredencialCompartidaId = IdCredencial;
        }
    }
}
