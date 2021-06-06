using OblDiseño1;
using OblDiseño1.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InterfazGrafica.InterfazCompartirContraseñas
{
    public partial class InterfazDejarDeCompartirContrasenia : Form
    {
        private Sistema sistema;
        private Usuario usuario;
        private Credencial credencial;
        private GestorContraseniasCompartidas miGestor;

        public InterfazDejarDeCompartirContrasenia(ref Sistema sistema, ref Usuario usuario, ref Credencial credencial)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.sistema = sistema;
            this.credencial = credencial;

            miGestor = usuario.GestorCompartirContrasenia;

            if (miGestor.ObtenerContraseniasCompartidasPorMi().ContainsKey(credencial))
            {
                List<Usuario> usuariosCompartidosPorDupla = miGestor.ObtenerContraseniasCompartidasPorMi()[credencial];
                dataGridUsuariosCompartidos.DataSource = usuariosCompartidosPorDupla;
                dataGridUsuariosCompartidos.Columns["Contrasenia"].Visible = false;
                dataGridUsuariosCompartidos.Columns["GestorCompartirContrasenia"].Visible = false;
            }
        }

        private void buttonDejarDeCompartir_Click(object sender, EventArgs e)
        {
            Usuario usuarioSeleccionado = (Usuario)dataGridUsuariosCompartidos.CurrentRow.DataBoundItem;
            usuario.DejarDeCompartirContrasenia(this.credencial, usuarioSeleccionado);
            IrAInterfazContraseñasCompartidas();
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            IrAInterfazContraseñasCompartidas();
        }

        private void IrAInterfazContraseñasCompartidas()
        {
            this.Close();
            InterfazContraseñasCompartidas interfazContraseñasCompartidas = new InterfazContraseñasCompartidas(ref sistema, ref usuario);
            interfazContraseñasCompartidas.Show();
        }
    }
}
