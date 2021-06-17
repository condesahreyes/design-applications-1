using OblDiseño1.ControladoresPorEntidad;
using System.Collections.Generic;
using AccesoDatos.Repositorios;
using System.Windows.Forms;
using AccesoDatos;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfazCompartirContraseñas
{
    public partial class InterfazCompartirContraseña : Form
    {
        private Usuario usuario;

        private ControladorUsuario controladorUsuario;
        private ControladorCredencial controladorCredencial;

         public InterfazCompartirContraseña(ref Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;

            CrearManejadoresCredencial();
            CrearControladorUsuario();
            CargarOpcionesDeUsuariosACompartir();
            CargarOpcionesDeSitiosParaCompartir();
        }

        private void CrearManejadoresCredencial()
        {
            controladorCredencial = new ControladorCredencial(this.usuario);
        }

        private void CrearControladorUsuario()
        {
            controladorUsuario = new ControladorUsuario();
        }

        private void CargarOpcionesDeUsuariosACompartir()
        {
            List<Usuario> usuariosDisponibles = controladorUsuario.ObtenerTodosMisUsuarios();

            usuariosDisponibles.Remove(this.usuario);

            foreach (var usuario in usuariosDisponibles)
                comboBoxUsuarios.Items.Add(usuario.Nombre);
        }

        private void CargarOpcionesDeSitiosParaCompartir()
        {
            List<Credencial> credenciales = controladorCredencial.ObtenerTodasMisCredenciales(); 

            if (credenciales != null)
            foreach (var credencial in credenciales)
                comboBoxSitios.Items.Add(credencial.NombreSitioApp);
        }

        private void comboBoxSitios_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxUsuariosSitios.Items.Clear();
            string sitio = comboBoxSitios.SelectedItem.ToString();

            List<Credencial> credenciales = controladorCredencial.ObtenerTodasMisCredenciales();

            foreach (var credencial in credenciales)
                if (credencial.NombreSitioApp == sitio)
                    comboBoxUsuariosSitios.Items.Add(credencial.NombreUsuario);
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            IrAInterfazContraseñasCompartidas();
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {

            string usuarioSeleccionado = comboBoxUsuarios.Text;

            Usuario usuarioACompartir;

            if (usuarioSeleccionado.Length == 0)
                MessageBox.Show("Debe seleccionar un usuario para compartir");
            else
            {
                Usuario usuarioAuxiliar = new Usuario();
                usuarioAuxiliar.Nombre = usuarioSeleccionado;
                usuarioACompartir = controladorUsuario.ObtenerUnUsuario(usuarioAuxiliar);

                CompartirContraseña(ref usuarioACompartir);
            }
         }

        private void CompartirContraseña(ref Usuario usuarioACompartir)
        {
            string nomSitioSeleccionado = comboBoxSitios.Text;
            string nomUsuarioSeleccionado = comboBoxUsuariosSitios.Text;
            RegistroCredencialCompartidaRepositorio repositorioCredencialCompartida = new RegistroCredencialCompartidaRepositorio(this.usuario);
            ControladorAlta controladorAlta = new ControladorAlta();

            foreach (var iterador in this.usuario.ObtenerCredenciales())
            {
                if ((iterador.NombreSitioApp == nomSitioSeleccionado) && 
                    (iterador.NombreUsuario == nomUsuarioSeleccionado))
                {
                    Credencial credencialACompartir = iterador;
                    try
                    {
                        controladorAlta.AgregarRegistroCredencialCompartida(credencialACompartir,usuarioACompartir, 
                            repositorioCredencialCompartida);
                        MessageBox.Show("Se compartio la contraseña correctamente");
                        IrAInterfazContraseñasCompartidas();
                    }
                    catch (Exception Exepcion_InvalidUsuarioData)
                    {
                        MessageBox.Show("Ya se compartio esta contraseña con el usuario");
                    }
                    break;
                }
            }
        }

        private void IrAInterfazContraseñasCompartidas()
        {
            this.Close();
            InterfazContraseñasCompartidas interfazContraseñasCompartidas = new InterfazContraseñasCompartidas(ref usuario);
            interfazContraseñasCompartidas.Show();
        }
    }
}
