using OblDiseño1;
using System;
using System.Windows.Forms;
using Menu = InterfazGrafica.InterfacesMenu.Menu;

namespace InterfazGrafica.InterfazIngreso
{
    public partial class InterfazIngresoSistema : Form
    {
        Sistema sistema;

        public InterfazIngresoSistema(ref Sistema sistema)
        {
            InitializeComponent();
            this.sistema = sistema;
        }

        private void InterfazIngresoSistema_Load(object sender, EventArgs e)
        {

        }

        private void ingresoSistema_Click(object sender, EventArgs e)
        {
            string nombreUsuario = userGestor.Text;
            string contrasenia = pssGestor.Text;

            Usuario usuario = sistema.DevolverUsuario(nombreUsuario);

            if (usuario == null)
            {
                usuario = sistema.AgregarUsuario(nombreUsuario, contrasenia);
                MessageBox.Show("Se lo ha registrado como nuevo usuario");
                IrAlMenu(ref usuario);
            }
            else if (sistema.PuedoIngresarAlSistema(nombreUsuario, contrasenia))
                IrAlMenu(ref usuario);
            else
                ContraseniaInvalida();
        }

        private void IrAlMenu(ref Usuario usuario)
        {
            this.Hide();
            Menu menu = new Menu(ref sistema, ref usuario);
            menu.Show();
        }

        private void ContraseniaInvalida()
        {
            MessageBox.Show("Contraseña incorrecta, vuelva a ingresar");
            userGestor.Clear();
            pssGestor.Clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
