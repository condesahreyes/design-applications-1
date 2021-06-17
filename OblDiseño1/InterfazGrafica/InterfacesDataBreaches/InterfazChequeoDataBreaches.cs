using InterfazGrafica.InterfacesDeContrasenias;
using InterfazGrafica.InterfacesDataBreaches;
using OblDiseño1.ControladoresPorEntidad;
using System.Collections.Generic;
using OblDiseño1.Exception;
using System.Windows.Forms;
using System.Linq;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfazDataBreaches
{
    public partial class InterfazChequeoDataBreaches : Form
    {
        private Usuario usuario;
        private ControladorDataBreach controladorDataBreach;
        private ControladorUsuario usuarioControlador;

        public InterfazChequeoDataBreaches(ref Usuario usuario)
        {
            InitializeComponent();

            this.usuarioControlador = new ControladorUsuario();
            this.usuario = usuarioControlador.ObtenerUnUsuario(usuario);
            this.controladorDataBreach = new ControladorDataBreach(this.usuario);
        }

        private void btnChequear_Click(object sender, EventArgs e)
        {
            string datos = TextBoxDatosDataBreaches.Text;

            List<string> listaDatos = datos.Split(new[] { "\n" }, 
                    StringSplitOptions.RemoveEmptyEntries).ToList();

            CrearChequeadorYMostrarDatosVulnerados(listaDatos);
        }

        private void CrearChequeadorYMostrarDatosVulnerados(List<string> listaDatos)
        {
            ChequeadorDeDataBreaches chequeador = new ChequeadorDeDataBreaches(this.usuario);

            this.controladorDataBreach.AgregarRegistroDataBreach(listaDatos);

            List<Tarjeta> tarjetasVulneradas = controladorDataBreach.ObtenerTarjetasVulneradas();
            List<Credencial> credencialesVulnderadas = controladorDataBreach.ObenerCredencialesVulneradas();

            CargarDataGridTarjetas(tarjetasVulneradas);
            CargarDataGridCredenciales(credencialesVulnderadas);
        }

        private void btnModificarDupla_Click(object sender, EventArgs e)
        {
            if (0 < dataGridContrasenias.RowCount)
            {
                Credencial credencialSeleccionada = (Credencial)dataGridContrasenias.CurrentRow.DataBoundItem;

                InterfazDeModificarContrasenia interfazModificarContrasenia = new 
                    InterfazDeModificarContrasenia(ref usuario, credencialSeleccionada, 
                    "InterfazChequeoDataBreaches");

                interfazModificarContrasenia.Show();
                this.Close();
            }
        }

        private void btnContraseniaVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            InterfazHistoricosDataBreach dataBreach = new 
                InterfazHistoricosDataBreach(ref usuario);
            dataBreach.Show();
        }

        private void button_ImportarDesdeArchivo_Click(object sender, EventArgs e)
        {
            string rutaVacia = "";

            InterfazImportarDatosDesdeArchivoTxt interfazImportarDesdeArchivo = new 
                InterfazImportarDatosDesdeArchivoTxt();
            interfazImportarDesdeArchivo.ShowDialog();

            string rutaSeleccionada = interfazImportarDesdeArchivo.ObteneRutaSeleccionada();

            if (!rutaSeleccionada.Equals(rutaVacia))
            {
                try
                {
                    CargarDataGridsConDatosImportadosDeArchivo(rutaSeleccionada);
                }
                catch (ExcepcionFormatoArchivoInvalido)
                {
                    MessageBox.Show("ERROR: tipo de archivo no soportado (Actualmente se soportan solamente archivos .txt)");
                }
            }
        }

       
        private void CargarDataGridsConDatosImportadosDeArchivo(string rutaSeleccionada)
        {
            MessageBox.Show("Se importon los datos de: \n\n" + rutaSeleccionada);

            List<Credencial> credencialesVulnderadas = controladorDataBreach.
                ObtenerDataBreachesCredencialesMedianteRuta(ref usuario, rutaSeleccionada);
            List<Tarjeta> tarjetasVulneradas = controladorDataBreach.
                ObtenerDataBreachesTarjetassMedianteRuta(ref usuario, rutaSeleccionada);

            CargarDataGridTarjetas(tarjetasVulneradas);
            CargarDataGridCredenciales(credencialesVulnderadas);
            MessageBox.Show("Se importon los datos de: \n\n" + rutaSeleccionada);
        }

        
        private void CargarDataGridCredenciales(List<Credencial> credencialesVulneradas)
        {
            BindingSource biso = new BindingSource();

            this.dataGridContrasenias.AllowUserToAddRows = false;

            credencialesVulneradas.Sort();
            biso.DataSource = credencialesVulneradas;
            this.dataGridContrasenias.DataSource = biso;

            CambiarColumnasVisiblesDelDataGridCredenciales();
            ModificarHeaderTextCredencial();
        }

        private void CambiarColumnasVisiblesDelDataGridCredenciales()
        {
            this.dataGridContrasenias.Columns["FechaUltimaModificacion"].Visible = false;
            this.dataGridContrasenias.Columns["ObtenerNivelSeguridad"].Visible = false;
            this.dataGridContrasenias.Columns["ObtenerContraseña"].Visible = false;
            this.dataGridContrasenias.Columns["TipoSitioOApp"].Visible = false;
            this.dataGridContrasenias.Columns["Contraseña"].Visible = false;
            this.dataGridContrasenias.Columns["DataBrench"].Visible = false;
            this.dataGridContrasenias.Columns["Nota"].Visible = false;
        }

        private void ModificarHeaderTextCredencial()
        {
            this.dataGridContrasenias.Columns["NombreUsuario"].HeaderText = "Usuario";
            this.dataGridContrasenias.Columns["NombreSitioApp"].HeaderText = "Sitio";
            this.dataGridContrasenias.Columns["Categoria"].HeaderText = "Categoría";
        }

        private void CargarDataGridTarjetas(List<Tarjeta> tarjetasVulneradas)
        {
            BindingSource biso = new BindingSource();

            this.dataGridTarjetas.AllowUserToAddRows = false;

            tarjetasVulneradas.Sort();
            biso.DataSource = tarjetasVulneradas;
            this.dataGridTarjetas.DataSource = tarjetasVulneradas;

            CambiarColumnasVisiblesDelDataGridTarjetas();
            ModificarHeaderTextTarjeta();
        }

        private void CambiarColumnasVisiblesDelDataGridTarjetas()
        {
            dataGridTarjetas.Columns["NotaOpcional"].Visible = false;
            dataGridTarjetas.Columns["CodigoSeguridad"].Visible = false;
            dataGridTarjetas.Columns["fechaVencimiento"].Visible = false;
            dataGridTarjetas.Columns["categoria"].Visible = false;
        }

        private void ModificarHeaderTextTarjeta()
        {
            this.dataGridTarjetas.Columns["Numero"].HeaderText = "Número";
        }
    }
}
