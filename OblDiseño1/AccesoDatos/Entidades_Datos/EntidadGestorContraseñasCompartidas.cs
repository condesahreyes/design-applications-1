using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades_Datos
{
    public class EntidadGestorContraseñasCompartidas
    {
        public EntidadUsuario usuarioDueño { set; get; }

        public Dictionary<EntidadUsuario, List<EntidadCredencial>> contraseniasCompartidasConmigo { set; get; }
        public Dictionary<EntidadCredencial, List<EntidadUsuario>> contraseniasCompartidasPorMi { set; get; }
    }
}
