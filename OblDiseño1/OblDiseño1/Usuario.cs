using System.Collections.Generic;

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
        private Dictionary<Dupla_UsuarioContrasenia, Usuario> contraseniasCompartidasPorMi;

        public string Nombre { get => nombre; set => ActualizarNombre(value); }
        public string Contrasenia { get => contrasenia; set => ActualizarContrasenia(value); }

        public Usuario(string nombre, string contrasenia) { 
            Nombre = nombre;
            Contrasenia = contrasenia;
            this.categorias = new List<Categoria>();
            this.tarjetas = new List<Tarjeta>();
            this.duplas = new List<Dupla_UsuarioContrasenia>();
            this.contraseniasCompartidasConmigo = new Dictionary<Dupla_UsuarioContrasenia, Usuario>();
            this.contraseniasCompartidasPorMi = new Dictionary<Dupla_UsuarioContrasenia, Usuario>();
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

        public Dictionary<Dupla_UsuarioContrasenia, Usuario> ObtenerContraseniasCompartidasPorMi()
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
            this.categorias.Add(categoria);
        }

        public void EliminarCategoria(Categoria categoria)
        {
            this.categorias.Remove(categoria);
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

        public void CompartirContrasenia(Dupla_UsuarioContrasenia dupla, Usuario usuarioACompartir)
        {
            if (ExisteDuplaAsociada(dupla))
            {
                usuarioACompartir.ObtenerContraseniasCompartidasConmigo().Add(dupla, this);
                this.contraseniasCompartidasPorMi.Add(dupla, usuarioACompartir);
            }
            else
            {
                throw new InvalidUsuarioDataException("No existe una contraseña asociada a " +dupla.Contrasenia + "para este usuario");
            }
        }

        public bool ExisteDuplaAsociada(Dupla_UsuarioContrasenia dupla)
        {
            return this.ObtenerDuplas().Contains(dupla);
        }

        public void DejarDeCompartirContrasenia(Dupla_UsuarioContrasenia dupla, Usuario usuarioAlQueDejoDeCompartir)
        {
            if (this.ObtenerContraseniasCompartidasPorMi().ContainsKey(dupla))
            {
                this.ObtenerContraseniasCompartidasPorMi().Remove(dupla);
                usuarioAlQueDejoDeCompartir.ObtenerContraseniasCompartidasConmigo().Remove(dupla);
            }
            else
                throw new InvalidUsuarioDataException("La contraseña " +dupla.Contrasenia + "no ha sido compartido aun con este usuario" );
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



    }
}
