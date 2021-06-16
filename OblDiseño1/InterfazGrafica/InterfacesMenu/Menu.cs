using InterfazGrafica.InterfazCompartirContraseñas;
using InterfazGrafica.InterfacesDeContrasenias;
using OblDiseño1.ControladoresPorFuncionalidad;
using InterfazGrafica.InterfacesDeTarjetas;
using InterfazGrafica.InterfazDataBreaches;
using InterfazGrafica.InterfazCategoria;
using InterfazGrafica.InterfacesReporte;
using InterfazGrafica.InterfazIngreso;
using System.Windows.Forms;
using AccesoDatos;
using OblDiseño1;
using System;
using AccesoDatos;
using System.Collections.Generic;

namespace InterfazGrafica.InterfacesMenu
{
    public partial class Menu : Form
    {
        private Sistema sistema;
        private Usuario usuario;
        private ControladorObtener controladorObtener;
        private CategoriaRepositorio categoriaRepo;
        private CredencialRepositorio credencialRepo;

        private readonly string msgErrorDebeCrearCategoria = "Error, primero " +
            "se debe registrar una Categoría para acceder a esta opción.";

        public Menu(ref Sistema sistema, ref Usuario usuario)
        {
            this.usuario = usuario;
            this.sistema = sistema;
            controladorObtener = new ControladorObtener();
            categoriaRepo = new CategoriaRepositorio(this.usuario);
            credencialRepo = new CredencialRepositorio(this.usuario);


            InitializeComponent();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            this.Hide();
            InterfazCategorias categoria = new InterfazCategorias(ref this.usuario, ref this.sistema);
            categoria.Show();
        }

        private void btnContrasenias_Click(object sender, EventArgs e)
        {
            if (controladorObtener.ObtenerCategorias(categoriaRepo).Count > 0)
            {
                this.Hide();
                InterfazContrasenia contrasenias = new InterfazContrasenia(ref usuario, ref sistema);
                contrasenias.Show();
            }
            else
                MessageBox.Show(msgErrorDebeCrearCategoria);
        }

        private void btnTarjetas_Click(object sender, EventArgs e)
        {
            if (controladorObtener.ObtenerCategorias(categoriaRepo).Count > 0)
                IrAPantallaTarjetas();
            else
                MessageBox.Show(msgErrorDebeCrearCategoria);
        }

        private void IrAPantallaTarjetas()
        {
            this.Hide();
            InterfazTarjeta tarjeta = new InterfazTarjeta(ref usuario, ref sistema);
            tarjeta.Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            InterfazIngresoSistema login = new InterfazIngresoSistema(ref sistema);
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            InterfazCambioContrasenia cambioContrasenia = new InterfazCambioContrasenia(ref sistema);
            cambioContrasenia.Show();
        }

        private void btnDataBreaches_Click(object sender, EventArgs e)
        {
            this.Close();
            InterfazChequeoDataBreaches dataBreaches = new InterfazChequeoDataBreaches(ref sistema, ref usuario);
            dataBreaches.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            InterfazReporte reporte = new InterfazReporte(ref usuario, ref sistema);
            reporte.Show();
            this.Close();
        }

        private void btnCompartirContrasenia_Click_1(object sender, EventArgs e)
        {
            if (controladorObtener.ObtenerCredenciales(credencialRepo).Count > 0)
            {
                this.Close();
                InterfazContraseñasCompartidas interfazContraseñas = new
                    InterfazContraseñasCompartidas(ref sistema, ref usuario);
                interfazContraseñas.Show();
            }
            else
                MessageBox.Show("No existen credenciales registradas aun");
            
        }
    }
}
