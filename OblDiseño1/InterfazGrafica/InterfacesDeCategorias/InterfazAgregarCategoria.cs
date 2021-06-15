using OblDiseño1.ControladoresPorFuncionalidad;
using InterfazGrafica.InterfazCategoria;
using System.Windows.Forms;
using AccesoDatos;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfazDeCategorias
{
    public partial class InterfazAgregarCategoria : Form
    {
        private Sistema sistema;
        private Usuario usuario;

        public InterfazAgregarCategoria(ref Sistema sistema, ref Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.sistema = sistema;
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Categoria categoria = CrearCategoria();

            if (categoria != null)
                try
                {
                    CategoriaRepositorio repositorioCategoria = new CategoriaRepositorio(this.usuario);
                    ControladorAlta controladorAlta = new ControladorAlta();
                    controladorAlta.AgregarCategoria(categoria, repositorioCategoria);

                    MessageBox.Show("Categoria '" + categoria.Nombre + "' creada con exito");
                    IrACategoria();
                }
                catch (ExepcionObjetosRepetidos)
                {
                    MessageBox.Show("Ya existe una categoría con este nombre.");
                    textBoxNombreCategoria.Clear();
                }
        }

        private Categoria CrearCategoria()
        {
            Categoria categoria = null;
            string nomCategoria = textBoxNombreCategoria.Text;

            try
            {
                categoria = new Categoria(nomCategoria);
            }
            catch (ExepcionInvalidCategoriaData)
            {
                MessageBox.Show("Error el nombre de la categoría debe contener entre 3 a 15 caracteres.");
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
            InterfazCategorias categoria = new InterfazCategorias(ref usuario, ref sistema);
            categoria.Show();
        }

        private void InterfazAgregarCategoria_Load(object sender, EventArgs e)
        {

        }
    }
}