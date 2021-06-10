using System.Windows.Forms;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfazIngreso
{
    public partial class InterfazCambioContrasenia : Form
    {
        private Sistema sistema;
        public InterfazCambioContrasenia(ref Sistema sistema)
        {
            InitializeComponent();
            this.sistema = sistema;
        }

        private void btnModificarContrasenia_Click(object sender, EventArgs e)
        {
            string nombreUsuario = textBoxNombre.Text;
            string contrasenia = textBoxContrasenia.Text;
            string nuevaContrasenia = textBoxNuevaContrasenia.Text;

            try
            {
                if(sistema.PuedoIngresarAlSistema(nombreUsuario, contrasenia))
                {
                    Usuario usuario = sistema.DevolverUsuario(nombreUsuario);
                    ModificarContrasenia(ref usuario, nuevaContrasenia);
                }
                else
                    MessageBox.Show("Error, contraseña incorrecta");

            }
            catch (Exception ObjectNotFoundException)
            {
                MessageBox.Show("Error, no existe usuario");
                LimpiarCampos();
            }
        }

        private void ModificarContrasenia(ref Usuario usuario, string unaContrasenia)
        {
            try
            {
                usuario.ActualizarContrasenia(unaContrasenia);
                MessageBox.Show("Su contraseña se ha actualizado con éxito. Pruebe loguearse");
                IrAlLogin();
            }
            catch (Exception InvalidUsuarioDataException)
            {
                MessageBox.Show("Verifique que su nueva contraseña contenga entre 5 a 25 caracteres.");
                LimpiarCampos();
            }
        }

        private void LimpiarCampos()
        {
            textBoxNombre.Clear();
            textBoxContrasenia.Clear();
            textBoxNuevaContrasenia.Clear();
        }

        private void btnCancelarContrasenia_Click(object sender, EventArgs e)
        {
            IrAlLogin();
        }
        private void IrAlLogin()
        {
            this.Hide();
            InterfazIngresoSistema login = new InterfazIngresoSistema(ref sistema);
            login.Show();
        }
    }
}
