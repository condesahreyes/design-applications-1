using System.Windows.Forms;
using System;
using OblDiseño1;
using OblDiseño1.ControladoresPorFuncionalidad;
using AccesoDatos;
using System.Collections.Generic;

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

            CargarOpcionesDeUsuariosACompartir();
            CargarOpcionesDeSitiosParaCompartir();
        }

        private void CargarOpcionesDeUsuariosACompartir()
        {
            ControladorObtener controladorObtener = new ControladorObtener();
            UsuarioRepositorio repositorioUsuario = new UsuarioRepositorio();
            List<Usuario> usuariosDisponibles = controladorObtener.ObtenerUsuarios(repositorioUsuario);
            usuariosDisponibles.Remove(this.usuario);

            foreach (var usuario in usuariosDisponibles)
                comboBoxUsuarios.Items.Add(usuario.Nombre);
        }

        private void CargarOpcionesDeSitiosParaCompartir()
        {
            ControladorObtener controladorObtener = new ControladorObtener();
            CredencialRepositorio repositorioCredencial = new CredencialRepositorio(this.usuario);
            List<Credencial> credenciales = repositorioCredencial.GetAll();

            foreach (var credencial in credenciales)
            {
                comboBoxSitios.Items.Add(credencial.NombreSitioApp);
            }
            //foreach (var iterador in usuario.ObtenerCredenciales())
            //    comboBoxSitios.Items.Add(iterador.NombreSitioApp);
        }

        private void comboBoxSitios_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxUsuariosSitios.Items.Clear();
            string sitio = comboBoxSitios.SelectedItem.ToString();
            
            
            //foreach (var iterador in usuario.ObtenerCredenciales())
            //{
            //    if (iterador.NombreSitioApp == sitio)
            //        comboBoxUsuariosSitios.Items.Add(iterador.NombreUsuario);
            //}
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
                usuarioACompartir = ObtenerUsuarioACompartir(usuarioSeleccionado);

                CompartirContraseña(ref usuarioACompartir);
            }
         }

        private void CompartirContraseña(ref Usuario usuarioACompartir)
        {
            string nomSitioSeleccionado = comboBoxSitios.Text;
            string nomUsuarioSeleccionado = comboBoxUsuariosSitios.Text;

            foreach (var iterador in this.usuario.ObtenerCredenciales())
            {
                if ((iterador.NombreSitioApp == nomSitioSeleccionado) && 
                    (iterador.NombreUsuario == nomUsuarioSeleccionado))
                {
                    Credencial duplaACompartir = iterador;
                    try
                    {
                        this.usuario.CompartirContrasenia(duplaACompartir, usuarioACompartir);
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

        private Usuario ObtenerUsuarioACompartir(String usuarioSeleccionado)
        {
            foreach (var iteradorUsuario in this.sistema.ObtenerUsuarios())
                if (iteradorUsuario.Nombre == usuarioSeleccionado)
                    return iteradorUsuario;
            return null;
        }

        private void IrAInterfazContraseñasCompartidas()
        {
            this.Close();
            InterfazContraseñasCompartidas interfazContraseñasCompartidas = new InterfazContraseñasCompartidas(ref sistema, ref usuario);
            interfazContraseñasCompartidas.Show();
        }
    }
}
