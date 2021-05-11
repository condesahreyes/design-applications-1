using OblDiseño1;
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

        private readonly string msgNoHayCategorias= "Error, no hay categorías para modificar";
        private readonly string msgSelecionarCategorias= "Error, debe seleccionar una categoría";

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
                (ref sistema, ref usuario, ref aModificar);
            modificarCategoria.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
