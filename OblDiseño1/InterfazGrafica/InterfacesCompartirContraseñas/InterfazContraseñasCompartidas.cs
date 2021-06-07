using Menu = InterfazGrafica.InterfacesMenu.Menu;
using System.Collections.Generic;
using OblDiseño1.Entidades;
using System.Windows.Forms;
using OblDiseño1;
using System;


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
            GestorContraseniasCompartidas miGestor = usuario.GestorCompartirContrasenia;
            biso.DataSource = miGestor.ObtenerContraseniasCompartidasPorMi().Keys;

            if (miGestor.ObtenerContraseniasCompartidasPorMi().Count == 0)
            {
                this.dataGridContraseñasCompartidas.Visible = true;
            }
            else
            {
                this.dataGridContraseñasCompartidas.DataSource = biso;
                HacerAlgunasColumnasNoVisiblesDelDataGridContraseñasCompartidas();
            }
        }

        private void HacerAlgunasColumnasNoVisiblesDelDataGridContraseñasCompartidas()
        {
            this.dataGridContraseñasCompartidas.Columns["ObtenerNivelSeguridad"].Visible = false;
            this.dataGridContraseñasCompartidas.Columns["ObtenerContraseña"].Visible = false;
            this.dataGridContraseñasCompartidas.Columns["TipoSitioOApp"].Visible = false;
            this.dataGridContraseñasCompartidas.Columns["DataBrench"].Visible = false;
            this.dataGridContraseñasCompartidas.Columns["Contraseña"].Visible = false;
            this.dataGridContraseñasCompartidas.Columns["Nota"].Visible = false;
        }

        private void CargarContraseñasCompartidasConmigo()
        {
            BindingSource biso2 = new BindingSource();
            GestorContraseniasCompartidas miGestor = usuario.GestorCompartirContrasenia;
            List<Credencial> listaCredencialesCompartidasConmigo = new List<Credencial>();

            foreach (var iterador in miGestor.ObtenerContraseniasCompartidasConmigo())
            {
                foreach (var iteradorAuxiliar in iterador.Value)
                    listaCredencialesCompartidasConmigo.Add(iteradorAuxiliar);
            }

            biso2.DataSource = listaCredencialesCompartidasConmigo;
            if (listaCredencialesCompartidasConmigo.Count > 0)
            {
                this.dataGridContraseñasCompartidasConmigo.DataSource = biso2;
                HacerAlgunasColumnasNoVisiblesDelDataGridContraseñasCompartidasConmigo();
            }
        }

        private void HacerAlgunasColumnasNoVisiblesDelDataGridContraseñasCompartidasConmigo()
        {
            this.dataGridContraseñasCompartidas.Columns["ObtenerNivelSeguridad"].Visible = false;
            this.dataGridContraseñasCompartidas.Columns["ObtenerContraseña"].Visible = false;
            this.dataGridContraseñasCompartidas.Columns["TipoSitioOApp"].Visible = false;
            this.dataGridContraseñasCompartidas.Columns["DataBrench"].Visible = false;
            this.dataGridContraseñasCompartidas.Columns["Contraseña"].Visible = false;
            this.dataGridContraseñasCompartidas.Columns["Nota"].Visible = false;
        }

        private void InterfazContraseñasCompartidas_Load(object sender, EventArgs e)
        {
            if (this.dataGridContraseñasCompartidasConmigo.Rows.Count > 0)
                this.dataGridContraseñasCompartidasConmigo.ClearSelection();

            if (this.dataGridContraseñasCompartidas.Rows.Count > 0)
                this.dataGridContraseñasCompartidas.ClearSelection();
        }

        private void buttonCompartir_Click(object sender, EventArgs e)
        {
            this.Close();
            InterfazCompartirContraseña interfazCompartirContraseña = 
                new InterfazCompartirContraseña(ref sistema, ref usuario);
            interfazCompartirContraseña.Show();
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu(ref sistema, ref usuario);
            menu.Show();
        }

        private void buttonVerUsuariosCompartidos_Click(object sender, EventArgs e)
        {
            GestorContraseniasCompartidas miGestor = usuario.GestorCompartirContrasenia;
            if (miGestor.ObtenerContraseniasCompartidasPorMi().Count == 0)
                MessageBox.Show("Error: No hay contraseñas compartidas aun");
            else
            {
                Credencial credencialSeleccionada = (Credencial)dataGridContraseñasCompartidas.
                    CurrentRow.DataBoundItem;

                if (credencialSeleccionada == null)
                    MessageBox.Show("Error: debe seleccionar una contrasenia primero");
                else
                    IrADejarDeCompartirContrasenia(ref credencialSeleccionada);
            }
        }

        private void IrADejarDeCompartirContrasenia(ref Credencial credencialSeleccionada)
        {
            InterfazDejarDeCompartirContrasenia interfazDejarDeCompartirContrasenias =
                new InterfazDejarDeCompartirContrasenia(ref sistema, ref usuario, ref credencialSeleccionada);
            this.Close();
            interfazDejarDeCompartirContrasenias.Show();
        }
    }
}
