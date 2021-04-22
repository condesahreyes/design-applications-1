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

        public ReporteSeguridadContrasenias ObtenerReporteSeguridadContrasenias()
        {
            ReporteSeguridadContrasenias reporte = new ReporteSeguridadContrasenias(76);
            foreach (Dupla_UsuarioContrasenia dupla in this.duplas)
            {
                switch (dupla.NivelSeguridadContrasenia)
                {
                    case 1:
                        reporte.numeroContrasROJO++;
                        reporte.ListaROJO.Add(dupla);
                        break;
                    case 2:
                        reporte.numeroContrasNARANJA++;
                        reporte.ListaNARANJA.Add(dupla);
                        break;
                    case 3:
                        reporte.numeroContrasAMARILLO++;
                        reporte.ListaAMARILLO.Add(dupla);
                        break;
                    case 4:
                        reporte.numeroContrasVERDE_CLARO++;
                        reporte.ListaVERDE_CLARO.Add(dupla);
                        break;
                    case 5:
                        reporte.numeroContrasVERDE_OSCURO++;
                        reporte.ListaVERDE_OSCURO.Add(dupla);
                        break;
                    default:
                        throw new Exepcion_NivelDeSeguridadNoValido("Una de las Duplas " +
                            "devolvio un nivel de seguridad fuera del rango valido (1 a 5)" +
                            " en \"ObtenerReporteSeguridadContrasenias()\"");
                        break;
                }
            }
            return reporte;
        }
    }

    public struct ReporteSeguridadContrasenias
    {
        public int numeroContrasROJO;
        public int numeroContrasNARANJA;
        public int numeroContrasAMARILLO;
        public int numeroContrasVERDE_CLARO;
        public int numeroContrasVERDE_OSCURO;
        public List<Dupla_UsuarioContrasenia> ListaROJO;
        public List<Dupla_UsuarioContrasenia> ListaNARANJA;
        public List<Dupla_UsuarioContrasenia> ListaAMARILLO;
        public List<Dupla_UsuarioContrasenia> ListaVERDE_CLARO;
        public List<Dupla_UsuarioContrasenia> ListaVERDE_OSCURO;

        public ReporteSeguridadContrasenias(int placeHolder)
        {
            this.numeroContrasROJO = 0;
            this.numeroContrasNARANJA = 0;
            this.numeroContrasAMARILLO = 0;
            this.numeroContrasVERDE_CLARO = 0;
            this.numeroContrasVERDE_OSCURO = 0;
            this.ListaROJO = new List<Dupla_UsuarioContrasenia> { };
            this.ListaNARANJA = new List<Dupla_UsuarioContrasenia> { };
            this.ListaAMARILLO = new List<Dupla_UsuarioContrasenia> { };
            this.ListaVERDE_CLARO = new List<Dupla_UsuarioContrasenia> { };
            this.ListaVERDE_OSCURO = new List<Dupla_UsuarioContrasenia> { };
        }
    }

}
