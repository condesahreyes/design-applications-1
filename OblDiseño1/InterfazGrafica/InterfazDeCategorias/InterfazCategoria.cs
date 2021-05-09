﻿using OblDiseño1;
using System;
using Menu = InterfazGrafica.InterfacesMenu.Menu;
using System.Windows.Forms;
using InterfazGrafica.InterfazDeCategorias;
using System.Collections.Generic;

namespace InterfazGrafica.InterfazCategoria
{
    public partial class InterfazCategorias : Form
    {
        private Usuario usuario;
        private Sistema sistema;

        public InterfazCategorias(ref Usuario usuario, ref Sistema sistema)
        {
            this.usuario = usuario;
            this.sistema = sistema;

            InitializeComponent();
            CargarLista();
        }

        private void CargarLista()
        {
            List<Categoria> categorias = usuario.ObtenerCategorias();
            categorias.Sort();

            dataGridCategorias.DataSource = categorias;
        }

        private void InterfazCategorias_Load(object sender, EventArgs e)
        {

        }

        private void btnCategoriaVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu(ref sistema, ref usuario);
            menu.Show();
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            this.Hide();
            InterfazAgregarCategoria agregarCategoria = new InterfazAgregarCategoria(ref sistema, ref usuario);
            agregarCategoria.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            if (dataGridCategorias.RowCount > 0)
            {
                var categoriaSeleccionada = dataGridCategorias.CurrentCell;

                if (categoriaSeleccionada == null)
                    MessageBox.Show("Error, debe seleccionar una categoría");
                else
                {
                    Categoria aModificar = ObtenerCategoriaDelDataGrid();
                    MostrarPantallaModificarCtagoria(ref aModificar);
                }
            }
            else
                MessageBox.Show("Error, no hay categorías para modificar");
        }

        private Categoria ObtenerCategoriaDelDataGrid()
        {
            return (Categoria)dataGridCategorias.CurrentRow.DataBoundItem;
        }

        private void MostrarPantallaModificarCtagoria(ref Categoria aModificar)
        {
            this.Hide();
            InterfazModificarCategoria modificarCategoria = new InterfazModificarCategoria
                (ref sistema, ref usuario, ref aModificar);
            modificarCategoria.Show();
        }

    }
}
