using Menu = InterfazGrafica.InterfacesMenu.Menu;
using OblDiseño1.ControladoresPorEntidad;
using System.Collections.Generic;
using System.Windows.Forms;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfacesDeTarjetas
{
    public partial class InterfazTarjeta : Form
    {
        private Usuario usuario;

        private ControladorTarjeta controladorTarjeta;


        public InterfazTarjeta(ref Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;

            CrearManejadoresTarjeta();
            CargarListaTarjetas();
            ModificarNombreDeColumnasDelDataGrid();
        }

        private void CrearManejadoresTarjeta()
        {
            controladorTarjeta = new ControladorTarjeta(this.usuario);
        }

        private void CargarListaTarjetas()
        {
            List<Tarjeta> misTarjetas = controladorTarjeta.ObtenerTodasMisTarjetas();
            if (misTarjetas.Count > 0)
                misTarjetas.Sort();
            dataGridTarjetas.DataSource = misTarjetas;
            dataGridTarjetas.Columns["Categoria"].DisplayIndex = 0;
            dataGridTarjetas.Columns["NotaOpcional"].Visible = false;
            dataGridTarjetas.Columns["CodigoSeguridad"].Visible = false;
        }

        private void ModificarNombreDeColumnasDelDataGrid()
        {
            dataGridTarjetas.Columns["FechaVencimiento"].HeaderText = "Fecha Vencimiento";
            dataGridTarjetas.Columns["Numero"].HeaderText = "Número";
            dataGridTarjetas.Columns["Categoria"].HeaderText = "Categoría";
        }

        private void btnTarjetasVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu(ref usuario);
            menu.Show();
        }

        private void btnAgregarTarjeta_Click(object sender, EventArgs e)
        {
            this.Close();
            InterfazAgregarTarjeta interfazAgregar = new InterfazAgregarTarjeta(ref usuario);
            interfazAgregar.Show();
        }

        private void btnModificarTarjeta_Click(object sender, EventArgs e)
        {
            if (dataGridTarjetas.RowCount > 0)
                AModificarTarjetaSeleccionada();
            else
                MessageBox.Show("Error, no hay tarjetas para modificar");
        }

        private void AModificarTarjetaSeleccionada()
        {
            Tarjeta tarjetaSeleccionada = (Tarjeta)dataGridTarjetas.CurrentRow.DataBoundItem;

            if (tarjetaSeleccionada == null)
                MessageBox.Show("Error, debe seleccionar una tarjeta");
            else
            {
                this.Hide();
                InterfazModificarTarjeta modificarTarjeta = new InterfazModificarTarjeta
                    (ref usuario, ref tarjetaSeleccionada);
                modificarTarjeta.Show();
            }
        }

        private void btnEliminarTarjeta_Click(object sender, EventArgs e)
        {
            if (dataGridTarjetas.RowCount > 0)
                EliminarTarjetaSeleccionada();
            else
                MessageBox.Show("Error, no hay tarjetas para modificar");
        }

        private void EliminarTarjetaSeleccionada()
        {
            Tarjeta tarjetaSeleccionada = (Tarjeta)dataGridTarjetas.CurrentRow.DataBoundItem;

            if (tarjetaSeleccionada == null)
                MessageBox.Show("Error, debe seleccionar una tarjeta");
            else
            {
                InterfazEliminarTarjeta eliminarTarjeta = new InterfazEliminarTarjeta
                    (ref usuario, ref tarjetaSeleccionada);
                eliminarTarjeta.Show();
            }
        }
    }
}
