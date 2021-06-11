using OblDiseño1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades_Datos
{
    public class EntidadContraseña
    {
        public string Contrasenia { set; get; }
        public int NivelSeguridadContrasenia { set; get; }

        public EntidadCredencial Credencial { set; get; }
        public string CredencialNombre { set; get; }
        public string CredencialSitio { set; get; }
        public string CredencialUsuario { set; get; }

        public EntidadContraseña() { }

        public EntidadContraseña(string unaContrasenia, int nivelSeguridadContrasenia, Credencial credencial)
        {
            this.Contrasenia = unaContrasenia;
            this.NivelSeguridadContrasenia = nivelSeguridadContrasenia;
            this.CredencialNombre = credencial.NombreUsuario;
            this.CredencialSitio = credencial.NombreSitioApp;
            this.CredencialUsuario = credencial.NombreUsuario;
        }
    }
}
