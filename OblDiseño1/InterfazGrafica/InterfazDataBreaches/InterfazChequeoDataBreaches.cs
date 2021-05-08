using OblDiseño1;
using System;
using System.Collections.Generic;
using System.Linq;
using Menu = InterfazGrafica.InterfacesMenu.Menu;
using System.Windows.Forms;

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

        private void lblListadoTarjetas_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu(ref sistema, ref usuario);
            menu.Show();
        }

        private void btnChequear_Click(object sender, EventArgs e)
        {
            string datos = TextBoxDatosDataBreaches.Text;
            List<string> listaDatos = datos.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<object>[] datosVulnerados = sistema.ObtenerDataBreaches(ref usuario, listaDatos);


            dataGridTarjetas.DataSource = datosVulnerados[0];
            dataGridContrasenias.DataSource = datosVulnerados[1];
        }
    }
}
