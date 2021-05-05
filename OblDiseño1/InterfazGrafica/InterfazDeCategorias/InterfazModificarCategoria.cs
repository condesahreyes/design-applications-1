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
        public InterfazModificarCategoria(ref Sistema sistema, ref Usuario usuario, ref Categoria categoria)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.sistema = sistema;
            this.categoria = categoria;
        }

        private void btnModificarCategoria_Click(object sender, System.EventArgs e)
        {


        }

        private void btnModificarCategoria_Click_1(object sender, System.EventArgs e)
        {
            string nuevoNombre = textBoxModificarCategoria.Text;
            this.categoria.setNombre(nuevoNombre);
            this.Close();
            InterfazCategorias categoria = new InterfazCategorias(ref usuario, ref sistema);
            categoria.Show();
        }
    }
}
