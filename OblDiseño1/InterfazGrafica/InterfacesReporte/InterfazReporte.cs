using Menu = InterfazGrafica.InterfacesMenu.Menu;
using System.Windows.Forms;
using OblDiseño1.Entidades;
using OblDiseño1;
using System;
using AccesoDatos;
using OblDiseño1.ControladoresPorFuncionalidad;
using System.Collections.Generic;

namespace InterfazGrafica.InterfacesReporte
{
    public partial class InterfazReporte : Form
    {
        private Usuario usuario;
        private Sistema sistema;
        private reporte reporte;

        private Reporte manejadorDeDatosReporte;

        private const int nivelSeguridadRojo = 1;
        private const int nivelSeguridadNaranja = 2;
        private const int nivelSeguridadAmarillo = 3;
        private const int nivelSeguridadVerdeClaro = 4;
        private const int nivelSeguridadVerdeOscuro = 5;

        public InterfazReporte(ref Usuario usuario, ref Sistema sistema)
        {
            InitializeComponent();

            this.usuario = usuario;
            this.sistema = sistema;
            ActualizarDatosUsuario();
            manejadorDeDatosReporte = new Reporte(usuario);

            this.reporte = manejadorDeDatosReporte.ObtenerReporteSeguridadContrasenias();

            ActualizarLables();
        }

        public void ActualizarDatosUsuario()
        {

            this.usuario.BorrarListas();

            ControladorObtener controladorObtener = new ControladorObtener();
            CredencialRepositorio credencialRepositorio = new CredencialRepositorio(usuario);
            CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio(usuario);

            List<Credencial> credenciales = controladorObtener.ObtenerCredenciales(credencialRepositorio);
            if (credenciales != null)
            {
                foreach (var credencial in credenciales)
                    usuario.AgregarCredencial(credencial);
            }


            List<Categoria> categorias = controladorObtener.ObtenerCategorias(categoriaRepositorio);
            if (categorias != null)
            {
                foreach (var categoria in categorias)
                    usuario.AgregarCategoria(categoria);
            }
        }

        public void ActualizarLables()
        {
            this.label_CantidadRojo.Text = "" + 
                reporte.duplasPorSeguridad[nivelSeguridadRojo].cantidad;
            this.label_CantidadNaranja.Text = "" + 
                reporte.duplasPorSeguridad[nivelSeguridadNaranja].cantidad;
            this.label_CantidadAmarillo.Text = "" + 
                reporte.duplasPorSeguridad[nivelSeguridadAmarillo].cantidad;
            this.label_CantidadVerdeClaro.Text = "" + 
                reporte.duplasPorSeguridad[nivelSeguridadVerdeClaro].cantidad;
            this.label_CantidadVerdeOscuro.Text = "" + 
                reporte.duplasPorSeguridad[nivelSeguridadVerdeOscuro].cantidad;
        }

        private void button_VerRojo_Click_1(object sender, EventArgs e)
        {
            InterfazReporteVer reporteVer = new InterfazReporteVer(ref usuario, ref sistema,
                reporte, nivelSeguridadRojo);
            reporteVer.Show();
            this.Close();
        }

        private void button_VerNaranja_Click_1(object sender, EventArgs e)
        {
            InterfazReporteVer reporteVer = new InterfazReporteVer(ref usuario, ref sistema,
                reporte, nivelSeguridadNaranja);
            reporteVer.Show();
            this.Close();
        }

        private void button_VerAmarillo_Click_1(object sender, EventArgs e)
        {
            InterfazReporteVer reporteVer = new InterfazReporteVer(ref usuario, ref sistema,
                reporte, nivelSeguridadAmarillo);
            reporteVer.Show();
            this.Close();
        }

        private void button_VerVerdeClaro_Click_1(object sender, EventArgs e)
        {
            InterfazReporteVer reporteVer = new InterfazReporteVer(ref usuario, ref sistema, 
                reporte, nivelSeguridadVerdeClaro);
            reporteVer.Show();
            this.Close();
        }

        private void button_VerVerdeOscuro_Click_1(object sender, EventArgs e)
        {
            InterfazReporteVer reporteVer = new InterfazReporteVer(ref usuario, ref sistema, 
                reporte, nivelSeguridadVerdeOscuro);
            reporteVer.Show();
            this.Close();
        }

        private void button_VolverAMenu_Click_1(object sender, EventArgs e)
        {
            Menu menu = new Menu(ref sistema, ref usuario);
            menu.Show();
            this.Close();
        }

        private void button_PorCategoria_Click(object sender, EventArgs e)
        {
            this.Hide();
            InterfazReportePorCategoria porCat = new InterfazReportePorCategoria(usuario, sistema, reporte);
            porCat.Show();
        }
    }
}
