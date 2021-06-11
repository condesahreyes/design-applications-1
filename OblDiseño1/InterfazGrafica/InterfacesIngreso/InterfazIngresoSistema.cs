using Menu = InterfazGrafica.InterfacesMenu.Menu;
using System.Windows.Forms;
using OblDiseño1;
using System;
using AccesoDatos;

namespace InterfazGrafica.InterfazIngreso
{
    public partial class InterfazIngresoSistema : Form
    {
        private Sistema sistema;
        UsuarioRepositorio usuariosRepo = new UsuarioRepositorio();

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
            {
                MessageBox.Show("Se ha ingresado correctamente.Bienvenido!");
                IrAlMenu(ref usuario);
            }
                
            else if(usuario != null)
                ContraseniaInvalida();
        }

        public bool VerificarContraseñaCorrecta(string nombreUsuario, string contrasenia)
        {
            Usuario usuarioIngresado = usuariosRepo.Get(nombreUsuario);
            if (usuarioIngresado.Contrasenia == contrasenia)
                return true;
            else
                return false;
        }

        private Usuario ObtenerUsuario(string nombreUsuario, string contrasenia)
        {
            Usuario usuario=null;
                //usuario = sistema.DevolverUsuario(nombreUsuario);
                
                if (usuariosRepo.Existe(nombreUsuario))
                {
                    Usuario usuarioDominio =usuariosRepo.Get(nombreUsuario);
                    return usuarioDominio;
                }
                else
                usuario = CrearUsuario(nombreUsuario, contrasenia);
            

            return usuario;
        }

        private Usuario CrearUsuario(string nombreUsuario, string contrasenia)
        {
            try
            {
                //Usuario unUsuario=sistema.AgregarUsuario(nombreUsuario, contrasenia);
                Usuario usuarioAAgregar = new Usuario(nombreUsuario, contrasenia);
                UsuarioRepositorio repositorioUsuaurio = new UsuarioRepositorio();
                repositorioUsuaurio.Add(usuarioAAgregar);
                MessageBox.Show("Se lo ha registrado como nuevo usuario");
                return usuarioAAgregar;
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            InterfazCambioContrasenia modificarContrasenia = new InterfazCambioContrasenia(ref sistema);
            modificarContrasenia.Show();
        }
    }
}
