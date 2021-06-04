using System.Collections.Generic;
using System.Data;

namespace OblDiseño1
{

    public class Usuario
    {

        private string nombre;
        private string contrasenia;
        private const string mnsjNombreUsuarioError = "El nombre de usuario debe tener entre" +
                                                    " 1 y 25 caracteres";
        private const string mnsjContraseniaError = "La contraseña debe tener entre 5 y" +
                                                    " 25 caracteres";
        private const string mnsjDuplaYaPresenteError = "Se intento agregar una Dupla que ya" +
                                                    " pertenecia al Usuario";

        private const int LARGO_NOMBRE_MIN = 1;
        private const int LARGO_NOMBRE_MAX = 25;
        private const int LARGO_CONTRASENIA_MIN = 5;
        private const int LARGO_CONTRASENIA_MAX = 25;

        private List<Dupla_UsuarioContrasenia> duplas;
        private List<Tarjeta> tarjetas;
        private List<Categoria> categorias;
        private Dictionary<Usuario, List<Dupla_UsuarioContrasenia>> contraseniasCompartidasConmigo;
        private Dictionary<Dupla_UsuarioContrasenia, List<Usuario>> contraseniasCompartidasPorMi;


      
        public string Nombre { get => nombre; set => ActualizarNombreUsuario(value); }
        public string Contrasenia { get => contrasenia; set => ActualizarContrasenia(value); }

        public Usuario() { }

