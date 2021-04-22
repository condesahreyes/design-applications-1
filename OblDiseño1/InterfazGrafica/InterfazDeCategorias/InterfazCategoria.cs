using OblDiseño1;
using System;
using Menu = InterfazGrafica.InterfacesMenu.Menu;
using System.Windows.Forms;
using InterfazGrafica.InterfazDeCategorias;

namespace InterfazGrafica.InterfazCategoria
{
    public partial class InterfazCategorias : Form
    {
        private Usuario usuario;
        private Sistema sistema;

        public InterfazCategorias(ref Usuario usuario, ref Sistema sistema)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.sistema = sistema;
        }

        private void InterfazCategorias_Load(object sender, EventArgs e)
        {

        }

        private void btnCategoriaVolverMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu(ref sistema, ref usuario);
            menu.Show();
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            this.Hide();
            InterfazAgregarCategoria agregarCategoria = new InterfazAgregarCategoria(ref sistema, ref usuario);
            agregarCategoria.Show();
        }
    }
}
