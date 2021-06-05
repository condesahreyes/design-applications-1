using System;
using System.Runtime.Serialization;

namespace OblDiseño1
{

    public class ExepcionNivelDeSeguridadNoValido : SystemException
    {
        public ExepcionNivelDeSeguridadNoValido(string message) : base(message)
        {

        }

    }
}