        public Usuario(string nombre, string contrasenia)
        {
            Nombre = nombre;
            Contrasenia = contrasenia;
            this.categorias = new List<Categoria>();
            this.tarjetas = new List<Tarjeta>();
            this.duplas = new List<Dupla_UsuarioContrasenia>();
            this.contraseniasCompartidasConmigo = new Dictionary<Usuario, List<Dupla_UsuarioContrasenia>>();
            this.contraseniasCompartidasPorMi = new Dictionary<Dupla_UsuarioContrasenia, List<Usuario>>();
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


        public Dictionary<Usuario, List<Dupla_UsuarioContrasenia>> ObtenerContraseniasCompartidasConmigo()
        {
            return this.contraseniasCompartidasConmigo;
        }

        public Dictionary<Dupla_UsuarioContrasenia, List<Usuario>> ObtenerContraseniasCompartidasPorMi()
        {
            return this.contraseniasCompartidasPorMi;
        }

        private bool ValidarNombreUsuario(string unNombre)
        {
            if (unNombre.Length < LARGO_NOMBRE_MIN || unNombre.Length > LARGO_NOMBRE_MAX)
                return true;
            return false;
        }

        public void ActualizarNombreUsuario(string unNombre)
        {
            if (ValidarNombreUsuario(unNombre))
                throw new Exepcion_InvalidUsuarioData(mnsjNombreUsuarioError);
            else
                this.nombre = unNombre;
        }

        private bool ValidarContrasenia(string contrasenia)
        {
            if (contrasenia.Length < LARGO_CONTRASENIA_MIN ||
                contrasenia.Length > LARGO_CONTRASENIA_MAX)
                return true;
            return false;
        }

        public void ActualizarContrasenia(string unaContrasenia)
        {
            if (ValidarContrasenia(unaContrasenia))
                throw new Exepcion_InvalidUsuarioData(mnsjContraseniaError);
            else
                this.contrasenia = unaContrasenia;
        }

        public void AgregarTarjeta(Tarjeta tarjeta)
        {
            if (this.ObtenerTarjetas().Contains(tarjeta))
                throw new Exepcion_ObjetosRepetidos("Ya existe una tarjeta con el mismo numero");
            else
                this.tarjetas.Add(tarjeta);
        }

        public void EliminarTarjeta(Tarjeta tarjeta)
        {
            this.tarjetas.Remove(tarjeta);
        }

        public void AgregarDupla(Dupla_UsuarioContrasenia dupla)
        {
            if (this.duplas.Contains(dupla))
                throw new Exepcion_InvalidUsuarioData(mnsjDuplaYaPresenteError);
            else
                this.duplas.Add(dupla);
        }

        public void EliminarDupla(Dupla_UsuarioContrasenia dupla)
        {
            this.duplas.Remove(dupla);
        }

        public void AgregarCategoria(Categoria categoria)
        {
            foreach (Categoria cat in categorias)
                if (cat.Nombre.ToLower() == categoria.Nombre.ToLower())
                    throw new DuplicateNameException();

            this.categorias.Add(categoria);
        }

        public void EliminarCategoria(Categoria categoria)
        {
            this.categorias.Remove(categoria);
        }

        public List<string> ListarToStringDeMisCategorias()
        {
            List<string> categoriasString = new List<string>();

            for (int i = 0; i < this.ObtenerCategorias().Count; i++)
                categoriasString.Add(this.ObtenerCategorias()[i].ToString());

            return categoriasString;
        }

        public List<string> ListarToStringDeMisDuplas()
        {
            List<string> duplasString = new List<string>();

            for (int i = 0; i < this.ObtenerDuplas().Count; i++)
                duplasString.Add(this.ObtenerDuplas()[i].ToString());

            return duplasString;
        }

        public void CompartirContrasenia(Dupla_UsuarioContrasenia duplaACompartir, Usuario usuarioACompartir)
        {
            if (VerificarQueLaDuplaEsMia(duplaACompartir))
            {
                if (VerificarQueYaSeCompartioLaContraseniaConElUsuario(duplaACompartir, usuarioACompartir))
                    throw new Exepcion_InvalidUsuarioData("Ya se compartio esta contraseña con el usuario" +
                        usuarioACompartir.Nombre);
                else
                {
                    GuardarLaContraseniaACompartir(duplaACompartir, usuarioACompartir);
                    CompartirContraseniaAUsuario(duplaACompartir, usuarioACompartir);
                }
            }
            else
                throw new Exepcion_InvalidUsuarioData("No existe una contraseña asociada a " +
                    duplaACompartir.Contrasenia + "para este usuario");
        }

        private void GuardarLaContraseniaACompartir(Dupla_UsuarioContrasenia duplaACompartir, Usuario usuarioACompartir)
        {
            if (VerificarQueEstoyCompartiendoLaContraseniaConAlguien(duplaACompartir))
                this.ObtenerContraseniasCompartidasPorMi()[duplaACompartir].Add(usuarioACompartir);
            else
                CompartirContraseniaPorPrimeraVez(duplaACompartir, usuarioACompartir);
        }

        private void CompartirContraseniaAUsuario(Dupla_UsuarioContrasenia duplaACompartir, Usuario usuarioACompartir)
        {
            if (usuarioACompartir.VerificarQueElUsuarioMeEstaCompartiendoAlgunaContrasenia(this))
                usuarioACompartir.ObtenerContraseniasCompartidasConmigo()[this].Add(duplaACompartir);
            else
                usuarioACompartir.MeCompartenLaContraseniaPorPrimeraVez(this, duplaACompartir);
        }

        public bool VerificarQueLaDuplaEsMia(Dupla_UsuarioContrasenia dupla)
        {
            return this.ObtenerDuplas().Contains(dupla);
        }

        public bool VerificarQueYaSeCompartioLaContraseniaConElUsuario(Dupla_UsuarioContrasenia dupla, Usuario usuario)
        {
            return (this.ObtenerContraseniasCompartidasPorMi().ContainsKey(dupla) &&
                    this.ObtenerContraseniasCompartidasPorMi()[dupla].Contains(usuario));
        }

        public bool VerificarQueEstoyCompartiendoLaContraseniaConAlguien(Dupla_UsuarioContrasenia dupla)
        {
            return (this.ObtenerContraseniasCompartidasPorMi().ContainsKey(dupla));
        }

        public bool VerificarQueElUsuarioMeEstaCompartiendoAlgunaContrasenia(Usuario usuario)
        {
            return (this.ObtenerContraseniasCompartidasConmigo().ContainsKey(usuario));
        }

        public void CompartirContraseniaPorPrimeraVez(Dupla_UsuarioContrasenia duplaACompartir, Usuario usuarioACompartir)
        {
            List<Usuario> listaConPrimerUsuario = new List<Usuario>();
            listaConPrimerUsuario.Add(usuarioACompartir);
            this.ObtenerContraseniasCompartidasPorMi().Add(duplaACompartir, listaConPrimerUsuario);
        }

        public void MeCompartenLaContraseniaPorPrimeraVez(Usuario usuarioQueMeComparte, Dupla_UsuarioContrasenia duplaQueMeComparte)
        {
            List<Dupla_UsuarioContrasenia> listaConPrimerDupla = new List<Dupla_UsuarioContrasenia>();
            listaConPrimerDupla.Add(duplaQueMeComparte);
            this.ObtenerContraseniasCompartidasConmigo().Add(usuarioQueMeComparte, listaConPrimerDupla);
        }

        public void DejarDeCompartirContrasenia(Dupla_UsuarioContrasenia duplaADejarDeCompartir, Usuario usuarioAlQueDejoDeCompartir)
        {
            if (VerificarQueLaDuplaEsMia(duplaADejarDeCompartir))
                if (VerificarQueEstaSiendoCompartidaLaContraseniaConElUsuario(duplaADejarDeCompartir, usuarioAlQueDejoDeCompartir))
                {
                    this.ObtenerContraseniasCompartidasPorMi()[duplaADejarDeCompartir].Remove(usuarioAlQueDejoDeCompartir);
                    if (VerificarQueNoEstoyCompartiendoLaContraseniaConAlguien(duplaADejarDeCompartir))
                        this.ObtenerContraseniasCompartidasPorMi().Remove(duplaADejarDeCompartir);
                    usuarioAlQueDejoDeCompartir.ObtenerContraseniasCompartidasConmigo()[this].Remove(duplaADejarDeCompartir);
                    if (usuarioAlQueDejoDeCompartir.ObtenerContraseniasCompartidasConmigo()[this].Count == 0)
                        usuarioAlQueDejoDeCompartir.ObtenerContraseniasCompartidasConmigo().Remove(this);
                }
                else
                {
                    throw new Exepcion_InvalidUsuarioData("Esta contraseña no ha sido compartida " +
                        "anteriormente con el usuario" + usuarioAlQueDejoDeCompartir.Nombre);
                }
            else
                throw new Exepcion_InvalidUsuarioData("No existe una contraseña asociada a " +
                    duplaADejarDeCompartir.Contrasenia + "para este usuario");
        }

        public bool VerificarQueEstaSiendoCompartidaLaContraseniaConElUsuario(Dupla_UsuarioContrasenia dupla,
            Usuario usuario)
        {
            if (this.ObtenerContraseniasCompartidasPorMi().ContainsKey(dupla))
                return (this.ObtenerContraseniasCompartidasPorMi()[dupla].Contains(usuario));
            else
                return false;
        }

        public bool VerificarQueNoEstoyCompartiendoLaContraseniaConAlguien(Dupla_UsuarioContrasenia dupla)
        {
            return (this.ObtenerContraseniasCompartidasPorMi()[dupla].Count == 0);
        }


        public List<string> ConvertirContraseñasCompartidasPorMiAListaString(Dictionary<Dupla_UsuarioContrasenia,
            List<Usuario>> contrasenias)
        {
            List<string> resultado = new List<string>();
            foreach (var iterador in contrasenias)
            {
                resultado.Add(iterador.Key.ToString());
            }
            return resultado;
        }

        public List<string> ConvertirContraseñasCompartidasConmigoAListaString(Dictionary<Usuario,
            List<Dupla_UsuarioContrasenia>> contrasenias)
        {
            List<string> resultado = new List<string>();
            foreach (var iterador in contrasenias)
            {
                foreach (var iteradorDuplas in iterador.Value)
                    resultado.Add(iteradorDuplas.ToString());
            }
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

        public void RemoverDupla(Dupla_UsuarioContrasenia duplaARemover)
        {
            if (this.duplas.Contains(duplaARemover))
                this.duplas.Remove(duplaARemover);
        }

        public bool RevisarSiLaContraseniaEsMia(string unaContrasenia)
        {
            foreach (Dupla_UsuarioContrasenia unaDupla in this.duplas)
                if (unaDupla.Contrasenia == unaContrasenia)
                    return true;

            return false;
        }

        public List<Dupla_UsuarioContrasenia> ObtenerDuplasConLaContrasenia(string laContrasenia)
        {
            List<Dupla_UsuarioContrasenia> lasDuplasQueMePidieron = new List<Dupla_UsuarioContrasenia>();

            foreach (Dupla_UsuarioContrasenia unaDupla in this.duplas)
                if (unaDupla.Contrasenia == laContrasenia)
                    lasDuplasQueMePidieron.Add(unaDupla);

            return lasDuplasQueMePidieron;
        }

        public bool RevisarSiLaTarjetaEsMia(string numeroTarjeta)
        {
            foreach (Tarjeta unaTarjeta in this.tarjetas)
                if (unaTarjeta.Numero == numeroTarjeta)
                    return true;

            return false;
        }

        public Tarjeta ObtenerTarjetaDeNumero(string numeroTarjeta)
        {
            Tarjeta laTarjetaQueMePidieron = null;

            foreach (Tarjeta unaTarjeta in this.tarjetas)
                if (unaTarjeta.Numero == numeroTarjeta)
                    laTarjetaQueMePidieron = unaTarjeta;

            if (laTarjetaQueMePidieron == null)
                throw new Exepcion_IntentoDeObtencionDeObjetoInexistente("Se intento obtener una " +
                                        "tarjeta que no le pertenecia al Usuario");

            return laTarjetaQueMePidieron;
        }

        public bool VerificarQueTengoCombinacionNombreSitio(string nombreDupla, string sitioDupla)
        {
            foreach (Dupla_UsuarioContrasenia dupla in duplas)
                if (nombreDupla == dupla.NombreUsuario && sitioDupla == dupla.NombreSitioApp)
                    return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            Usuario usuarioAComparar = (Usuario)obj;
            return (Nombre.Equals(usuarioAComparar.Nombre)) ? true : false;
        }

        public override string ToString()
        {
            return (this.Nombre);
        }

        public Categoria DevolverCategoria(string nombreCategoria)
        {
            foreach (Categoria cat in categorias)
                if (cat.Nombre == nombreCategoria)
                    return cat;
            return null;
        }

        public List<string> ListarToStringDeMisTarjetas()
        {
            List<string> tarjetasString = new List<string>();
            for (int i = 0; i < this.ObtenerTarjetas().Count; i++)
                tarjetasString.Add(this.ObtenerTarjetas()[i].ToString());

            return tarjetasString;
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



