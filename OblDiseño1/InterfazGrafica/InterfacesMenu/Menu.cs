using OblDiseño1;
using System;
using System.Windows.Forms;
using InterfazGrafica.InterfazCategoria;
using InterfazGrafica.InterfacesDeTarjetas;
using InterfazGrafica.InterfacesDeContrasenias;

namespace InterfazGrafica.InterfacesMenu
{
    public partial class Menu : Form
    {
        Sistema sistema;
        Usuario usuario;

        public Menu(ref Sistema sistema, ref Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.sistema = sistema;
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            this.Hide();
            InterfazCategorias categoria = new InterfazCategorias(ref this.usuario, ref this.sistema);
            categoria.Show();
        }

        private void btnContrasenias_Click(object sender, EventArgs e)
        {
            this.Hide();
            InterfazContrasenia contrasenias = new InterfazContrasenia(ref usuario, ref sistema);
            contrasenias.Show();
        }

        private void btnTarjetas_Click(object sender, EventArgs e)
        {
            this.Hide();
            InterfazTarjeta tarjeta = new InterfazTarjeta(ref usuario, ref sistema);
            tarjeta.Show();
        }
    }
}
