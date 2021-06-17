using OblDiseño1.Entidades;
using System.Windows.Forms;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfacesReporte
{
    public partial class InterfazReportePorCategoria : Form
    {
        private const string categoriaVerdeOscuro = "Verde Oscuro";
        private const string categoriaVerdeClaro = "Verde Claro";
        private const string categoriaAmarillo = "Amarillo";
        private const string categoriaNaranja = "Naranja";
        private const string categoriaRojo = "Rojo";

        private const int nivelSeguridadVerdeOscuro = 5;
        private const int nivelSeguridadVerdeClaro = 4;
        private const int nivelSeguridadAmarillo = 3;
        private const int nivelSeguridadNaranja = 2;
        private const int nivelSeguridadRojo = 1;
 
        private Usuario usuario;
        private reporte reporte;

        public InterfazReportePorCategoria(Usuario usu, reporte rep)
        {
            InitializeComponent();

            this.usuario = usu;
            this.reporte = rep;

            CrearGraficas();
        }

        private void CrearGraficas()
        {
            foreach (Categoria cat in usuario.ObtenerCategorias())
            {
                this.chart1.Series[categoriaRojo].Points.AddXY(cat.Nombre, 
                    reporte.duplasPorCategoria[cat.Nombre][nivelSeguridadRojo]);
                this.chart1.Series[categoriaNaranja].Points.AddXY(cat.Nombre, 
                    reporte.duplasPorCategoria[cat.Nombre][nivelSeguridadNaranja]);
                this.chart1.Series[categoriaAmarillo].Points.AddXY(cat.Nombre, 
                    reporte.duplasPorCategoria[cat.Nombre][nivelSeguridadAmarillo]);
                this.chart1.Series[categoriaVerdeClaro].Points.AddXY(cat.Nombre, 
                    reporte.duplasPorCategoria[cat.Nombre][nivelSeguridadVerdeClaro]);
                this.chart1.Series[categoriaVerdeOscuro].Points.AddXY(cat.Nombre, 
                    reporte.duplasPorCategoria[cat.Nombre][nivelSeguridadVerdeOscuro]);
            }
        }

        private void btnVolverAMenu_Click(object sender, EventArgs e)
        {
            InterfazReporte ventanaReporte = new InterfazReporte(ref usuario);
            ventanaReporte.Show();
            this.Close();
        }
    }
}
