using System.Collections.Generic;
using AccesoDatos.Repositorios;
using System.Windows.Forms;
using OblDiseño1.Entidades;
using OblDiseño1;
using System;
using CapaDeComunicación.ControladoresPorEntidad;

namespace InterfazGrafica.InterfazCompartirContraseñas
{
    public partial class InterfazDejarDeCompartirContrasenia : Form
    {
        private GestorContraseniasCompartidas miGestor;
        private Credencial credencial;
        private Usuario usuario;

        private ControladorRegistroCredencialCompartida controladorRegistroCredencialCompartida;

        public InterfazDejarDeCompartirContrasenia(ref Usuario usuario, ref Credencial credencial)
        {
            InitializeComponent();

            this.usuario = usuario;
            this.credencial = credencial;
            this.controladorRegistroCredencialCompartida = new ControladorRegistroCredencialCompartida(this.usuario);

            miGestor = usuario.GestorCompartirContrasenia;
            CargarDataGrid();
        }

        private void CargarDataGrid()
        {
            this.dataGridUsuariosCompartidos.AllowUserToAddRows = false;
            if (miGestor.ObtenerContraseniasCompartidasPorMi().ContainsKey(credencial))
            {
                List<Usuario> usuariosCompartidosPorDupla = miGestor.
                    ObtenerContraseniasCompartidasPorMi()[credencial];
                dataGridUsuariosCompartidos.DataSource = usuariosCompartidosPorDupla;
                dataGridUsuariosCompartidos.Columns["Contrasenia"].Visible = false;
                dataGridUsuariosCompartidos.Columns["GestorCompartirContrasenia"].Visible = false;
            }
        }

        private void buttonDejarDeCompartir_Click(object sender, EventArgs e)
        {
            if (dataGridUsuariosCompartidos.CurrentRow != null && 0 < dataGridUsuariosCompartidos.RowCount)
            {
                Usuario usuarioSeleccionado = (Usuario)dataGridUsuariosCompartidos.CurrentRow.DataBoundItem;
                controladorRegistroCredencialCompartida.dejarDeCompartirCredencial(this.credencial, usuarioSeleccionado);
                MessageBox.Show("La contraseña se dejo de compartir exitosamente");
                IrAInterfazContraseñasCompartidas();
            }
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            IrAInterfazContraseñasCompartidas();
        }

        private void IrAInterfazContraseñasCompartidas()
        {
            this.Close();
            InterfazContraseñasCompartidas interfazContraseñasCompartidas = 
                new InterfazContraseñasCompartidas(ref usuario);
            interfazContraseñasCompartidas.Show();
        }

    }
}
