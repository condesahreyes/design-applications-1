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
using Menu = InterfazGrafica.InterfacesMenu.Menu;

namespace InterfazGrafica.InterfazCompartirContraseñas
{
    public partial class InterfazContraseñasCompartidas : Form
    {
        private Sistema sistema;
        private Usuario usuario;
        public InterfazContraseñasCompartidas(ref Sistema sistema, ref Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.sistema = sistema;
            CargarContraseñasCompartidas();
            CargarContraseñasCompartidasConmigo();
        }

        private void CargarContraseñasCompartidas()
        {
            BindingSource biso = new BindingSource();
            biso.DataSource = this.usuario.ObtenerContraseniasCompartidasPorMi().Keys;
            
            if (this.usuario.ObtenerContraseniasCompartidasPorMi().Count == 0)
            {
                this.dataGridContraseñasCompartidas.Visible = true;
            }
            else
            {
                 this.dataGridContraseñasCompartidas.DataSource = biso;
                 this.dataGridContraseñasCompartidas.Columns["TipoSitioOApp"].Visible = false;
                 this.dataGridContraseñasCompartidas.Columns["Nota"].Visible = false;
                 this.dataGridContraseñasCompartidas.Columns["NivelSeguridadContrasenia"].Visible = false;
                 this.dataGridContraseñasCompartidas.Columns["DataBrench"].Visible = false;
            }
        }


        private void CargarContraseñasCompartidasConmigo()
        {
            BindingSource biso2 = new BindingSource();
            List<Dupla_UsuarioContrasenia> listaDuplasCompartidasConmigo = new List<Dupla_UsuarioContrasenia>();
            foreach (var iterador in this.usuario.ObtenerContraseniasCompartidasConmigo())
            {
                foreach (var iteradorAuxiliar in iterador.Value)
                    listaDuplasCompartidasConmigo.Add(iteradorAuxiliar);
            }
            
            biso2.DataSource = listaDuplasCompartidasConmigo;
            if (listaDuplasCompartidasConmigo.Count > 0)
            {
                this.dataGridContraseñasCompartidasConmigo.DataSource = biso2;
                this.dataGridContraseñasCompartidas.Columns["TipoSitioOApp"].Visible = false;
                this.dataGridContraseñasCompartidas.Columns["Nota"].Visible = false;
                this.dataGridContraseñasCompartidas.Columns["NivelSeguridadContrasenia"].Visible = false;
                this.dataGridContraseñasCompartidas.Columns["DataBrench"].Visible = false;
            }
           

        }



        private void InterfazContraseñasCompartidas_Load(object sender, EventArgs e)
        {
            if (this.dataGridContraseñasCompartidasConmigo.Rows.Count > 0)
                this.dataGridContraseñasCompartidasConmigo.ClearSelection();
            if (this.dataGridContraseñasCompartidas.Rows.Count > 0)
                this.dataGridContraseñasCompartidas.ClearSelection();
        }

        private void dataGridContraseñasCompartidas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonCompartir_Click(object sender, EventArgs e)
        {
            this.Close();
            InterfazCompartirContraseña interfazCompartirContraseña = new InterfazCompartirContraseña(ref sistema, ref usuario);
            interfazCompartirContraseña.Show();
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu(ref sistema, ref usuario);
            menu.Show();
        }

       

        private void listUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridUsuariosCompartidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonVerUsuariosCompartidos_Click(object sender, EventArgs e)
        {
            if (this.usuario.ObtenerContraseniasCompartidasPorMi().Count == 0)
                MessageBox.Show("Error: No hay contraseñas compartidas aun");
            else
            {
                Dupla_UsuarioContrasenia duplaSeleccionada = (Dupla_UsuarioContrasenia)dataGridContraseñasCompartidas.CurrentRow.DataBoundItem;
                if (duplaSeleccionada == null)
                    MessageBox.Show("Error: debe seleccionar una contrasenia primero");
                else
                {
                    InterfazDejarDeCompartirContrasenia interfazDejarDeCompartirContrasenias = new InterfazDejarDeCompartirContrasenia(ref sistema, ref usuario, ref duplaSeleccionada);
                    this.Close();
                    interfazDejarDeCompartirContrasenias.Show();
                }
            }
            
        }

        private void dataGridContraseñasCompartidasConmigo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
