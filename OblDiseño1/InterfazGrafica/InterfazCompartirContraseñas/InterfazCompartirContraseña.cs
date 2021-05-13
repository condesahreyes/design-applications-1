using OblDiseño1;
using System;
using System.Windows.Forms;

namespace InterfazGrafica.InterfazCompartirContraseñas
{
    public partial class InterfazCompartirContraseña : Form
    {
        private Sistema sistema;
        private Usuario usuario;
        public InterfazCompartirContraseña(ref Sistema sistema, ref Usuario usuario)
        {
            InitializeComponent();
            this.sistema = sistema;
            this.usuario = usuario;
            foreach (var iterador in sistema.ObtenerUsuarios())
            {
                if (iterador.Nombre != this.usuario.Nombre)
                comboBoxUsuarios.Items.Add(iterador.Nombre);
            }
            foreach (var iterador in usuario.ObtenerDuplas())
                comboBoxSitios.Items.Add(iterador.NombreSitioApp);
        }

        private void comboBoxSitios_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxUsuariosSitios.Items.Clear();
            string sitio = comboBoxSitios.SelectedItem.ToString();
            foreach (var iterador in usuario.ObtenerDuplas())
            {
                if (iterador.NombreSitioApp == sitio)
                    comboBoxUsuariosSitios.Items.Add(iterador.NombreUsuario);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            IrAInterfazContraseñasCompartidas();
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            string nomSitioSeleccionado = comboBoxSitios.Text;
            string nomUsuarioSeleccionado = comboBoxUsuariosSitios.Text;
            string usuarioSeleccionado = comboBoxUsuarios.Text;
            Usuario usuarioACompartir = new Usuario();

            if (usuarioSeleccionado.Length == 0)
                MessageBox.Show("Debe seleccionar un usuario para compartir");
            else
            {
                foreach (var iteradorUsuario in this.sistema.ObtenerUsuarios())
                {
                    usuarioACompartir = iteradorUsuario;
                    if (usuarioACompartir.Nombre == usuarioSeleccionado)
                        break;
                }

                foreach (var iterador in this.usuario.ObtenerDuplas())
                {
                    if ((iterador.NombreSitioApp == nomSitioSeleccionado) && (iterador.NombreUsuario == nomUsuarioSeleccionado))
                    {
                        Dupla_UsuarioContrasenia duplaACompartir = iterador;
                        try
                        {
                            this.usuario.CompartirContrasenia(duplaACompartir, usuarioACompartir);
                            MessageBox.Show("Se compartio la contraseña correctamente");
                            IrAInterfazContraseñasCompartidas();
                        }
                        catch (Exception InvalidUsuarioDataException)
                        {
                            MessageBox.Show("Ya se compartio esta contraseña con el usuario");

                        }
                        break;
                    }
                }
            }
         }

        private void IrAInterfazContraseñasCompartidas()
        {
            this.Close();
            InterfazContraseñasCompartidas interfazContraseñasCompartidas = new InterfazContraseñasCompartidas(ref sistema, ref usuario);
            interfazContraseñasCompartidas.Show();
        }
    }
}
