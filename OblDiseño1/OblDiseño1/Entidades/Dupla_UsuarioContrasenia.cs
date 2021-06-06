using System;
using System.Text;
using System.Collections;
using OblDiseño1.Entidades;

namespace OblDiseño1
{
    public class Dupla_UsuarioContrasenia : IComparable<Dupla_UsuarioContrasenia>
    {

        public string NombreUsuario { get => nombreUsuario; set => ActualizarNombreUsuario(value); }

        public string NombreSitioApp { get => nombreSitioApp; set => ActualizarNombreSitioApp(value); }

        public string TipoSitioOApp { get; set; }

        public string Nota { get => nota; set => ActualizarNota(value); }

        public Categoria Categoria { get; set; }

        public Contraseña Contraseña { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }

       
        public bool DataBrench { get; set; }

        private string contrasenia;
        private string nombreUsuario;

     
        private const int NOMBRE_LARGO_MIN = 5;
        private const int NOMBRE_LARGO_MAX = 25;
        private const int SITIO_LARGO_MIN = 3;
        private const int SITIO_LARGO_MAX = 25;
        private const int NOTA_LARGO_MAX = 250;
        private int nivelSeguridadContrasenia;
        private string nombreSitioApp;
        private string nota;
    

        

        public Dupla_UsuarioContrasenia(string unNombreUsuario, Contraseña unaContrasenia,
            string unSitio, string laNota, Categoria laCategoria)
        {
            NombreUsuario = unNombreUsuario;
            Contraseña = unaContrasenia;
            NombreSitioApp = unSitio;
            Nota = laNota;
            Categoria = laCategoria;
            FechaUltimaModificacion = DateTime.Today;
            DataBrench = false;
        }

        private void ActualizarUltimaFechaModificacion()
        {
            FechaUltimaModificacion = DateTime.Today;
        }

        public void ActualizarNota(string unaNota)
        {
            if (EsNotaMuylarga(unaNota.Length))
                throw new ExepcionDatosDeContraseniaInvalidos($"La nota debe contener " +
                    $"como maximo {NOTA_LARGO_MAX} caracteres");
            else
            {
                nota = unaNota;
                ActualizarUltimaFechaModificacion();
            }
        }

        private bool EsNotaMuylarga(int largoDeLaNota)
        {
            return (largoDeLaNota > NOTA_LARGO_MAX);
        }

        public void ActualizarNombreSitioApp(string unNombreSitioApp)
        {
            if (EsNombreSitioAppLargoValido(unNombreSitioApp.Length))
                throw new ExepcionDatosDeContraseniaInvalidos($"El nombre de usuario debe " +
                    $"contener entre {SITIO_LARGO_MIN} y {SITIO_LARGO_MAX} caracteres");
            else
            {
                nombreSitioApp = unNombreSitioApp;
                ActualizarUltimaFechaModificacion();
            }  
        }

        private bool EsNombreSitioAppLargoValido(int largoNombre)
        {
            return (largoNombre < SITIO_LARGO_MIN || largoNombre > SITIO_LARGO_MAX);
        }

        public void ActualizarNombreUsuario(string unNombreUsuario)
        {
            if (EsNombreUsuarioValido(unNombreUsuario.Length))
                throw new ExepcionDatosDeContraseniaInvalidos($"El nombre de usuario debe " +
                    $"contener entre {NOMBRE_LARGO_MIN} y {NOMBRE_LARGO_MAX} caracteres");
            else
            {
                nombreUsuario = unNombreUsuario;
                ActualizarUltimaFechaModificacion();
            }
        }

        private bool EsNombreUsuarioValido(int largoNombre)
        {
            return (largoNombre < NOMBRE_LARGO_MIN || largoNombre > NOMBRE_LARGO_MAX);
        }

        public override string ToString()
        {
            return ("Nombre: " + this.NombreUsuario + " " + this.Contraseña.ToString() +
                " Nombre sitio: " + this.NombreSitioApp + " Categoria: " + this.Categoria);
        }

        public int CompareTo(Dupla_UsuarioContrasenia otraDupla)
        {
            return this.Categoria.Nombre.CompareTo(otraDupla.Categoria.Nombre);
        }

        public override bool Equals(object obj)
        {
            Dupla_UsuarioContrasenia duplaAComparar = (Dupla_UsuarioContrasenia)obj;
            return ((this.NombreUsuario == duplaAComparar.NombreUsuario) && 
                (this.NombreSitioApp == duplaAComparar.NombreSitioApp));
        }
    }
}