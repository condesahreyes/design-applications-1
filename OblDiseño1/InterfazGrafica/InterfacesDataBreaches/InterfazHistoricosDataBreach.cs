
using Menu = InterfazGrafica.InterfacesMenu.Menu;
using AccesoDatos.Repositorios;
using OblDiseño1;
using OblDiseño1.ControladoresPorFuncionalidad;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using InterfazGrafica.InterfazDataBreaches;

namespace InterfazGrafica.InterfacesDataBreaches
{
    public partial class InterfazHistoricosDataBreach : Form
    {
        private ControladorObtener controladorObtener;
        private IRepositorio<ChequeadorDeDataBreaches> repositorioDataBreach;
        private Usuario usuario;
        private Sistema sistema;
        public InterfazHistoricosDataBreach(ref Usuario usuario, ref Sistema sistema)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.sistema = sistema;
            this.controladorObtener = new ControladorObtener();
            this.repositorioDataBreach = new DataBrechRepositorio(usuario);
            CargarDataGrid();
            ModificarNombreDeColumnasDelDataGrid();
        }

        private void CargarDataGrid()
        {
            List<ChequeadorDeDataBreaches> misDataBreaches = controladorObtener.ObtenerDataBreaches(repositorioDataBreach);

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
            //InterfazChequeoDataBreaches dataBreaches = new InterfazChequeoDataBreaches(ref sistema, ref usuario);
            //dataBreaches.Show();
        }

        private void btnContraseniaVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu(ref sistema, ref usuario);
            menu.Show();
        }

        private void btnChequeo_Click(object sender, EventArgs e)
        {
            this.Close();
            InterfazChequeoDataBreaches dataBreaches = new InterfazChequeoDataBreaches(ref sistema, ref usuario);
            dataBreaches.Show();
        }
    }
}
