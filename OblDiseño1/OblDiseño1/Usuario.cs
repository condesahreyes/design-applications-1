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

        public string Nombre { get => nombre; set => ActualizarNombre(value); }
        public string Contrasenia { get => contrasenia; set => ActualizarContrasenia(value); }


        public Usuario(string nombre, string contrasenia)
        {
            Nombre = nombre;
            Contrasenia = contrasenia;
            this.categorias = new List<Categoria>();
            this.tarjetas = new List<Tarjeta>();
            this.duplas = new List<Dupla_UsuarioContrasenia>();
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

        public override bool Equals(object obj)
        {
            Usuario usuarioAComparar = (Usuario)obj;
            if (Nombre.Equals(usuarioAComparar.Nombre))
                return true;
            else
                return false;
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


}
