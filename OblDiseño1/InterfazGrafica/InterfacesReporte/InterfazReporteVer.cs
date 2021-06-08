using InterfazDeModificarContrasenia = 
    InterfazGrafica.InterfacesDeContrasenias.InterfazDeModificarContrasenia;
using System.Collections.Generic;
using System.Windows.Forms;
using OblDiseño1.Entidades;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfacesReporte
{
    public partial class InterfazReporteVer : Form
    {
        private Usuario usuario;
        private Sistema sistema;
        private reporte reporte;

        private int nivelDeSeguridad;

        private const int nivelSeguridadVerdeOscuro = 5;
        private const int nivelSeguridadVerdeClaro = 4;
        private const int nivelSeguridadAmarillo = 3;
        private const int nivelSeguridadNaranja = 2;
        private const int nivelSeguridadRojo = 1;

        public InterfazReporteVer(ref Usuario usuario, ref Sistema sistema, 
            reporte reporte, int nivelDeSeguridad)
        {
            InitializeComponent();

            this.usuario = usuario;
            this.sistema = sistema;
            this.reporte = reporte;
            this.nivelDeSeguridad = nivelDeSeguridad;

            ActualizarLabel(nivelDeSeguridad);
            ActualizarDatosALaTabla();
        }

        private void ActualizarDatosALaTabla()
        {
            this.dataGridView_Contrasenias.Columns.Clear();
            this.dataGridView_Contrasenias.DataSource = null;

            List<string> unaLista = new List<string>();
            unaLista.Sort();

            reporte.duplasPorSeguridad[nivelDeSeguridad].unaListaCredenciales.Sort();
            BindingSource biso = new BindingSource();
            biso.DataSource = reporte.duplasPorSeguridad[nivelDeSeguridad].unaListaCredenciales;

            this.dataGridView_Contrasenias.DataSource = biso;

            ModificarDatosVisibles();
            ModificarCeldasReadonly();
            ModificarNombreDeColumnas();

            this.dataGridView_Contrasenias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ModificarDatosVisibles()
        {
            this.dataGridView_Contrasenias.Columns["ObtenerNivelSeguridad"].Visible = false;
            this.dataGridView_Contrasenias.Columns["ObtenerNivelSeguridad"].Visible = false;
            this.dataGridView_Contrasenias.Columns["ObtenerContraseña"].Visible = false;
            this.dataGridView_Contrasenias.Columns["TipoSitioOApp"].Visible = false;
            this.dataGridView_Contrasenias.Columns["DataBrench"].Visible = false;
            this.dataGridView_Contrasenias.Columns["Contraseña"].Visible = false;
            this.dataGridView_Contrasenias.Columns["Nota"].Visible = false;
        }

        private void ModificarNombreDeColumnas()
        {
            this.dataGridView_Contrasenias.Columns["NombreUsuario"].HeaderText = "Usuario";
            this.dataGridView_Contrasenias.Columns["NombreSitioApp"].HeaderText = "Sitio";
            this.dataGridView_Contrasenias.Columns["FechaUltimaModificacion"].HeaderText = 
                "Ultima Modificación";
            this.dataGridView_Contrasenias.Columns["Categoria"].HeaderText = "Categoría";
        }

        private void ModificarCeldasReadonly()
        {
            this.dataGridView_Contrasenias.Columns["FechaUltimaModificacion"].ReadOnly = true;
            this.dataGridView_Contrasenias.Columns["NombreSitioApp"].ReadOnly = true;
            this.dataGridView_Contrasenias.Columns["NombreUsuario"].ReadOnly = true;
            this.dataGridView_Contrasenias.Columns["Categoria"].ReadOnly = true;
        }

        private void ActualizarLabel(int nivelSeguridad)
        {
            switch (nivelDeSeguridad)
            {
                case nivelSeguridadRojo:
                    this.label_Titulo.Text = "Contraseñas nivel Rojo";
                    break;
                case nivelSeguridadNaranja:
                    this.label_Titulo.Text = "Contraseñas nivel Naranja";
                    break;
                case nivelSeguridadAmarillo:
                    this.label_Titulo.Text = "Contraseñas nivel Amarillo";
                    break;
                case nivelSeguridadVerdeClaro:
                    this.label_Titulo.Text = "Contraseñas nivel Verde Claro";
                    break;
                case nivelSeguridadVerdeOscuro:
                    this.label_Titulo.Text = "Contraseñas nivel Verde Oscuro";
                    break;
                default:
                    throw new ExepcionNivelDeSeguridadNoValido("La ventana IntrvazReporteVer " +
                        "recibio como parametro un nivel de seguridad no valido");
            }
        }

        private void button_Volver_Click(object sender, EventArgs e)
        {
            InterfazReporte interReporte = new InterfazReporte(ref usuario, ref sistema);
            interReporte.Show();
            this.Close();
        }

        private void btnModificarContrasenia_Click(object sender, EventArgs e)
        {
            if (0 < dataGridView_Contrasenias.RowCount)
            {
                Credencial duplaSeleccionada = (Credencial)dataGridView_Contrasenias.CurrentRow.
                    DataBoundItem;
                InterfazDeModificarContrasenia modContra = new InterfazDeModificarContrasenia
                    (ref usuario, ref sistema, duplaSeleccionada, "InterfazReporteVer");
                modContra.Show();
                this.Close();
            }
        }
    }
}
