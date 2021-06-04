using OblDiseño1.Entidades;
using OblDiseño1.Exception;
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

        public string Nombre { get => nombre; set => ActualizarNombreUsuario(value); }
        public string Contrasenia { get => contrasenia; set => ActualizarContrasenia(value); }

        public Usuario() { }

        public GestorContraseniasCompartidas GestorCompartirContrasenia { get; }

        public Usuario(string nombre, string contrasenia)
        {
            Nombre = nombre;
            Contrasenia = contrasenia;
            this.categorias = new List<Categoria>();
            this.tarjetas = new List<Tarjeta>();
            this.duplas = new List<Dupla_UsuarioContrasenia>();
            this.GestorCompartirContrasenia = new GestorContraseniasCompartidas(this);
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

        public void RemoverDupla(Dupla_UsuarioContrasenia duplaARemover)
        {
            if (this.duplas.Contains(duplaARemover) && !this.GestorCompartirContrasenia.VerificarQueEstoyCompartiendoLaContraseniaConAlguien(duplaARemover))
                this.duplas.Remove(duplaARemover);
            else
                throw new Exception_EliminacionDeContraseniaCompartida("No se puede eliminar una contraseña compartida");
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

        public void CompartirContrasenia(Dupla_UsuarioContrasenia duplaACompartir, Usuario conEste)
        {
            GestorCompartirContrasenia.funcionCompartir(duplaACompartir, conEste);
        }

        public void DejarDeCompartirContrasenia(Dupla_UsuarioContrasenia duplaADejarDeCompartir, Usuario conEste)
        {
            GestorCompartirContrasenia.DejarDeCompartirContrasenia(duplaADejarDeCompartir, conEste);
        }
    }
}