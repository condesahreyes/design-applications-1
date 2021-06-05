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
            if (YaExisteOtraCategoriaConEseNombre(nuevoNombre) || categoria.Nombre==nuevoNombre) 
                try
                {
                    this.categoria.ActualizarNombre(nuevoNombre);
                    MessageBox.Show(modificadoCorrectamente);
                    IrACategoria();
                }
                catch (ExepcionInvalidCategoriaData)
                {
                    MessageBox.Show(validacionNombre);
                }
            else
                MessageBox.Show("Ya existe una categoría con este nombre.");

        }

        private bool YaExisteOtraCategoriaConEseNombre(string nuevoNombreCategoria)
        {
            foreach (Categoria cat in usuario.ObtenerCategorias())
                if (cat.Nombre.ToLower() == nuevoNombreCategoria.ToLower())
                    return false;
            return true;
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
