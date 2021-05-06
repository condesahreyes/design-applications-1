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
            Usuario usuario = ObtenerUsuario(nombreUsuario, contrasenia);

            if (usuario != null && sistema.PuedoIngresarAlSistema(nombreUsuario, contrasenia))
                IrAlMenu(ref usuario);
            else if(usuario != null)
                ContraseniaInvalida();
        }

        private Usuario ObtenerUsuario(string nombreUsuario, string contrasenia)
        {
            Usuario usuario=null;

            try
            {
                usuario = sistema.DevolverUsuario(nombreUsuario);
            }
            catch (Exception ObjectNotFoundException)
            {
                
                usuario = CrearUsuario(nombreUsuario, contrasenia);
            }

            return usuario;
        }

        private Usuario CrearUsuario(string nombreUsuario, string contrasenia)
        {
            try
            {
                Usuario unUsuario=sistema.AgregarUsuario(nombreUsuario, contrasenia);
                MessageBox.Show("Se lo ha registrado como nuevo usuario");
                return unUsuario;
            }
            catch (Exception InvalidUsuarioDataException)
            {
                MessageBox.Show("Verifique que su usuario contenga entre 1 a 25 " +
                    "caracteres y su contraseña entre 5 a 25 caracteres.");
                LimpiarCampos();
            }

            return null;
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
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            userGestor.Clear();
            pssGestor.Clear();
        }

    }
}
