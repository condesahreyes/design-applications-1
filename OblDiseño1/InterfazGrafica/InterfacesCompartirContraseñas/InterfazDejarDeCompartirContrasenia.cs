using OblDiseño1.ControladoresPorFuncionalidad;
using System.Collections.Generic;
using AccesoDatos.Repositorios;
using System.Windows.Forms;
using OblDiseño1.Entidades;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfazCompartirContraseñas
{
    public partial class InterfazDejarDeCompartirContrasenia : Form
    {
        private GestorContraseniasCompartidas miGestor;
        private Credencial credencial;
        private Usuario usuario;

        private ControladorObtener controladorObtener = new ControladorObtener();
        private ControladorEliminar controladorEliminar = new ControladorEliminar();

        private IRepositorioCompartir<Credencial, Usuario> repositorioRegistroContraCompartida;

        public InterfazDejarDeCompartirContrasenia(ref Usuario usuario, ref Credencial credencial)
        {
            InitializeComponent();

            this.usuario = usuario;
            this.credencial = credencial;

            miGestor = usuario.GestorCompartirContrasenia;

            repositorioRegistroContraCompartida = new RegistroCredencialCompartidaRepositorio(usuario);

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
                this.controladorEliminar.EliminarRegistroCredencialCompartida(this.credencial,
                    usuarioSeleccionado, this.repositorioRegistroContraCompartida);

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
