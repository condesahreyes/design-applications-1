using Menu = InterfazGrafica.InterfacesMenu.Menu;
using System.Windows.Forms;
using AccesoDatos;
using OblDiseño1;
using System;
using OblDiseño1.ControladoresPorEntidad;

namespace InterfazGrafica.InterfazIngreso
{
    public partial class InterfazIngresoSistema : Form
    {
        private ControladorUsuario controladorUsuario;

        public InterfazIngresoSistema()
        {
            InitializeComponent();
            controladorUsuario = new ControladorUsuario();
        }

        private void ingresoSistema_Click(object sender, EventArgs e)
        {
            string nombreUsuario = userGestor.Text;
            string contrasenia = pssGestor.Text;

            Usuario usuario = ObtenerUsuario(nombreUsuario, contrasenia);

            if (usuario != null && VerificarContraseñaCorrecta(nombreUsuario, contrasenia))
                IrAlMenu(ref usuario);
            else if (usuario != null)
                ContraseniaInvalida();
        }

        public bool VerificarContraseñaCorrecta(string nombreUsuario, string contrasenia)
        {
            Usuario usuario = new Usuario(nombreUsuario, contrasenia);
            Usuario usuarioIngresado = controladorUsuario.ObtenerUnUsuario(usuario);

            if (usuarioIngresado.Contrasenia == contrasenia)
                return true;
            else
                return false;
        }

        private Usuario ObtenerUsuario(string nombreUsuario, string contrasenia)
        {
            try
            {
                Usuario usuario = new Usuario(nombreUsuario, contrasenia);

                if (controladorUsuario.ExisteUsuario(usuario))
                {
                    usuario = controladorUsuario.ObtenerUnUsuario(usuario);
                    
                }
                    
                else
                {
                    controladorUsuario.AgregarUsuario(usuario);
                    MessageBox.Show("Se lo ha registrado como nuevo usuario");
                }
                return usuario;
            }
            catch (Exception ExcepcionInvalidUsuarioData)
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
            Menu menu = new Menu(ref usuario);
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

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            this.Hide();
            InterfazCambioContrasenia modificarContrasenia = new InterfazCambioContrasenia();
            modificarContrasenia.Show();
        }
    }
}
