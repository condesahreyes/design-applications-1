using InterfazGrafica.InterfazCategoria;
using OblDiseño1;

using System.Windows.Forms;

namespace InterfazGrafica.InterfazDeCategorias
{
    public partial class InterfazModificarCategoria : Form
    {
        private Usuario usuario;
        private Sistema sistema;
        private Categoria categoria;

        private string validacionNombre = "Error el " +
            "nombre de la categoría debe contener entre 3 a 15 caracteres.";
        private string modificadoCorrectamente = "El nombre de la categoría fue modificada con éxito.";

        public InterfazModificarCategoria(ref Sistema sistema, ref Usuario usuario, ref Categoria categoria)
        {
            InitializeComponent();

            this.usuario = usuario;
            this.sistema = sistema;
            this.categoria = categoria;
            this.textBoxModificarCategoria.Text = this.categoria.Nombre;
        }

        private void btnModificarCategoria_Click_1(object sender, System.EventArgs e)
        {
            string nuevoNombre = textBoxModificarCategoria.Text;

            try
            {
                this.categoria.setNombre(nuevoNombre);
                MessageBox.Show(modificadoCorrectamente);
                IrACategoria();
            }
            catch (InvalidCategoriaDataException)
            {
                MessageBox.Show(validacionNombre);
            }
        }

        private void IrACategoria()
        {
            this.Close();
            InterfazCategorias categoria = new InterfazCategorias(ref usuario, ref sistema);
            categoria.Show();
        }

        private void btnCancelarModCategoria_Click(object sender, System.EventArgs e)
        {
            IrACategoria();
        }

        private void button_RevertirCambios_Click(object sender, System.EventArgs e)
        {
            this.textBoxModificarCategoria.Text = this.categoria.Nombre;
        }
    }
}
