using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblDiseño1.ControladoresPorEntidades
{
    public class ControladorUsuario
    {
        IRepositorio<Usuario, string> repositorio;
        public ControladorUsuario(IRepositorio<Usuario, string> repositorio)
        {
            this.repositorio = repositorio;
        }
    }
}
