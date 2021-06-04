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
        private Dupla_UsuarioContrasenia dupla;
        private GestorContraseniasCompartidas miGestor;

        public InterfazDejarDeCompartirContrasenia(ref Sistema sistema, ref Usuario usuario, ref Dupla_UsuarioContrasenia dupla)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.sistema = sistema;
            this.dupla = dupla;

            miGestor = usuario.GestorCompartirContrasenia;

            if (miGestor.ObtenerContraseniasCompartidasPorMi().ContainsKey(dupla))
            {
                List<Usuario> usuariosCompartidosPorDupla = miGestor.ObtenerContraseniasCompartidasPorMi()[dupla];
                dataGridUsuariosCompartidos.DataSource = usuariosCompartidosPorDupla;
                dataGridUsuariosCompartidos.Columns["Contrasenia"].Visible = false;
                dataGridUsuariosCompartidos.Columns["GestorCompartirContrasenia"].Visible = false;
            }
        }

        private void buttonDejarDeCompartir_Click(object sender, EventArgs e)
        {
            Usuario usuarioSeleccionado = (Usuario)dataGridUsuariosCompartidos.CurrentRow.DataBoundItem;
            usuario.DejarDeCompartirContrasenia(this.dupla, usuarioSeleccionado);
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
