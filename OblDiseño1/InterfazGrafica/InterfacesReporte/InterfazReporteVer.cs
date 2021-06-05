using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OblDiseño1;
using OblDiseño1.Entidades;
using Interfaz_ModificarContrasenia = InterfazGrafica.InterfacesDeContrasenias.Interfaz_ModificarContrasenia;

namespace InterfazGrafica.InterfacesReporte
{
    public partial class InterfazReporteVer : Form
    {
        Usuario usuario;
        Sistema sistema;
        reporte reporte;
        int nivelDeSeguridad;

        const int nivelSeguridadRojo = 1;
        const int nivelSeguridadNaranja = 2;
        const int nivelSeguridadAmarillo = 3;
        const int nivelSeguridadVerdeClaro = 4;
        const int nivelSeguridadVerdeOscuro = 5;

        public InterfazReporteVer(ref Usuario usuario, ref Sistema sistema, reporte reporte, int nivelDeSeguridad)
        {
            this.usuario = usuario;
            this.sistema = sistema;
            this.reporte = reporte;
            this.nivelDeSeguridad = nivelDeSeguridad;
            InitializeComponent();
            ActualizarLabel(nivelDeSeguridad);
            ActualizarDatosALaTabla();
        }

        private void ActualizarDatosALaTabla()
        {
            this.dataGridView_Contrasenias.Columns.Clear();
            this.dataGridView_Contrasenias.DataSource = null;

            List<string> unaLista = new List<string>();
            unaLista.Sort();

            reporte.duplasPorSeguridad[nivelDeSeguridad].unaListaDuplas.Sort();
            BindingSource biso = new BindingSource();
            biso.DataSource = reporte.duplasPorSeguridad[nivelDeSeguridad].unaListaDuplas;

            this.dataGridView_Contrasenias.DataSource = biso;

            this.dataGridView_Contrasenias.Columns["TipoSitioOApp"].Visible = false;
            this.dataGridView_Contrasenias.Columns["NivelSeguridadContrasenia"].Visible = false;
            this.dataGridView_Contrasenias.Columns["DataBrench"].Visible = false;
            this.dataGridView_Contrasenias.Columns["Nota"].Visible = false;

            this.dataGridView_Contrasenias.Columns["NombreUsuario"].HeaderText = "Usuario";
            this.dataGridView_Contrasenias.Columns["Contrasenia"].HeaderText = "Contraseña";
            this.dataGridView_Contrasenias.Columns["NombreSitioApp"].HeaderText = "Sitio";
            this.dataGridView_Contrasenias.Columns["FechaUltimaModificacion"].HeaderText = "Ultima Modificacion";
            this.dataGridView_Contrasenias.Columns["Categoria"].HeaderText = "Categoria";

            this.dataGridView_Contrasenias.Columns["NombreUsuario"].ReadOnly = true;
            this.dataGridView_Contrasenias.Columns["Contrasenia"].ReadOnly = true;
            this.dataGridView_Contrasenias.Columns["NombreSitioApp"].ReadOnly = true;
            this.dataGridView_Contrasenias.Columns["FechaUltimaModificacion"].ReadOnly = true;
            this.dataGridView_Contrasenias.Columns["Categoria"].ReadOnly = true;

            this.dataGridView_Contrasenias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                    throw new ExepcionNivelDeSeguridadNoValido("La ventana IntrvazReporteVer recibio como parametro un nivel de seguridad no valido");
                    break;
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
                Dupla_UsuarioContrasenia duplaSeleccionada = (Dupla_UsuarioContrasenia)dataGridView_Contrasenias.CurrentRow.DataBoundItem;
                Interfaz_ModificarContrasenia modContra = new Interfaz_ModificarContrasenia(ref usuario, ref sistema, duplaSeleccionada, "InterfazReporteVer");
                modContra.Show();
                this.Close();
            }
        }
    }
}
