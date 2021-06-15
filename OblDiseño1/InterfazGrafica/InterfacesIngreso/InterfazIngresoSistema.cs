using Menu = InterfazGrafica.InterfacesMenu.Menu;
using OblDiseño1.ControladoresPorFuncionalidad;
using System.Windows.Forms;
using AccesoDatos;
using OblDiseño1;
using System;
using System.Collections.Generic;

namespace InterfazGrafica.InterfazIngreso
{
    public partial class InterfazIngresoSistema : Form
    {
        private Sistema sistema;

        private UsuarioRepositorio usuariosRepo = new UsuarioRepositorio();
        private ControladorAlta controladorAlta = new ControladorAlta();

        public InterfazIngresoSistema(ref Sistema sistema)
        {
            this.sistema = sistema;
            InitializeComponent();
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
            Usuario usuarioIngresado = usuariosRepo.Get(usuario);

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

                if (usuariosRepo.Existe(usuario))
                {
                    usuario = usuariosRepo.Get(usuario);
                    
                }
                    
                else
                {
                    controladorAlta.AgregarUsuario(usuario, usuariosRepo);
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

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            this.Hide();
            InterfazCambioContrasenia modificarContrasenia = new InterfazCambioContrasenia(ref sistema);
            modificarContrasenia.Show();
        }
    }
}
