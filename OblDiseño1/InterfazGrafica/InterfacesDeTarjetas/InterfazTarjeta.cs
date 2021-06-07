using Menu = InterfazGrafica.InterfacesMenu.Menu;
using System.Windows.Forms;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfacesDeTarjetas
{
    public partial class InterfazTarjeta : Form
    {
        private Usuario usuario;
        private Sistema sistema;

        public InterfazTarjeta(ref Usuario usuario, ref Sistema sistema)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.sistema = sistema;
            CargarListaTarjetas(ref usuario, ref sistema);
        }

        private void CargarListaTarjetas(ref Usuario usuario, ref Sistema sistema)
        {
            if (usuario.ObtenerTarjetas().Count > 0)
                usuario.ObtenerTarjetas().Sort();
                dataGridTarjetas.DataSource = usuario.ObtenerTarjetas();
                dataGridTarjetas.Columns["Categoria"].DisplayIndex = 0;
                dataGridTarjetas.Columns["NotaOpcional"].Visible = false;
                dataGridTarjetas.Columns["CodigoSeguridad"].Visible = false;
        }

        private void btnTarjetasVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu(ref sistema, ref usuario);
            menu.Show();
        }

        private void btnAgregarTarjeta_Click(object sender, EventArgs e)
        {
                this.Close();
                InterfazAgregarTarjeta interfazAgregar = new InterfazAgregarTarjeta(ref usuario, ref sistema);
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
                    (ref sistema, ref usuario, ref tarjetaSeleccionada);
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
                    (ref sistema, ref usuario, ref tarjetaSeleccionada);
                this.Close();
                eliminarTarjeta.Show();
            }
        }

    }
}
