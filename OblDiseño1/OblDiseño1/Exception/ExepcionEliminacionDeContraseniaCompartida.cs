using System;


namespace OblDiseño1.Exception
{
    public class ExepcionEliminacionDeContraseniaCompartida : SystemException
    {

        public ExepcionEliminacionDeContraseniaCompartida(string message) : base(message)
        {
        }

    }
}
