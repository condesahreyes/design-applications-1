using Menu = InterfazGrafica.InterfacesMenu.Menu;
using OblDiseño1.ControladoresPorEntidad;
using OblDiseño1.Entidades;
using System.Windows.Forms;
using AccesoDatos;
using OblDiseño1;
using System;


namespace InterfazGrafica.InterfacesReporte
{
    public partial class InterfazReporte : Form
    {
        private Usuario usuario;
        private reporte reporte;

        private Reporte manejadorDeDatosReporte;

        private ControladorUsuario controladorUsuario;
        private IRepositorio<Usuario> usuarioRepositorio;

        private const int nivelSeguridadRojo = 1;
        private const int nivelSeguridadNaranja = 2;
        private const int nivelSeguridadAmarillo = 3;
        private const int nivelSeguridadVerdeClaro = 4;
        private const int nivelSeguridadVerdeOscuro = 5;

        public InterfazReporte(ref Usuario usuario)
        {
            InitializeComponent();
            CrearControladorUsuario();

            usuario = controladorUsuario.ObtenerUnUsuario(usuario);
            this.usuario = usuario;
            manejadorDeDatosReporte = new Reporte(usuario);

            this.reporte = manejadorDeDatosReporte.ObtenerReporteSeguridadContrasenias();

            ActualizarLables();
        }

        private void CrearControladorUsuario()
        {
            usuarioRepositorio = new UsuarioRepositorio();
            controladorUsuario = new ControladorUsuario(usuario, usuarioRepositorio);
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
            InterfazReporteVer reporteVer = new InterfazReporteVer(ref usuario, reporte, nivelSeguridadRojo);
            reporteVer.Show();
            this.Close();
        }

        private void button_VerNaranja_Click_1(object sender, EventArgs e)
        {
            InterfazReporteVer reporteVer = new InterfazReporteVer(ref usuario, reporte, nivelSeguridadNaranja);
            reporteVer.Show();
            this.Close();
        }

        private void button_VerAmarillo_Click_1(object sender, EventArgs e)
        {
            InterfazReporteVer reporteVer = new InterfazReporteVer(ref usuario, reporte, nivelSeguridadAmarillo);
            reporteVer.Show();
            this.Close();
        }

        private void button_VerVerdeClaro_Click_1(object sender, EventArgs e)
        {
            InterfazReporteVer reporteVer = new InterfazReporteVer(ref usuario, reporte, nivelSeguridadVerdeClaro);
            reporteVer.Show();
            this.Close();
        }

        private void button_VerVerdeOscuro_Click_1(object sender, EventArgs e)
        {
            InterfazReporteVer reporteVer = new InterfazReporteVer(ref usuario, reporte, nivelSeguridadVerdeOscuro);
            reporteVer.Show();
            this.Close();
        }

        private void button_VolverAMenu_Click_1(object sender, EventArgs e)
        {
            Menu menu = new Menu(ref usuario);
            menu.Show();
            this.Close();
        }

        private void button_PorCategoria_Click(object sender, EventArgs e)
        {
            this.Hide();
            InterfazReportePorCategoria porCat = new InterfazReportePorCategoria(this.usuario, reporte);
            porCat.Show();
        }
    }
}
