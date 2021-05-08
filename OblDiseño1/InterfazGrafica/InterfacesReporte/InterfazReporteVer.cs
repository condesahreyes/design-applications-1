using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OblDiseño1;
using Menu = InterfazGrafica.InterfacesMenu.Menu;
using InterfazGrafica.InterfacesReporte;
using Interfaz_ModificarContrasenia = InterfazGrafica.InterfacesDeContrasenias.Interfaz_ModificarContrasenia;
using System.ComponentModel;


namespace InterfazGrafica.InterfacesReporte
{
    public partial class InterfazReporteVer : Form
    {
        Usuario usuario;
        Sistema sistema;
        reporte reporte;
        int nivelDeSeguridad;
        public InterfazReporteVer(ref Usuario usuario, ref Sistema sistema, reporte reporte, int nivelDeSeguridad)
        {
            this.usuario = usuario;
            this.sistema = sistema;
            this.reporte = reporte;
            this.nivelDeSeguridad = nivelDeSeguridad;
            InitializeComponent();
            ActualizarLabel(nivelDeSeguridad);
            ActualizarDatosALaTabla();
        }

        private void ActualizarDatosALaTabla()
        {
            /*BindingListView<Customer> view = new BindingListView<Customer>(customers);
            dataGridView1.DataSource = view;*/


            this.dataGridView_Contrasenias.Columns.Clear();
            this.dataGridView_Contrasenias.DataSource = null;

            /*  BindingListView<Dupla_UsuarioContrasenia> view = new BindingListView<Dupla_UsuarioContrasenia>(reporte.duplasPorSeguridad[nivelDeSeguridad].unaListaDuplas);
   */
            List<string> unaLista = new List<string>();
            unaLista.Sort();

            reporte.duplasPorSeguridad[nivelDeSeguridad].unaListaDuplas.Sort();
            BindingSource biso = new BindingSource();
            biso.DataSource = reporte.duplasPorSeguridad[nivelDeSeguridad].unaListaDuplas;

            this.dataGridView_Contrasenias.DataSource = biso;

            this.dataGridView_Contrasenias.Columns["TipoSitioOApp"].Visible = false;
            this.dataGridView_Contrasenias.Columns["NivelSeguridadContrasenia"].Visible = false;
            this.dataGridView_Contrasenias.Columns["DataBrench"].Visible = false;
            this.dataGridView_Contrasenias.Columns["Nota"].Visible = false;

            this.dataGridView_Contrasenias.Columns["NombreUsuario"].HeaderText = "Usuario";
            this.dataGridView_Contrasenias.Columns["Contrasenia"].HeaderText = "Contraseña";
            this.dataGridView_Contrasenias.Columns["NombreSitioApp"].HeaderText = "Sitio";
            this.dataGridView_Contrasenias.Columns["FechaUltimaModificacion"].HeaderText = "Ultima Modificacion";
            this.dataGridView_Contrasenias.Columns["Categoria"].HeaderText = "Categoria";

            this.dataGridView_Contrasenias.Columns["NombreUsuario"].ReadOnly = true;
            this.dataGridView_Contrasenias.Columns["Contrasenia"].ReadOnly = true;
            this.dataGridView_Contrasenias.Columns["NombreSitioApp"].ReadOnly = true;
            this.dataGridView_Contrasenias.Columns["FechaUltimaModificacion"].ReadOnly = true;
            this.dataGridView_Contrasenias.Columns["Categoria"].ReadOnly = true;

            this.dataGridView_Contrasenias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            //this.dataGridView_Contrasenias.Sort("Categoria", ListSortDirection.Descending);
            //this.dataGridView_Contrasenias.Columns["Categoria"].SortMode = DataGridViewColumnSortMode.Automatic;

            //this.dataGridView_Contrasenias.Sort(dataGridView_Contrasenias.Columns["Categoria"] , System.ComponentModel.ListSortDirection.Descending);
        }


        private void ActualizarLabel(int nivelSeguridad) 
        {
            switch (nivelDeSeguridad)
            {
                case 1:
                    this.label_Titulo.Text = "Contraseñas nivel Rojo";
                    break;
                case 2:
                    this.label_Titulo.Text = "Contraseñas nivel Naranja";
                    break;
                case 3:
                    this.label_Titulo.Text = "Contraseñas nivel Amarillo";
                    break;
                case 4:
                    this.label_Titulo.Text = "Contraseñas nivel Verde Claro";
                    break;
                case 5:
                    this.label_Titulo.Text = "Contraseñas nivel Verde Oscuro";
                    break;
                default:
                    throw new Exepcion_NivelDeSeguridadNoValido("La ventana IntrvazReporteVer recibio como parametro un nivel de seguridad no valido");
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void InterfazReporteVer_Load(object sender, EventArgs e)
        {

        }

        private void panel_ListaDeContrasenias_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_Volver_Click(object sender, EventArgs e)
        {
            InterfazReporte interReporte = new InterfazReporte(ref usuario, ref sistema);
            interReporte.Show();
            this.Close();
        }

        private void dataGridView_Contrasenias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_Titulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (0 < dataGridView_Contrasenias.RowCount)
            {
                Dupla_UsuarioContrasenia duplaSeleccionada = (Dupla_UsuarioContrasenia)dataGridView_Contrasenias.CurrentRow.DataBoundItem;
                Interfaz_ModificarContrasenia modContra = new Interfaz_ModificarContrasenia(ref usuario, ref sistema, duplaSeleccionada, "InterfazReporteVer");
                modContra.Show();
                this.Close();
            }
        }
    }
}
