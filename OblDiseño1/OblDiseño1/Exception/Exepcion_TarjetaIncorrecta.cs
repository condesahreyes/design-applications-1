using System;

namespace OblDiseño1
{

    public class Exepcion_TarjetaIncorrecta : SystemException
    {

        public Exepcion_TarjetaIncorrecta(string message) : base(message)
        {
        }

    }
}