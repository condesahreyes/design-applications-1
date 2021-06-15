﻿using Menu = InterfazGrafica.InterfacesMenu.Menu;
using InterfazGrafica.InterfacesDeContrasenias;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using AccesoDatos;
using OblDiseño1;
using System;
using InterfazGrafica.InterfacesDataBreaches;

namespace InterfazGrafica.InterfazDataBreaches
{
    public partial class InterfazChequeoDataBreaches : Form
    {
        private Sistema sistema;
        private Usuario usuario;

        private IRepositorio<Tarjeta> tarjetaRepositorio;
        private IRepositorio<Credencial> credencialRepositorio;

        public InterfazChequeoDataBreaches(ref Sistema sistema, ref Usuario usuario)
        {
            InitializeComponent();
            this.sistema = sistema;
            this.usuario = usuario;

            this.tarjetaRepositorio = new TarjetaRepositorio(this.usuario);
            this.credencialRepositorio = new CredencialRepositorio(this.usuario);
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

        private void btnChequear_Click(object sender, EventArgs e)
        {
            string datos = TextBoxDatosDataBreaches.Text;

            List<string> listaDatos = datos.Split(new[] { "\n" }, 
                    StringSplitOptions.RemoveEmptyEntries).ToList();


            ChequeadorDeDataBreaches chequeador = new ChequeadorDeDataBreaches(this.usuario, tarjetaRepositorio, credencialRepositorio);
            
            List<Credencial> credencialesVulnderadas = chequeador.ObtenerCredencialesVulneradas(listaDatos);
            List<Tarjeta> tarjetasVulneradas = chequeador.ObtenerTarjetasVulneradas(listaDatos);

            CargarDataGridTarjetas(tarjetasVulneradas);
            CargarDataGridCredenciales(credencialesVulnderadas);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (0 < dataGridContrasenias.RowCount)
            {
                Credencial credencialSeleccionada = (Credencial)dataGridContrasenias.CurrentRow.DataBoundItem;
                InterfazDeModificarContrasenia interfazModificarContrasenia = new 
                    InterfazDeModificarContrasenia(ref usuario, ref sistema, credencialSeleccionada, 
                    "InterfazChequeoDataBreaches");

                interfazModificarContrasenia.Show();
                this.Close();
            }
        }

        private void btnContraseniaVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu(ref sistema, ref usuario);
            menu.Show();
        }

        private void button_ImportarDesdeArchivo_Click(object sender, EventArgs e)
        {
            string rutaVacia = "";

            InterfazImportarDatosDesdeArchivoTxt interfazImportarDesdeArchivo = new InterfazImportarDatosDesdeArchivoTxt(ref sistema);
            interfazImportarDesdeArchivo.ShowDialog();

            string rutaSeleccionada = interfazImportarDesdeArchivo.ObteneRutaSeleccionada();

            if (!rutaSeleccionada.Equals(rutaVacia))
            {
                MessageBox.Show("Se importon los datos de: \n\n" + rutaSeleccionada);

                List<Credencial> credencialesVulnderadas = sistema.
                    ObtenerDataBreachesCredencialesMedianteRuta(ref usuario, rutaSeleccionada);
                List<Tarjeta> tarjetasVulneradas = sistema.
                    ObtenerDataBreachesTarjetassMedianteRuta(ref usuario, rutaSeleccionada);

                CargarDataGridTarjetas(tarjetasVulneradas);
                CargarDataGridCredenciales(credencialesVulnderadas);
            }
        }
    }
}
