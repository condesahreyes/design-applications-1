using Menu = InterfazGrafica.InterfacesMenu.Menu;
using System.Windows.Forms;
using OblDiseño1;

namespace InterfazGrafica.InterfacesDeContrasenias
{
    
    public partial class InterfazContrasenia : Form
    {
        private Usuario usuario;
        private Sistema sistema;

        public InterfazContrasenia(ref Usuario usuario, ref Sistema sistema)
        {
            InitializeComponent();

            this.usuario = usuario;
            this.sistema = sistema;

            CargarCredenciales();
        }

        private void CargarCredenciales()
        {
            this.dataGridView_ListaDuplas.Columns.Clear();
            this.dataGridView_ListaDuplas.DataSource = null;

            usuario.ObtenerCredenciales().Sort();
            BindingSource biso = new BindingSource();
            biso.DataSource = usuario.ObtenerCredenciales();

            this.dataGridView_ListaDuplas.DataSource = biso;

            ModificarACamposSoloLectura();
            ModificarACamposNoVisibles();
            ModificarHeaderText();

            this.dataGridView_ListaDuplas.RowHeadersVisible = false;
            this.dataGridView_ListaDuplas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ModificarACamposNoVisibles()
        {
            this.dataGridView_ListaDuplas.Columns["ObtenerNivelSeguridad"].Visible = false;
            this.dataGridView_ListaDuplas.Columns["ObtenerContraseña"].Visible = false;
            this.dataGridView_ListaDuplas.Columns["TipoSitioOApp"].Visible = false;
            this.dataGridView_ListaDuplas.Columns["DataBrench"].Visible = false;
            this.dataGridView_ListaDuplas.Columns["Contraseña"].Visible = false;
            this.dataGridView_ListaDuplas.Columns["Nota"].Visible = false;
        }

        private void ModificarHeaderText()
        {
            this.dataGridView_ListaDuplas.Columns["NombreUsuario"].HeaderText = "Usuario";
            this.dataGridView_ListaDuplas.Columns["NombreSitioApp"].HeaderText = "Sitio";
            this.dataGridView_ListaDuplas.Columns["FechaUltimaModificacion"].HeaderText = "Ultima Modificación";
            this.dataGridView_ListaDuplas.Columns["Categoria"].HeaderText = "Categoría";
        }

        private void ModificarACamposSoloLectura()
        {
            this.dataGridView_ListaDuplas.Columns["NombreUsuario"].ReadOnly = true;
            this.dataGridView_ListaDuplas.Columns["NombreSitioApp"].ReadOnly = true;
            this.dataGridView_ListaDuplas.Columns["FechaUltimaModificacion"].ReadOnly = true;
            this.dataGridView_ListaDuplas.Columns["Categoria"].ReadOnly = true;
        }

        private void btnContraseniaVolverMenu_Click(object sender, System.EventArgs e)
        {
            this.Close();
            Menu menu = new Menu(ref sistema, ref usuario);
            menu.Show();
        }

        private void btnAgregarContrasenia_Click(object sender, System.EventArgs e)
        {
            this.Close();
            InterfazAgregarContrasenia agregarContrasenia = new InterfazAgregarContrasenia(ref sistema, ref usuario);
            agregarContrasenia.Show();
        }

        private void btnModificarContrasenia_Click(object sender, System.EventArgs e)
        {
            if (0 < dataGridView_ListaDuplas.RowCount)
            {
                Credencial duplaSeleccionada = (Credencial)dataGridView_ListaDuplas.CurrentRow.DataBoundItem;

                InterfazDeModificarContrasenia interfazModiicar = new 
                    InterfazDeModificarContrasenia(ref usuario, ref sistema, duplaSeleccionada, "InterfazContrasenia");

                interfazModiicar.Show();
                this.Close();
            }
            else
                MessageBox.Show("No hay contraseñas para modificar");
        }

        private void btnEliminarContrasenia_Click(object sender, System.EventArgs e)
        {
            if (0 < dataGridView_ListaDuplas.RowCount && ConfirmarEliminacion())
            {
                EliminarContrasenia();
                CargarCredenciales();
                
            }
            else if (0 == dataGridView_ListaDuplas.RowCount)
                MessageBox.Show("No hay contraseñas para eliminar");
        }

        private void EliminarContrasenia()
        {
            Credencial duplaSeleccionada = (Credencial)dataGridView_ListaDuplas.CurrentRow.DataBoundItem;
            usuario.RemoverDupla(duplaSeleccionada);
            MessageBox.Show("Se elimino correctamente");
        }

        private bool ConfirmarEliminacion()
        {
            DialogResult resultado = MessageBox.Show("Esta seguro que desea eliminar esta contraseña", "", 
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

            return (resultado==DialogResult.Yes)? true : false;
        }
    }
}
