using OblDiseño1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazGrafica.InterfazCompartirContraseñas
{
    public partial class InterfazDejarDeCompartirContrasenia : Form
    {
        private Sistema sistema;
        private Usuario usuario;
        private Dupla_UsuarioContrasenia dupla;

        public InterfazDejarDeCompartirContrasenia(ref Sistema sistema, ref Usuario usuario, ref Dupla_UsuarioContrasenia dupla)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.sistema = sistema;
            this.dupla = dupla;

            if(this.usuario.ObtenerContraseniasCompartidasPorMi().ContainsKey(dupla))
            {
                List<Usuario> usuariosCompartidosPorDupla = this.usuario.ObtenerContraseniasCompartidasPorMi()[dupla];
                dataGridUsuariosCompartidos.DataSource = usuariosCompartidosPorDupla;
                dataGridUsuariosCompartidos.Columns["Contrasenia"].Visible = false;
            }
        }

        private void InterfazDejarDeCompartirContrasenia_Load(object sender, EventArgs e)
        {

        }

        private void dataGridUsuariosCompartidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonDejarDeCompartir_Click(object sender, EventArgs e)
        {
            Usuario usuarioSeleccionado = (Usuario) dataGridUsuariosCompartidos.CurrentRow.DataBoundItem;
            this.usuario.DejarDeCompartirContrasenia(this.dupla, usuarioSeleccionado);
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
