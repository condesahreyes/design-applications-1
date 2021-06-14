using OblDiseño1.ControladoresPorFuncionalidad;
using System.Windows.Forms;
using AccesoDatos;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfazIngreso
{
    public partial class InterfazCambioContrasenia : Form
    {
        private Sistema sistema;

        private ControladorModificar controladorModificar = new ControladorModificar();
        private ControladorObtener controladorObtener = new ControladorObtener();
        private UsuarioRepositorio usuariosRepo = new UsuarioRepositorio();
        private ControladorAlta controladorAlta = new ControladorAlta();

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
                Usuario intentoLogin = new Usuario(nombreUsuario, contrasenia);
                if (controladorObtener.ObtenerUsuario(intentoLogin, usuariosRepo)!=null)
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

                controladorModificar.ModificarUsuario(usuario, usuarioModificado, usuariosRepo);
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
