﻿using OblDiseño1;
using System.Windows.Forms;
using Menu = InterfazGrafica.InterfacesMenu.Menu;
using System.Collections.Generic;

namespace InterfazGrafica.InterfacesDeContrasenias
{
    public partial class InterfazContrasenia : Form
    {
        Usuario usuario;
        Sistema sistema;
        public InterfazContrasenia(ref Usuario usuario, ref Sistema sistema)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.sistema = sistema;
            CargarDuplas();
        }


        private void CargarDuplas()
        {
            this.dataGridView_ListaDuplas.Columns.Clear();
            this.dataGridView_ListaDuplas.DataSource = null;

            usuario.ObtenerDuplas().Sort();
            BindingSource biso = new BindingSource();
            biso.DataSource = usuario.ObtenerDuplas();

            this.dataGridView_ListaDuplas.DataSource = biso;

            this.dataGridView_ListaDuplas.Columns["TipoSitioOApp"].Visible = false;
            this.dataGridView_ListaDuplas.Columns["NivelSeguridadContrasenia"].Visible = false;
            this.dataGridView_ListaDuplas.Columns["DataBrench"].Visible = false;
            this.dataGridView_ListaDuplas.Columns["Nota"].Visible = false;
            this.dataGridView_ListaDuplas.Columns["Contrasenia"].Visible = false;

            this.dataGridView_ListaDuplas.Columns["NombreUsuario"].HeaderText = "Usuario";
            this.dataGridView_ListaDuplas.Columns["NombreSitioApp"].HeaderText = "Sitio";
            this.dataGridView_ListaDuplas.Columns["FechaUltimaModificacion"].HeaderText = "Ultima Modificacion";
            this.dataGridView_ListaDuplas.Columns["Categoria"].HeaderText = "Categoria";

            this.dataGridView_ListaDuplas.Columns["NombreUsuario"].ReadOnly = true;
            this.dataGridView_ListaDuplas.Columns["NombreSitioApp"].ReadOnly = true;
            this.dataGridView_ListaDuplas.Columns["FechaUltimaModificacion"].ReadOnly = true;
            this.dataGridView_ListaDuplas.Columns["Categoria"].ReadOnly = true;

            this.dataGridView_ListaDuplas.RowHeadersVisible = false;
            this.dataGridView_ListaDuplas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnContraseniaVolverMenu_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu(ref sistema, ref usuario);
            menu.Show();
        }

        private void btnAgregarContrasenia_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            InterfazAgregarContrasenia agregarContrasenia = new InterfazAgregarContrasenia(ref sistema, ref usuario);
            agregarContrasenia.Show();
        }

        private void btnModificarContrasenia_Click(object sender, System.EventArgs e)
        {
            if (0 < dataGridView_ListaDuplas.RowCount)
            {
                Dupla_UsuarioContrasenia duplaSeleccionada = (Dupla_UsuarioContrasenia)dataGridView_ListaDuplas.CurrentRow.DataBoundItem;
                Interfaz_ModificarContrasenia intModiContra = new Interfaz_ModificarContrasenia(ref usuario, ref sistema, duplaSeleccionada, "InterfazContrasenia");
                intModiContra.Show();
                this.Close();
            }
        }

        private void listaCategorias_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void dataGridView_ListaDuplas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminarContrasenia_Click(object sender, System.EventArgs e)
        {
            if (0 < dataGridView_ListaDuplas.RowCount)
            {
                Dupla_UsuarioContrasenia duplaSeleccionada = (Dupla_UsuarioContrasenia)dataGridView_ListaDuplas.CurrentRow.DataBoundItem;
                usuario.RemoverDupla(duplaSeleccionada);
                CargarDuplas();
            }
        }
    }
}
