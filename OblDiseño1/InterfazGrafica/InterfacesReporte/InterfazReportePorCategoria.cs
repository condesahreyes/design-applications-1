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
using InterfazReporte = InterfazGrafica.InterfacesReporte.InterfazReporte;

namespace InterfazGrafica.InterfacesReporte
{
    public partial class InterfazReportePorCategoria : Form
    {
        const string categoriaRojo = "Rojo";
        const string categoriaNaranja = "Naranja";
        const string categoriaAmarillo = "Amarillo";
        const string categoriaVerdeClaro = "Verde Claro";
        const string categoriaVerdeOscuro = "Verde Oscuro";
        const int nivelSeguridadRojo = 1;
        const int nivelSeguridadNaranja = 2;
        const int nivelSeguridadAmarillo = 3;
        const int nivelSeguridadVerdeClaro = 4;
        const int nivelSeguridadVerdeOscuro = 5;


        private Usuario usuario;
        private Sistema sistema;
        private reporte reporte;

        public InterfazReportePorCategoria(Usuario usu, Sistema sist, reporte rep)
        {
            this.usuario = usu;
            this.sistema = sist;
            this.reporte = rep;
            InitializeComponent();
            CrearGraficas();
        }

        private void CrearGraficas()
        {

            foreach (Categoria cat in usuario.ObtenerCategorias())
            {
                this.chart1.Series[categoriaRojo].Points.AddXY(cat.Nombre, reporte.duplasPorCategoria[cat.Nombre][nivelSeguridadRojo]);
                this.chart1.Series[categoriaNaranja].Points.AddXY(cat.Nombre, reporte.duplasPorCategoria[cat.Nombre][nivelSeguridadNaranja]);
                this.chart1.Series[categoriaAmarillo].Points.AddXY(cat.Nombre, reporte.duplasPorCategoria[cat.Nombre][nivelSeguridadAmarillo]);
                this.chart1.Series[categoriaVerdeClaro].Points.AddXY(cat.Nombre, reporte.duplasPorCategoria[cat.Nombre][nivelSeguridadVerdeClaro]);
                this.chart1.Series[categoriaVerdeOscuro].Points.AddXY(cat.Nombre, reporte.duplasPorCategoria[cat.Nombre][nivelSeguridadVerdeOscuro]);
            }

        }

        private void InterfazReportePorCategoria_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InterfazReporte ventanaReporte = new InterfazReporte(ref usuario, ref sistema);
            ventanaReporte.Show();
            this.Close();
        }
    }
}
