﻿using OblDiseño1;
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
        public int ContraseniaId { get; set; }
        public string Contrasenia { set; get; }
        public int NivelSeguridadContrasenia { set; get; }

        public EntidadCredencial Credencial { set; get; }

        public int CredencialId { get; set; }

        public EntidadContraseña() { }

        public EntidadContraseña(string unaContrasenia, int nivelSeguridadContrasenia)
        {
            this.Contrasenia = unaContrasenia;
            this.NivelSeguridadContrasenia = nivelSeguridadContrasenia;
        }
    }
}