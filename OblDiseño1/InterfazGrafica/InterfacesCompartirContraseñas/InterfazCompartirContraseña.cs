using System.Windows.Forms;
using System;
using OblDiseño1;
using OblDiseño1.ControladoresPorFuncionalidad;
using AccesoDatos;
using System.Collections.Generic;
using AccesoDatos.Repositorios;

namespace InterfazGrafica.InterfazCompartirContraseñas
{
    public partial class InterfazCompartirContraseña : Form
    {
        private Sistema sistema;
        private Usuario usuario;
        ControladorObtener controladorObtener = new ControladorObtener();
         public InterfazCompartirContraseña(ref Sistema sistema, ref Usuario usuario)
        {
            InitializeComponent();
            this.sistema = sistema;
            this.usuario = usuario;

            CargarOpcionesDeUsuariosACompartir();
            CargarOpcionesDeSitiosParaCompartir();
        }

        private void CargarOpcionesDeUsuariosACompartir()
        {
            UsuarioRepositorio repositorioUsuario = new UsuarioRepositorio();
            List<Usuario> usuariosDisponibles = controladorObtener.ObtenerUsuarios(repositorioUsuario);
            usuariosDisponibles.Remove(this.usuario);

            foreach (var usuario in usuariosDisponibles)
                comboBoxUsuarios.Items.Add(usuario.Nombre);
        }

        private void CargarOpcionesDeSitiosParaCompartir()
        {
            CredencialRepositorio repositorioCredencial = new CredencialRepositorio(this.usuario);
            List<Credencial> credenciales = controladorObtener.ObtenerCredenciales(repositorioCredencial); 

            if (credenciales != null)
            foreach (var credencial in credenciales)
                comboBoxSitios.Items.Add(credencial.NombreSitioApp);
        }

        private void comboBoxSitios_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxUsuariosSitios.Items.Clear();
            string sitio = comboBoxSitios.SelectedItem.ToString();

            CredencialRepositorio repositorioCredencial = new CredencialRepositorio(this.usuario);
            List<Credencial> credenciales = controladorObtener.ObtenerCredenciales(repositorioCredencial);

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
                UsuarioRepositorio repositorioUsuario = new UsuarioRepositorio();
                usuarioACompartir = controladorObtener.ObtenerUsuario(usuarioAuxiliar, repositorioUsuario);

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
                        controladorAlta.AgregarRegistroCredencialCompartida(credencialACompartir,usuarioACompartir, repositorioCredencialCompartida);
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
            InterfazContraseñasCompartidas interfazContraseñasCompartidas = new InterfazContraseñasCompartidas(ref sistema, ref usuario);
            interfazContraseñasCompartidas.Show();
        }
    }
}
