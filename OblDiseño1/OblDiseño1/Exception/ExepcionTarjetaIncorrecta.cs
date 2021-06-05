using System;

namespace OblDiseño1
{

    public class ExepcionTarjetaIncorrecta : SystemException
    {

        public ExepcionTarjetaIncorrecta(string message) : base(message)
        {
        }

    }
}