using OblDiseño1.ControladoresPorFuncionalidad;
using System.Collections.Generic;
using OblDiseño1.Entidades;
using OblDiseño1.Exception;
using System.Data;

namespace OblDiseño1
{
    public class Usuario
    {
        private const string mnsjNombreUsuarioError = "El nombre de usuario debe tener entre" +
                                                    " 1 y 25 caracteres";
        private const string mnsjContraseniaError = "La contraseña debe tener entre 5 y" +
                                                    " 25 caracteres";
        private const string mnsjDuplaYaPresenteError = "Se intento agregar una Dupla que ya" +
                                                    " pertenecia al Usuario";

        private string nombre;
        private string contrasenia;

        private const int LARGO_CONTRASENIA_MAX = 25;
        private const int LARGO_CONTRASENIA_MIN = 5;
        private const int LARGO_NOMBRE_MAX = 25;
        private const int LARGO_NOMBRE_MIN = 1;

        public List<Credencial> credenciales;
        public List<Categoria> categorias;
        public List<Tarjeta> tarjetas;

        public string Nombre { get => nombre; set => ActualizarNombreUsuario(value); }
        public string Contrasenia { get => contrasenia; set => ActualizarContrasenia(value); }

        public Usuario() 
        {
            this.categorias = new List<Categoria>();
            this.tarjetas = new List<Tarjeta>();
            this.credenciales = new List<Credencial>();
            this.GestorCompartirContrasenia = new GestorContraseniasCompartidas(this);
        }

        public GestorContraseniasCompartidas GestorCompartirContrasenia { get; }

        public Usuario(string nombre, string contrasenia)
        {
            Nombre = nombre;
            Contrasenia = contrasenia;
            this.categorias = new List<Categoria>();
            this.tarjetas = new List<Tarjeta>();
            this.credenciales = new List<Credencial>();
            this.GestorCompartirContrasenia = new GestorContraseniasCompartidas(this);
        }

        public List<Tarjeta> ObtenerTarjetas()
        {
            return this.tarjetas;
        }

        public List<Credencial> ObtenerCredenciales()
        {
            return this.credenciales;
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
                throw new ExepcionInvalidUsuarioData(mnsjNombreUsuarioError);
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
                throw new ExepcionInvalidUsuarioData(mnsjContraseniaError);
            else
                this.contrasenia = unaContrasenia;
        }

        public void AgregarTarjeta(Tarjeta tarjeta)
        {
            if (this.ObtenerTarjetas().Contains(tarjeta))
                throw new ExepcionObjetosRepetidos("Ya existe una tarjeta con el mismo numero");
            else
            {
                this.tarjetas.Add(tarjeta);
            }
        }

        public void EliminarTarjeta(Tarjeta tarjeta)
        {
            this.tarjetas.Remove(tarjeta);
        }

        public void AgregarCredencial(Credencial credencial)
        {
            if (this.credenciales.Contains(credencial))
                throw new ExepcionInvalidUsuarioData(mnsjDuplaYaPresenteError);
            else
                this.credenciales.Add(credencial);
        }

        public void EliminarCredencial(Credencial credencial)
        {
            this.credenciales.Remove(credencial);
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

            for (int i = 0; i < this.ObtenerCredenciales().Count; i++)
                duplasString.Add(this.ObtenerCredenciales()[i].ToString());

            return duplasString;
        }

        public void RemoverDupla(Credencial credencialARemover)
        {
            if (this.credenciales.Contains(credencialARemover) && !this.GestorCompartirContrasenia.
                VerificarQueEstoyCompartiendoLaContraseniaConAlguien(credencialARemover))
                this.credenciales.Remove(credencialARemover);
            else
                throw new ExepcionEliminacionDeContraseniaCompartida("No se puede eliminar una " +
                    "contraseña compartida");
        }

        public bool RevisarSiLaContraseniaEsMia(string unaContrasenia)
        {
            if(this.credenciales!=null)
            foreach (Credencial unaDupla in this.credenciales)
                if (unaDupla.Contraseña.Contrasenia == unaContrasenia)
                    return true;

            return false;
        }

        public List<Credencial> ObtenerDuplasConLaContrasenia(string laContrasenia)
        {
            List<Credencial> lasDuplasQueMePidieron = new List<Credencial>();

            foreach (Credencial unaDupla in this.credenciales)
                if (unaDupla.Contraseña.Contrasenia == laContrasenia)
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
                throw new ExepcionIntentoDeObtencionDeObjetoInexistente("Se intento obtener una " +
                                        "tarjeta que no le pertenecia al Usuario");

            return laTarjetaQueMePidieron;
        }

        public bool VerificarQueTengoCombinacionNombreSitio(string nombreCredencial, string sitioDupla)
        {
            foreach (Credencial credencial in credenciales)
                if (nombreCredencial == credencial.NombreUsuario && sitioDupla == credencial.NombreSitioApp)
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

     
        public List<string> ListarToStringDeMisTarjetas()
        {
            List<string> tarjetasString = new List<string>();
            for (int i = 0; i < this.ObtenerTarjetas().Count; i++)
                tarjetasString.Add(this.ObtenerTarjetas()[i].ToString());

            return tarjetasString;
        }

    }
}