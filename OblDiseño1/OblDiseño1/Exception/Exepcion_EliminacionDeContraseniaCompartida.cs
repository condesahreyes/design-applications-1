using System;


namespace OblDiseño1.Exception
{
    public class Exepcion_EliminacionDeContraseniaCompartida : SystemException
    {

        public Exepcion_EliminacionDeContraseniaCompartida(string message) : base(message)
        {
        }

    }
}
