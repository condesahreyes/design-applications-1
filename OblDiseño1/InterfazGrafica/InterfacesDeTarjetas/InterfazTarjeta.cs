using OblDiseño1;
using System;
using System.Windows.Forms;
using Menu = InterfazGrafica.InterfacesMenu.Menu;

namespace InterfazGrafica.InterfacesDeTarjetas
{
    public partial class InterfazTarjeta : Form
    {
        private Usuario usuario;
        private Sistema sistema;

        public InterfazTarjeta(ref Usuario usuario, ref Sistema sistema)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.sistema = sistema;
        }

        private void InterfazTarjeta_Load(object sender, EventArgs e)
        {

        }

        private void btnTarjetasVolverMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu(ref sistema, ref usuario);
            menu.Show();
        }

        private void btnAgregarTarjeta_Click(object sender, EventArgs e)
        {

        }
    }
}
