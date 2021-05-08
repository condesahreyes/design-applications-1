using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OblDiseño1
{

    public class Usuario
    {

        private string nombre;
        private string contrasenia;
        private const string mnsjUsuarioError = "El nombre de usuario debe tener entre" +
            " 1 y 25 caracteres";
        private const string mnsjContraseniaError = "La contraseña debe tener entre 5 y" +
            " 25 caracteres";

        private const int LARGO_NOMBRE_MIN = 1;
        private const int LARGO_NOMBRE_MAX = 25;
        private const int LARGO_CONTRASENIA_MIN = 5;
        private const int LARGO_CONTRASENIA_MAX = 25;

        private List<Dupla_UsuarioContrasenia> duplas;
        private List<Tarjeta> tarjetas;
        private List<Categoria> categorias;
        private Dictionary<Dupla_UsuarioContrasenia, Usuario> contraseniasCompartidasConmigo;
        private Dictionary<Dupla_UsuarioContrasenia, List<Usuario>> contraseniasCompartidasPorMi;
        private List<Usuario> usuariosQueYoComparto;

        public string Nombre { get => nombre; set => ActualizarNombre(value); }
        public string Contrasenia { get => contrasenia; set => ActualizarContrasenia(value); }

        public Usuario(string nombre, string contrasenia)
        {
            Nombre = nombre;
            Contrasenia = contrasenia;
            this.categorias = new List<Categoria>();
            this.tarjetas = new List<Tarjeta>();
            this.duplas = new List<Dupla_UsuarioContrasenia>();
            this.contraseniasCompartidasConmigo = new Dictionary<Dupla_UsuarioContrasenia, Usuario>();
            this.contraseniasCompartidasPorMi = new Dictionary<Dupla_UsuarioContrasenia, List<Usuario>>();
            this.usuariosQueYoComparto = new List<Usuario>();
        }

        public List<Tarjeta> ObtenerTarjetas()
        {
            return this.tarjetas;
        }

        public List<Dupla_UsuarioContrasenia> ObtenerDuplas()
        {
            return this.duplas;
        }

        public List<Categoria> ObtenerCategorias()
        {
            return this.categorias;
        }

        public Dictionary<Dupla_UsuarioContrasenia, Usuario> ObtenerContraseniasCompartidasConmigo()
        {
            return this.contraseniasCompartidasConmigo;
        }

        public Dictionary<Dupla_UsuarioContrasenia, List<Usuario>> ObtenerContraseniasCompartidasPorMi()
        {
            return this.contraseniasCompartidasPorMi;
        }

        private bool NombreInvalido(string unNombre)
        {
            if (unNombre.Length < LARGO_NOMBRE_MIN || unNombre.Length > LARGO_NOMBRE_MAX)
                return true;
            return false;
        }

        public void ActualizarNombre(string unNombre)
        {
            if (NombreInvalido(unNombre))
                throw new InvalidUsuarioDataException(mnsjUsuarioError);
            else
                this.nombre = unNombre;
        }

        private bool ContraseniaInvalida(string contrasenia)
        {
            if (contrasenia.Length < LARGO_CONTRASENIA_MIN ||
                contrasenia.Length > LARGO_CONTRASENIA_MAX)
                return true;
            return false;
        }

        public void ActualizarContrasenia(string unaContrasenia)
        {
            if (ContraseniaInvalida(unaContrasenia))
                throw new InvalidUsuarioDataException(mnsjContraseniaError);
            else
                this.contrasenia = unaContrasenia;
        }

        public void AgregarTarjeta(Tarjeta tarjeta)
        {
            this.tarjetas.Add(tarjeta);
        }

        public void EliminarTarjeta(Tarjeta tarjeta)
        {
            this.tarjetas.Remove(tarjeta);
        }

        public void AgregarDupla(Dupla_UsuarioContrasenia dupla)
        {
            this.duplas.Add(dupla);
        }

        public void EliminarDupla(Dupla_UsuarioContrasenia dupla)
        {
            this.duplas.Remove(dupla);
        }


        public void AgregarCategoria(Categoria categoria)
        {
            foreach (Categoria cat in categorias)
                if(cat.Nombre.ToLower() == categoria.Nombre.ToLower())
                    throw new DuplicateNameException();

            this.categorias.Add(categoria);
        }

        public void EliminarCategoria(Categoria categoria)
        {
            this.categorias.Remove(categoria);
        }

        public Categoria DevolverCategoria(string nombreCategoria)
        {

            foreach (Categoria cat in categorias)
                if (cat.Nombre == nombreCategoria)
                    return cat;
            return null;
        }

        public List<string> ListarTarjetas()
        {
            List<string> tarjetasString = new List<string>();
            for (int i = 0; i < this.ObtenerTarjetas().Count; i++)
                tarjetasString.Add(this.ObtenerTarjetas()[i].ToString());

            return tarjetasString;
        }

        public List<string> ListarCategorias()
        {
            List<string> categoriasString = new List<string>();

            for (int i = 0; i < this.ObtenerCategorias().Count; i++)
                categoriasString.Add(this.ObtenerCategorias()[i].ToString());

            return categoriasString;
        }

        public List<string> ListarDuplas()
        {
            List<string> duplasString = new List<string>();

            for (int i = 0; i < this.ObtenerDuplas().Count; i++)
                duplasString.Add(this.ObtenerDuplas()[i].ToString());

            return duplasString;
        }

        public void CompartirContrasenia(Dupla_UsuarioContrasenia duplaACompartir, Usuario usuarioACompartir)
        {
            if (ExisteDuplaAsociada(duplaACompartir))
                if (this.ObtenerContraseniasCompartidasPorMi().ContainsKey(duplaACompartir) && 
                    this.ObtenerContraseniasCompartidasPorMi()[duplaACompartir].Contains(usuarioACompartir))
                    throw new InvalidUsuarioDataException("Ya se compartio esta contraseña con el usuario" + 
                        usuarioACompartir.Nombre);
                else
                {
                    this.usuariosQueYoComparto.Add(usuarioACompartir);
                    this.ObtenerContraseniasCompartidasPorMi().Add(duplaACompartir, this.usuariosQueYoComparto);
                    usuarioACompartir.ObtenerContraseniasCompartidasConmigo().Add(duplaACompartir, this);
                }
            else
                throw new InvalidUsuarioDataException("No existe una contraseña asociada a " + 
                    duplaACompartir.Contrasenia + "para este usuario");
        }

        public bool ExisteDuplaAsociada(Dupla_UsuarioContrasenia dupla)
        {
            return this.ObtenerDuplas().Contains(dupla);
        }

        public void DejarDeCompartirContrasenia(Dupla_UsuarioContrasenia duplaADejarDeCompartir, 
            Usuario usuarioAlQueDejoDeCompartir)
        {
            if (ExisteDuplaAsociada(duplaADejarDeCompartir))
                if (this.ObtenerContraseniasCompartidasPorMi()[duplaADejarDeCompartir].Contains(usuarioAlQueDejoDeCompartir))
                {
                    this.ObtenerContraseniasCompartidasPorMi()[duplaADejarDeCompartir].Remove(usuarioAlQueDejoDeCompartir);
                    if (this.ObtenerContraseniasCompartidasPorMi()[duplaADejarDeCompartir].Count == 0)
                        this.ObtenerContraseniasCompartidasPorMi().Remove(duplaADejarDeCompartir);
                    usuarioAlQueDejoDeCompartir.ObtenerContraseniasCompartidasConmigo().Remove(duplaADejarDeCompartir);
                }
                else
                {
                    throw new InvalidUsuarioDataException("Esta contraseña no ha sido compartida anteriormente con el usuario"
                        + usuarioAlQueDejoDeCompartir.Nombre);
                }
            else
                throw new InvalidUsuarioDataException("No existe una contraseña asociada a " +
                    duplaADejarDeCompartir.Contrasenia + "para este usuario");
        }

        public List<string> ConvertirDiccionarioAListaString(Dictionary<Dupla_UsuarioContrasenia, Usuario> contrasenias)
        {
            List<string> resultado = new List<string>();
            foreach (var iterador in contrasenias)
            {
                resultado.Add(iterador.Key.ToString());
            }
            return resultado;
        }

        public List<string> ConvertirDiccionarioConListaAListaString(Dictionary<Dupla_UsuarioContrasenia, 
            List<Usuario>> contrasenias)
        {
            List<string> resultado = new List<string>();
            foreach (var iterador in contrasenias)
                resultado.Add(iterador.Key.ToString());
            return resultado;
        }

        public reporte ObtenerReporteSeguridadContrasenias()
        {
            paresSeguridad[] misPares = new paresSeguridad[6];
            Dictionary<string, int[]> categoria = new Dictionary<string, int[]>();
            foreach (Categoria cat in this.categorias)
                categoria.Add(cat.Nombre, new int[6]);

            for (int i = 0; i < 6; i++)
                misPares[i] = new paresSeguridad(0, null);

            foreach (Dupla_UsuarioContrasenia dupla in this.duplas)
            {

                string nombreCategoria = dupla.Categoria.Nombre;
                int nivelSeguridad = dupla.NivelSeguridadContrasenia;
                categoria[nombreCategoria][nivelSeguridad] = categoria[nombreCategoria][nivelSeguridad] + 1;
                misPares[nivelSeguridad].unaListaDuplas.Add(dupla);
                misPares[nivelSeguridad].cantidad++;
            }
            reporte miReporte = new reporte(misPares, categoria);
            return miReporte;
        }

        public override bool Equals(object obj)
        {
            Usuario usuarioAComparar = (Usuario)obj;
            if (Nombre.Equals(usuarioAComparar.Nombre))
                return true;
            else
                return false;
        }

    }

    public struct reporte
    {
        public paresSeguridad[] duplasPorSeguridad;
        public Dictionary<string, int[]> duplasPorCategoria;

        public reporte(paresSeguridad[] pares, Dictionary<string, int[]> dicionrio)
        {
            duplasPorSeguridad = pares;
            duplasPorCategoria = dicionrio;
        }
    }

    public struct paresSeguridad
    {
        public int cantidad;
        public List<Dupla_UsuarioContrasenia> unaListaDuplas;

        public paresSeguridad(int cant, List<Dupla_UsuarioContrasenia> dupla)
        {
            cantidad = cant;
            unaListaDuplas = new List<Dupla_UsuarioContrasenia>();
        }
    }
}



