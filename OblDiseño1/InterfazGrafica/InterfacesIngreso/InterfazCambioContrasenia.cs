using System.Windows.Forms;
using AccesoDatos;
using OblDiseño1;
using System;
using OblDiseño1.ControladoresPorEntidad;

namespace InterfazGrafica.InterfazIngreso
{
    public partial class InterfazCambioContrasenia : Form
    {

        private ControladorUsuario controladorUsuario;
        public InterfazCambioContrasenia()
        {
            InitializeComponent();
            controladorUsuario = new ControladorUsuario();
        }

        private void btnModificarContrasenia_Click(object sender, EventArgs e)
        {
            string nombreUsuario = textBoxNombre.Text;
            string contrasenia = textBoxContrasenia.Text;
            string nuevaContrasenia = textBoxNuevaContrasenia.Text;

            try
            {
                Usuario intentoLogin = new Usuario(nombreUsuario, contrasenia);
                Usuario usuarioRegistrado = controladorUsuario.ObtenerUnUsuario(intentoLogin);
                if (usuarioRegistrado != null && usuarioRegistrado.Contrasenia == contrasenia)
                    ModificarContrasenia(intentoLogin, nuevaContrasenia);
                else
                    MessageBox.Show("Error, contraseña incorrecta");
            }
            catch (Exception ObjectNotFoundException)
            {
                MessageBox.Show("Error, no existe usuario");
                LimpiarCampos();
            }
        }

        private void ModificarContrasenia(Usuario usuario, string unaContrasenia)
        {
            try
            {
                Usuario usuarioModificado = new Usuario(usuario.Nombre, unaContrasenia);

                controladorUsuario.ModificarUsuario(usuario, usuarioModificado);
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
            InterfazIngresoSistema login = new InterfazIngresoSistema();
            login.Show();
        }
    }
}
