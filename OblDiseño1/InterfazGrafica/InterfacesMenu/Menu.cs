using InterfazGrafica.InterfazCompartirContraseñas;
using InterfazGrafica.InterfacesDeContrasenias;
using InterfazGrafica.InterfacesDataBreaches;
using InterfazGrafica.InterfacesDeTarjetas;
using OblDiseño1.ControladoresPorEntidad;
using InterfazGrafica.InterfazCategoria;
using InterfazGrafica.InterfacesReporte;
using InterfazGrafica.InterfazIngreso;
using System.Windows.Forms;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfacesMenu
{
    public partial class Menu : Form
    {
        private Usuario usuario;

        private ControladorCategoria controladorCategoria;

        private readonly string msgErrorDebeCrearCategoria = "Error, primero " +
            "se debe registrar una Categoría para acceder a esta opción.";

        public Menu(ref Usuario usuario)
        {
            this.usuario = usuario;

            CrearManejadoresCategoria();
            InitializeComponent();
        }

        private void CrearManejadoresCategoria()
        {
            controladorCategoria = new ControladorCategoria(this.usuario);
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            this.Hide();
            InterfazCategorias categoria = new InterfazCategorias(ref this.usuario);
            categoria.Show();
        }

        private void btnContrasenias_Click(object sender, EventArgs e)
        {
            if (controladorCategoria.ObtenerCategorias().Count > 0)
            {
                this.Hide();
                InterfazContrasenia contrasenias = new InterfazContrasenia(ref usuario);
                contrasenias.Show();
            }
            else
                MessageBox.Show(msgErrorDebeCrearCategoria);
        }

        private void btnTarjetas_Click(object sender, EventArgs e)
        {
            if (controladorCategoria.ObtenerCategorias().Count > 0)
                IrAPantallaTarjetas();
            else
                MessageBox.Show(msgErrorDebeCrearCategoria);
        }

        private void IrAPantallaTarjetas()
        {
            this.Hide();
            InterfazTarjeta tarjeta = new InterfazTarjeta(ref usuario);
            tarjeta.Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            InterfazIngresoSistema login = new InterfazIngresoSistema();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            InterfazCambioContrasenia cambioContrasenia = new InterfazCambioContrasenia();
            cambioContrasenia.Show();
        }

        private void btnDataBreaches_Click(object sender, EventArgs e)
        {
            this.Close();
            InterfazHistoricosDataBreach dataBreach = new InterfazHistoricosDataBreach(ref usuario);
            dataBreach.Show();

        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            InterfazReporte reporte = new InterfazReporte(ref usuario);
            reporte.Show();
            this.Close();
        }

        private void btnCompartirContrasenia_Click_1(object sender, EventArgs e)
        {
                this.Close();
                InterfazContraseñasCompartidas interfazContraseñas = new
                    InterfazContraseñasCompartidas(ref usuario);
                interfazContraseñas.Show();
        }
    }
}
