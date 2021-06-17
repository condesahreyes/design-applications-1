using InterfazGrafica.InterfacesDataBreaches;
using InterfazGrafica.InterfazDataBreaches;
using OblDiseño1.ControladoresPorEntidad;
using InterfazGrafica.InterfacesReporte;
using System.Collections.Generic;
using AccesoDatos.Repositorios;
using OblDiseño1.Entidades;
using System.Windows.Forms;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfacesDeContrasenias
{
    public partial class InterfazDeModificarContrasenia : Form
    {
        private ChequeadorDeDataBreaches miChequeador;
        private Credencial credencial;
        private Usuario usuario;

        private int nivelSeguridadContraseniaOriginal;
        private int nivelSeguridadContraseniaNuevo;

        private string interfazPadre;

        private const string posibleInterfazPadre_ReporteVer = "InterfazReporteVer";
        private const string posibleInterfazPadre_Contrasenia = "InterfazContrasenia";
        private const string posibleInterfazPadre_ChequeoDataBreaches = "InterfazChequeoDataBreaches";
        private const string posibleInterfazPadre_ChequeoDataBreachesHistorico = "InterfazVerRegistroDataBreach";

        private IRepositorio<Categoria> repositorioCategoria;
        private ControladorCategoria controladorCategoria;

        private IRepositorio<Credencial> credencialRepositorio;
        private ControladorCredencial controladorCredencial;


        public InterfazDeModificarContrasenia(ref Usuario usuario, Credencial credencial, string padre)
        {
            Inicializador(ref usuario, credencial, padre, null);
        }

        public InterfazDeModificarContrasenia(ref Usuario usuario,
            Credencial credencial, string padre, ChequeadorDeDataBreaches miChequeador)
        {
            Inicializador(ref usuario, credencial, padre, miChequeador);
        }

        private void Inicializador(ref Usuario usuario, Credencial credencial, 
            string padre, ChequeadorDeDataBreaches miChequeador)
        {
            if (miChequeador != null)
                this.miChequeador = miChequeador;

            this.usuario = usuario;
            this.credencial = credencial;
            this.nivelSeguridadContraseniaOriginal = this.credencial.ObtenerNivelSeguridad;
            this.nivelSeguridadContraseniaNuevo = this.nivelSeguridadContraseniaOriginal;
            this.interfazPadre = padre;

            CrearManejadoresCredencial();
            CrearManejadoresCategoria();

            InitializeComponent();
            ColocarDatosEnLosCampos();
        }

        private void CrearManejadoresCredencial()
        {
            controladorCredencial = new ControladorCredencial(this.usuario);
        }

        private void CrearManejadoresCategoria()
        {
            controladorCategoria = new ControladorCategoria(this.usuario);
        }

        private void ColocarDatosEnLosCampos()
        {
            this.textBox_Usuario.Text = credencial.NombreUsuario;

            this.textBox_Sitio.Text = credencial.NombreSitioApp;

            List<Categoria> categorias = controladorCategoria.ObtenerCategorias();

            Credencial credencialPorBD = controladorCredencial.ObtenerCredencial(credencial);

            this.textBox_Contrasenia.Text = credencialPorBD.ObtenerContraseña;

            var bindingSource = new BindingSource();
            bindingSource.DataSource = categorias;
            this.comboBox_Categoria.DataSource = bindingSource.DataSource;
            SeleccionarCategoriaOriginal();
            this.richTextBox_Nota.Text = credencial.Nota;
        }

        private void SeleccionarCategoriaOriginal()
        {
            int indiceCatOriginal = -1;
            for (int i = 0; i < comboBox_Categoria.Items.Count; i++)
            {
                if (this.credencial.Categoria.Nombre.Equals(comboBox_Categoria.Items[i].ToString()))
                {
                    indiceCatOriginal = i;
                    break;
                }
            }
            this.comboBox_Categoria.SelectedIndex = indiceCatOriginal;
        }

        private void button_RevertirUsuario_Click(object sender, EventArgs e)
        {
            this.textBox_Usuario.Text = credencial.NombreUsuario;
        }

        private void button_RevertirContrasenia_Click(object sender, EventArgs e)
        {
            this.textBox_Contrasenia.Text = credencial.Contraseña.Contrasenia;
        }

        private void button_RevertirSitio_Click(object sender, EventArgs e)
        {
            this.textBox_Sitio.Text = credencial.NombreSitioApp;
        }

        private void button_RevertirNota_Click(object sender, EventArgs e)
        {
            this.richTextBox_Nota.Text = credencial.Nota;
        }

        private void button__RevertirCategoria_Click(object sender, EventArgs e)
        {
            SeleccionarCategoriaOriginal();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            CerrarVentana();
        }

        private void button_Aceptar_Click(object sender, EventArgs e)
        {

            string nuevoNombreUsuario = this.textBox_Usuario.Text;
            string nuevoNombreSitio = this.textBox_Sitio.Text;

            if (VerificarQueTengoCombinacionNombreSitio(nuevoNombreUsuario, nuevoNombreSitio) &&
                 (nuevoNombreUsuario != this.credencial.NombreUsuario || nuevoNombreSitio != this.credencial.NombreSitioApp))
            {
                MessageBox.Show("Error: ese Nombre de Uusario ya esta registrado para ese Sitio en el sistema");
            }
            else
            {
                ModificarContrasenia();
                MessageBox.Show("La contraseña se modifico correctamente");
                CerrarVentana();
            }
        }

        public bool VerificarQueTengoCombinacionNombreSitio(string nuevoNombreUsuario, string nuevoNombreSitio)
        {
            List<Credencial> credenciales = controladorCredencial.ObtenerTodasMisCredenciales();
            foreach (var credencial in credenciales)
            {
                if (credencial.NombreUsuario == nuevoNombreUsuario && credencial.NombreSitioApp == nuevoNombreSitio)
                    return true;
            }
            return false;
        }

        private void CerrarVentana()
        {
            switch (this.interfazPadre)
            {
                case posibleInterfazPadre_ReporteVer:
                    Reporte funcionalidad = new Reporte(usuario);
                    reporte reporte = funcionalidad.ObtenerReporteSeguridadContrasenias();
                    ActualizarReporte(reporte);
                        
                    InterfazReporteVer interfazVer = new InterfazReporteVer(ref usuario, 
                        reporte, this.nivelSeguridadContraseniaOriginal);
                    interfazVer.Show();
                    this.Close();
                    break;
                case posibleInterfazPadre_Contrasenia:
                    InterfazContrasenia interfazContra = new InterfazContrasenia(ref usuario);
                    interfazContra.Show();
                    this.Close();
                    break;
                case posibleInterfazPadre_ChequeoDataBreaches:
                    InterfazChequeoDataBreaches interfazDataBreaches = new InterfazChequeoDataBreaches(ref usuario);
                    interfazDataBreaches.Show();
                    this.Close();
                    break;                
                case posibleInterfazPadre_ChequeoDataBreachesHistorico:
                    InterfazVerRegistroDataBreach interfazDataBreachesHistorico = new InterfazVerRegistroDataBreach(ref usuario, ref miChequeador);
                    interfazDataBreachesHistorico.Show();
                    this.Close();
                    break;
            }
        }

        public void ActualizarReporte(reporte reporte)
        {
            if (this.nivelSeguridadContraseniaOriginal != this.nivelSeguridadContraseniaNuevo)
            {
                reporte.duplasPorSeguridad[nivelSeguridadContraseniaNuevo].cantidad++;
                reporte.duplasPorSeguridad[nivelSeguridadContraseniaNuevo].unaListaCredenciales.Add(this.credencial);
                reporte.duplasPorSeguridad[nivelSeguridadContraseniaOriginal].cantidad--;
                reporte.duplasPorSeguridad[nivelSeguridadContraseniaOriginal].unaListaCredenciales.Remove(this.credencial);
            }
        }

        private bool ModificarContrasenia()
        {
            bool seModificoCorrectamente = false;
            try
            {
                ModificarCredencial();
            }
            catch (ExepcionDatosDeContraseniaInvalidos)
            {
                seModificoCorrectamente = false;
                MostrarCualesSonLosDatosCorrector();
            }
            return seModificoCorrectamente;
        }

        private void ModificarCredencial()
        {
            string nombreNuevaCredencial = textBox_Usuario.Text;
            string contraseñaNuevaCredencial = textBox_Contrasenia.Text;
            string sitioNuevaCredencial = textBox_Sitio.Text;
            string notaNuevaCredencial = richTextBox_Nota.Text;

            OblDiseño1.Entidades.Contraseña nuevaContraseña = new OblDiseño1.Entidades.Contraseña(contraseñaNuevaCredencial);
            Categoria categoriaNuevaCredencial = (Categoria)this.comboBox_Categoria.SelectedItem;

            Credencial credencialAModificar = new Credencial(nombreNuevaCredencial, nuevaContraseña, 
                sitioNuevaCredencial, notaNuevaCredencial, categoriaNuevaCredencial);

            controladorCredencial.ModificarMiCredencial(credencial, credencialAModificar);

            this.nivelSeguridadContraseniaNuevo = credencialAModificar.ObtenerNivelSeguridad;
        }

        private void MostrarCualesSonLosDatosCorrector()
        {
            MessageBox.Show("DATOS ERRONEOS. Por faver recuerde que la Contraseña " +
                "debe cumplir con el siguiente formato: " +
                "\n\n" +
                "> Nombre de Usuario: Mínimo 5 caracteres y máximo 25\n\n" +
                "> Contraseña: Mínimo 5 caracteres y máximo 25\n\n" +
                "> Sitio: Mínimo 3 caracteres y máximo 25\n\n" +
                "> Categoría: Se selecciona de las disponibles en el sistema"
                );
        }

        private void button_GenerarContrasenia_Click(object sender, EventArgs e)
        {
            string nuevaContra = this.textBox_Contrasenia.Text;
            InterfazGenerarContrasenia genContra = new InterfazGenerarContrasenia();
            genContra.ShowDialog();
            string posibleNuevaContra = genContra.ObtenerNuevaContrasenia();
            if (!posibleNuevaContra.Equals(""))
            {
                nuevaContra = genContra.ObtenerNuevaContrasenia();
            }
            this.textBox_Contrasenia.Text = nuevaContra;
        }

        private void btnSugerencias_Click(object sender, EventArgs e)
        {
            string posibleContraseña = textBox_Contrasenia.Text;

            string mensaje = "";

            mensaje = EsContraseñaSegura(posibleContraseña, mensaje);

            mensaje = EsContraseñaDuplicada(posibleContraseña, mensaje);

            mensaje = EsContraseñaVulnerada(posibleContraseña, mensaje);

            MessageBox.Show(mensaje);
        }

        private string EsContraseñaSegura(string posibleContraseña, string mensaje)
        {
            bool segura = controladorCredencial.ObtenerSiEsContraseniaSegura(posibleContraseña);

            if (segura)
                mensaje = mensaje + "Es una contraseña segura \n";
            else
                mensaje = mensaje + "No es una contraseña segura \n";

            return mensaje;
        }

        private string EsContraseñaDuplicada(string posibleContraseña, string mensaje)
        {
            bool duplicada = controladorCredencial.ObtenerSiEsContraseniaDuplicada(posibleContraseña, this.credencial);

            if (duplicada)
                mensaje = mensaje + "Es una contraseña duplicada \n";

            return mensaje;
        }

        private string EsContraseñaVulnerada(string posibleContraseña, string mensaje)
        {
            bool vulnerada = controladorCredencial.ObtenerSiEsContraseñaVulnerada(posibleContraseña);

            if (vulnerada)
                mensaje = mensaje + "Es una contraseña vulnerada \n";

            return mensaje;
        }
    }
}
