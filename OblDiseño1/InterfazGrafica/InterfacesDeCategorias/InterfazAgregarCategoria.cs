using OblDiseño1.ControladoresPorFuncionalidad;
using OblDiseño1.ControladoresPorEntidad;
using InterfazGrafica.InterfazCategoria;
using System.Windows.Forms;
using AccesoDatos;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfazDeCategorias
{
    public partial class InterfazAgregarCategoria : Form
    {
        private Usuario usuario;

        private CategoriaRepositorio repositorioCategoria;
        private ControladorCategoria controladorCategoria;

        public InterfazAgregarCategoria(ref Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;

            repositorioCategoria = new CategoriaRepositorio(this.usuario);
            controladorCategoria = new ControladorCategoria(this.usuario);
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Categoria categoria = CrearCategoria();

            if (categoria != null)
            {
                MessageBox.Show("Categoria '" + categoria.Nombre + "' creada con exito");
                IrACategoria();
            }
        }

        private Categoria CrearCategoria()
        {
            Categoria categoria = null;

            string nombreCategoria = textBoxNombreCategoria.Text;

            try
            {
                categoria = controladorCategoria.CrearCategoria(nombreCategoria);
            }
            catch (ExepcionInvalidCategoriaData)
            {
                MessageBox.Show("Error el nombre de la categoría debe contener entre 3 a 15 caracteres.");
            }
            catch (ExepcionObjetosRepetidos)
            {
                MessageBox.Show("Ya existe una categoría con este nombre.");
                textBoxNombreCategoria.Clear();
            }

            return categoria;
        }

        private void btnCancelarCategoria_Click(object sender, EventArgs e)
        {
            IrACategoria();
        }

        private void IrACategoria()
        {
            this.Close();
            InterfazCategorias categoria = new InterfazCategorias(ref usuario);
            categoria.Show();
        }
    }
}