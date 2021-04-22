using OblDiseño1;
using System.Windows.Forms;
using Menu = InterfazGrafica.InterfacesMenu.Menu;

namespace InterfazGrafica.InterfacesDeContrasenias
{
    public partial class InterfazContrasenia : Form
    {
        Usuario usuario;
        Sistema sistema;
        public InterfazContrasenia(ref Usuario usuario, ref Sistema sistema)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.sistema = sistema;
        }

        private void btnContraseniaVolverMenu_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu(ref sistema, ref usuario);
            menu.Show();
        }

        private void btnAgregarContrasenia_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            InterfazAgregarContrasenia agregarContrasenia = new InterfazAgregarContrasenia(ref sistema, ref usuario);
            agregarContrasenia.Show();
        }
    }
}
