using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OblDiseño1;
using Menu = InterfazGrafica.InterfacesMenu.Menu;
using InterfazReportePorCategoria = InterfazGrafica.InterfacesReporte.InterfazReportePorCategoria;

namespace InterfazGrafica.InterfacesReporte
{
    public partial class InterfazReporte : Form
    {

        private Usuario usuario;
        private Sistema sistema;
        private reporte reporte;

        const int nivelSeguridadRojo = 1;
        const int nivelSeguridadNaranja = 2;
        const int nivelSeguridadAmarillo = 3;
        const int nivelSeguridadVerdeClaro = 4;
        const int nivelSeguridadVerdeOscuro = 5;

        public InterfazReporte(ref Usuario usuario, ref Sistema sistema)
        {
            this.usuario = usuario;
            this.sistema = sistema;
            this.reporte = usuario.ObtenerReporteSeguridadContrasenias();

            InitializeComponent();
            ActualizarLables();
        }

        public void ActualizarLables() 
        {
            // 1->Rojo, 2->Naranja, 3->Amarillo, 4->VerdeClaro, 5->VerdeOscuro
            this.label_CantidadRojo.Text = "" + reporte.duplasPorSeguridad[1].cantidad;
            this.label_CantidadNaranja.Text = "" + reporte.duplasPorSeguridad[2].cantidad;
            this.label_CantidadAmarillo.Text = "" + reporte.duplasPorSeguridad[3].cantidad;
            this.label_CantidadVerdeClaro.Text = "" + reporte.duplasPorSeguridad[4].cantidad;
            this.label_CantidadVerdeOscuro.Text = "" + reporte.duplasPorSeguridad[5].cantidad;
        }

        private void button_VerRojo_Click_1(object sender, EventArgs e)
        {
            InterfazReporteVer reporVer = new InterfazReporteVer(ref usuario, ref sistema, reporte, nivelSeguridadRojo);
            reporVer.Show();
            this.Close();
        }
        
        private void button_VerNaranja_Click_1(object sender, EventArgs e)
        {
            InterfazReporteVer reporVer = new InterfazReporteVer(ref usuario, ref sistema, reporte, nivelSeguridadNaranja);
            reporVer.Show();
            this.Close();
        }

        private void button_VerAmarillo_Click_1(object sender, EventArgs e)
        {
            InterfazReporteVer reporVer = new InterfazReporteVer(ref usuario, ref sistema, reporte, nivelSeguridadAmarillo);
            reporVer.Show();
            this.Close();
        }

        private void button_VerVerdeClaro_Click_1(object sender, EventArgs e)
        {
            InterfazReporteVer reporVer = new InterfazReporteVer(ref usuario, ref sistema, reporte, nivelSeguridadVerdeClaro);
            reporVer.Show();
            this.Close();
        }

        private void button_VerVerdeOscuro_Click_1(object sender, EventArgs e)
        {
            InterfazReporteVer reporVer = new InterfazReporteVer(ref usuario, ref sistema, reporte, nivelSeguridadVerdeOscuro);
            reporVer.Show();
            this.Close();
        }

        private void button_Aceptar_Click_1(object sender, EventArgs e)
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
