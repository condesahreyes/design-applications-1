using Menu = InterfazGrafica.InterfacesMenu.Menu;
using InterfazGrafica.InterfazDataBreaches;
using OblDiseño1.ControladoresPorEntidad;
using System.Collections.Generic;
using AccesoDatos.Repositorios;
using System.Windows.Forms;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfacesDataBreaches
{
    public partial class InterfazHistoricosDataBreach : Form
    {
        private IRepositorio<ChequeadorDeDataBreaches> repositorioDataBreach;
        private ControladorDataBreach controladorDataBreach;

        private Usuario usuario;

        public InterfazHistoricosDataBreach(ref Usuario usuario)
        {
            InitializeComponent();

            this.usuario = usuario;

            this.repositorioDataBreach = new DataBrechRepositorio(usuario);
            this.controladorDataBreach = new ControladorDataBreach(this.usuario, repositorioDataBreach);
            

            CargarDataGrid();
            ModificarNombreDeColumnasDelDataGrid();
        }

        private void CargarDataGrid()
        {
            List<ChequeadorDeDataBreaches> misDataBreaches = controladorDataBreach.ObtenerTodosMisDataBreaches();

            dataGridHistorico.DataSource = misDataBreaches;
            dataGridHistorico.Columns["usuario"].Visible = false;
        }

        private void ModificarNombreDeColumnasDelDataGrid()
        {
            dataGridHistorico.Columns["id"].HeaderText = "Número Historico";
            dataGridHistorico.Columns["Fecha"].HeaderText = "Fecha de vulnerado";
        }

        private void btnHistoricoVer_Click(object sender, EventArgs e)
        {
            if (dataGridHistorico.RowCount > 0)
                AVisualizarHistorico();
            else
                MessageBox.Show("Error, aún no hay historicos");
        }

        private void AVisualizarHistorico()
        {
            ChequeadorDeDataBreaches miDataBreach = (ChequeadorDeDataBreaches)
                dataGridHistorico.CurrentRow.DataBoundItem;

            InterfazVerRegistroDataBreach verRegistro = new InterfazVerRegistroDataBreach
                (ref this.usuario, ref miDataBreach);

            this.Close();
            verRegistro.Show();
        }

        private void btnContraseniaVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu(ref usuario);
            menu.Show();
        }

        private void btnChequeo_Click(object sender, EventArgs e)
        {
            this.Close();
            InterfazChequeoDataBreaches dataBreaches = new 
                InterfazChequeoDataBreaches(ref usuario);
            dataBreaches.Show();
        }
    }
}