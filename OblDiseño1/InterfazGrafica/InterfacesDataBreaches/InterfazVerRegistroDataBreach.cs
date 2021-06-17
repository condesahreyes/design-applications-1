using InterfazGrafica.InterfacesDeContrasenias;
using OblDiseño1.ControladoresPorEntidad;
using System.Collections.Generic;
using System.Windows.Forms;
using AccesoDatos;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfacesDataBreaches
{
    public partial class InterfazVerRegistroDataBreach : Form
    {
        private Usuario usuario;
        private ChequeadorDeDataBreaches dataBreach;

        public InterfazVerRegistroDataBreach(ref Usuario usuario, 
            ref ChequeadorDeDataBreaches dataBreach)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.dataBreach = dataBreach;
            CargarListaTarjetas();
            CargarCredenciales();
        }

        private void CargarListaTarjetas()
        {
            List<Tarjeta> misTarjetas = dataBreach.TarjetasVulneradas;
            if (misTarjetas.Count > 0)
                misTarjetas.Sort();
            dataGridHistoricoTarjeta.DataSource = misTarjetas;
            dataGridHistoricoTarjeta.Columns["Categoria"].DisplayIndex = 0;
            dataGridHistoricoTarjeta.Columns["NotaOpcional"].Visible = false;
            dataGridHistoricoTarjeta.Columns["CodigoSeguridad"].Visible = false;

            ModificarNombreDeColumnasDelDataGrid();
        }

        private void ModificarNombreDeColumnasDelDataGrid()
        {
            dataGridHistoricoTarjeta.Columns["FechaVencimiento"].HeaderText = "Fecha Vencimiento";
            dataGridHistoricoTarjeta.Columns["Numero"].HeaderText = "Número";
            dataGridHistoricoTarjeta.Columns["Categoria"].HeaderText = "Categoría";
        }

        private void CargarCredenciales()
        {
            this.dataGridCredenciales.AllowUserToAddRows = false;
            BindingSource biso = new BindingSource();
            biso.DataSource = dataBreach.CredencialesVulneradas;

            this.dataGridCredenciales.DataSource = biso;

            ModificarACamposNoVisibles();
            ModificarHeaderText();

            this.dataGridCredenciales.RowHeadersVisible = false;
            this.dataGridCredenciales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ModificarACamposNoVisibles()
        {
            this.dataGridCredenciales.Columns["ObtenerNivelSeguridad"].Visible = false;
            this.dataGridCredenciales.Columns["ObtenerContraseña"].Visible = false;
            this.dataGridCredenciales.Columns["TipoSitioOApp"].Visible = false;
            this.dataGridCredenciales.Columns["DataBrench"].Visible = false;
            this.dataGridCredenciales.Columns["Contraseña"].Visible = false;
            this.dataGridCredenciales.Columns["Nota"].Visible = false;
        }

        private void ModificarHeaderText()
        {
            this.dataGridCredenciales.Columns["NombreUsuario"].HeaderText = "Usuario";
            this.dataGridCredenciales.Columns["NombreSitioApp"].HeaderText = "Sitio";
            this.dataGridCredenciales.Columns["FechaUltimaModificacion"].HeaderText = "Ultima Modificación";
            this.dataGridCredenciales.Columns["Categoria"].HeaderText = "Categoría";
        }

        private void btnVolverHistorico_Click(object sender, EventArgs e)
        {
            this.Close();
            InterfazHistoricosDataBreach dataBreach = new 
                InterfazHistoricosDataBreach(ref usuario);
            dataBreach.Show();
        }

        private void btnModificarContraseña_Click(object sender, EventArgs e)
        {
            if (0 < dataGridCredenciales.RowCount)
                ModificarCredencial();
            else
                MessageBox.Show("No hay contraseñas para modificar");
        }

        private void ModificarCredencial()
        {
            try
            {
                Credencial credencialSeleccionada = (Credencial)dataGridCredenciales.CurrentRow.DataBoundItem;

                IRepositorio<Credencial> repoCredencial = new CredencialRepositorio(this.usuario);
                ControladorCredencial controladorCredencial = new ControladorCredencial(this.usuario, repoCredencial);

                Credencial credencial = controladorCredencial.ObtenerCredencial(credencialSeleccionada);

                ModificarContraseña(credencial, credencialSeleccionada);
            }
            catch (ExepcionIntentoDeObtencionDeObjetoInexistente)
            {
                MessageBox.Show("Esta contraseña ya fue modificada");
            }
        }

        private void ModificarContraseña(Credencial credencial, Credencial credencialSeleccionada)
        {
            if (credencial == null || credencial.ObtenerContraseña != credencialSeleccionada.ObtenerContraseña)
                MessageBox.Show("Esta contraseña ya se modifico");
            else
            {
                string nombreDeEstaPantalla = "InterfazVerRegistroDataBreach";
                InterfazDeModificarContrasenia interfazModiicar = new
                InterfazDeModificarContrasenia(ref usuario, credencialSeleccionada,
                nombreDeEstaPantalla, this.dataBreach);
                this.Close();
                interfazModiicar.Show();
            }
        }
    }
}
