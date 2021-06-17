using Menu = InterfazGrafica.InterfacesMenu.Menu;
using InterfazGrafica.InterfazDeCategorias;
using OblDiseño1.ControladoresPorEntidad;
using System.Collections.Generic;
using System.Windows.Forms;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfazCategoria
{
    public partial class InterfazCategorias : Form
    {
        private Usuario usuario;

        private readonly string msgNoHayCategorias = "Error, no hay categorías para modificar";
        private readonly string msgSelecionarCategorias = "Error, debe seleccionar una categoría";

        public InterfazCategorias(ref Usuario usuario)
        {
            this.usuario = usuario;

            InitializeComponent();
            CargarLista();
        }

        private void CargarLista()
        {
            ControladorCategoria controladorCategoria = new 
                ControladorCategoria(this.usuario);

            List<Categoria> categorias = controladorCategoria.ObtenerCategorias();
            categorias.Sort();

            dataGridCategorias.DataSource = categorias;
        }

        private void btnCategoriaVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu(ref usuario);
            menu.Show();
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            this.Hide();
            InterfazAgregarCategoria agregarCategoria = new
                InterfazAgregarCategoria(ref usuario);
            agregarCategoria.Show();
        }

        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            if (HayCategorias())
                if (ObtenerCategoriaDelDataGrid() == null)
                    MessageBox.Show(msgSelecionarCategorias);
                else
                {
                    Categoria aModificar = ObtenerCategoriaDelDataGrid();
                    MostrarPantallaModificarCtagoria(ref aModificar);
                }
        }

        private bool HayCategorias()
        {
            bool cantidadCategoriaMayorA0 = (dataGridCategorias.RowCount > 0);

            if (!cantidadCategoriaMayorA0)
                MessageBox.Show(msgNoHayCategorias);

            return (dataGridCategorias.RowCount > 0) ? true : false;
        }

        private Categoria ObtenerCategoriaDelDataGrid()
        {
            return (Categoria)dataGridCategorias.CurrentRow.DataBoundItem;
        }

        private void MostrarPantallaModificarCtagoria(ref Categoria aModificar)
        {
            this.Hide();
            InterfazModificarCategoria modificarCategoria = new InterfazModificarCategoria
                (ref usuario, ref aModificar);
            modificarCategoria.Show();
        }
    }
}
