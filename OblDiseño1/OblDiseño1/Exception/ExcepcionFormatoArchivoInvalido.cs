﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblDiseño1.Exception
{
    public class ExcepcionFormatoArchivoInvalido : SystemException
    {

        public ExcepcionFormatoArchivoInvalido(string message) : base(message)
        {
        }
    }
}
