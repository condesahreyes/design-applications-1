using OblDiseño1;
using System;
using System.Collections.Generic;
using System.Linq;
using Menu = InterfazGrafica.InterfacesMenu.Menu;
using System.Windows.Forms;
using InterfazGrafica.InterfacesDeContrasenias;

namespace InterfazGrafica.InterfazDataBreaches
{
    public partial class InterfazChequeoDataBreaches : Form
    {
        private Sistema sistema;
        private Usuario usuario;
        public InterfazChequeoDataBreaches(ref Sistema sistema, ref Usuario usuario)
        {
            InitializeComponent();
            this.sistema = sistema;
            this.usuario = usuario;
        }

        private void CargarDataGridDuplas(List<Dupla_UsuarioContrasenia> duplasVulneradas)
        {
                BindingSource biso = new BindingSource();

                duplasVulneradas.Sort();

                biso.DataSource = duplasVulneradas;

                this.dataGridContrasenias.DataSource = biso;
                this.dataGridContrasenias.Columns["TipoSitioOApp"].Visible = false;
                this.dataGridContrasenias.Columns["NivelSeguridadContrasenia"].Visible = false;
                this.dataGridContrasenias.Columns["Contrasenia"].Visible = false;
                this.dataGridContrasenias.Columns["FechaUltimaModificacion"].Visible = false;
                this.dataGridContrasenias.Columns["DataBrench"].Visible = false;
                this.dataGridContrasenias.Columns["Nota"].Visible = false;
        }

        private void CargarDataGridTarjetas(List<Tarjeta> tarjetasVulneradas)
        {
                BindingSource biso = new BindingSource();

                tarjetasVulneradas.Sort();
                biso.DataSource = tarjetasVulneradas;

                dataGridTarjetas.DataSource = tarjetasVulneradas;
                dataGridTarjetas.Columns["NotaOpcional"].Visible = false;
                dataGridTarjetas.Columns["CodigoSeguridad"].Visible = false;
                dataGridTarjetas.Columns["fechaVencimiento"].Visible = false;
                dataGridTarjetas.Columns["categoria"].Visible = false;
        }

        private void btnChequear_Click(object sender, EventArgs e)
        {
            string datos = TextBoxDatosDataBreaches.Text;

            List<string> listaDatos = datos.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<object>[] datosVulnerados = sistema.ObtenerDataBreaches(ref usuario, listaDatos);

            List<Dupla_UsuarioContrasenia> duplasVulnderadas = datosVulnerados[1].Cast<Dupla_UsuarioContrasenia>().ToList();
            List<Tarjeta> tarjetasVulneradas = datosVulnerados[0].Cast<Tarjeta>().ToList();

            CargarDataGridTarjetas(tarjetasVulneradas);
            CargarDataGridDuplas(duplasVulnderadas);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (0 < dataGridContrasenias.RowCount)
            {
                Dupla_UsuarioContrasenia duplaSeleccionada = (Dupla_UsuarioContrasenia)dataGridContrasenias.CurrentRow.DataBoundItem;
                Interfaz_ModificarContrasenia modContra = new 
                    Interfaz_ModificarContrasenia(ref usuario, ref sistema, duplaSeleccionada, "InterfazChequeoDataBreaches");
                
                modContra.Show();
                this.Close();
            }
        }

        private void btnContraseniaVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu(ref sistema, ref usuario);
            menu.Show();
        }

        private void TextBoxDatosDataBreaches_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
