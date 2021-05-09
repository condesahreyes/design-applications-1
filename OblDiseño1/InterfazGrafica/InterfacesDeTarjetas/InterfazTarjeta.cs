using OblDiseño1;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Menu = InterfazGrafica.InterfacesMenu.Menu;

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


        private void InterfazTarjeta_Load(object sender, EventArgs e)
        {

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
            else
                MessageBox.Show("Error, no hay tarjetas para modificar");
        }

        private void btnEliminarTarjeta_Click(object sender, EventArgs e)
        {
            if (dataGridTarjetas.RowCount > 0)
            {
                Tarjeta tarjetaSeleccionada = (Tarjeta)dataGridTarjetas.CurrentRow.DataBoundItem;
                
                if (tarjetaSeleccionada == null)
                    MessageBox.Show("Error, debe seleccionar una tarjeta");
                else
                {


                    //Posible solucion, pero tira un error 
                    //MessageBoxButtons botones = MessageBoxButtons.YesNo;
                    //DialogResult dr = MessageBox.Show("¿Estas seguro que deseas eliminar esta Tarjeta?","", botones, MessageBoxIcon.Exclamation);

                    //if (dr == DialogResult.Yes)
                    //{
                    //    this.usuario.EliminarTarjeta(tarjetaSeleccionada);
                    //}
                    //CargarListaTarjetas(ref usuario, ref sistema);

                    InterfazEliminarTarjeta eliminarTarjeta = new InterfazEliminarTarjeta
                        (ref sistema, ref usuario, ref tarjetaSeleccionada);
                    this.Close();
                    eliminarTarjeta.Show();
                }
            }
            else
                MessageBox.Show("Error, no hay tarjetas para modificar");

        }

    }
}
