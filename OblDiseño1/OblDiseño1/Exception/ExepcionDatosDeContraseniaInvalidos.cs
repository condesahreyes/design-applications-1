﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblDiseño1
{
    public class ExepcionDatosDeContraseniaInvalidos : SystemException
    {
        public ExepcionDatosDeContraseniaInvalidos(string message) : base(message)
        {

        }

    }
}
