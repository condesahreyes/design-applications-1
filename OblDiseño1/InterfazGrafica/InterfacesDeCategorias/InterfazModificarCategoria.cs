using OblDiseño1.ControladoresPorEntidad;
using InterfazGrafica.InterfazCategoria;
using System.Collections.Generic;
using System.Windows.Forms;
using OblDiseño1;

namespace InterfazGrafica.InterfazDeCategorias
{
    public partial class InterfazModificarCategoria : Form
    {
        private Usuario usuario;
        private Categoria categoria;
        private ControladorCategoria controladorCategoria;

        private string validacionNombre = "Error el " +
            "nombre de la categoría debe contener entre 3 a 15 caracteres.";
        private string modificadoCorrectamente = "El nombre de la categoría fue modificada con éxito.";

        public InterfazModificarCategoria(ref Usuario usuario, ref Categoria categoria)
        {
            InitializeComponent();

            this.usuario = usuario;
            this.categoria = categoria;
            this.textBoxModificarCategoria.Text = this.categoria.Nombre;

            controladorCategoria = new ControladorCategoria(this.usuario);
        }

        private void btnModificarCategoria_Click_1(object sender, System.EventArgs e)
        {
            string nuevoNombre = textBoxModificarCategoria.Text;
            if (!YaExisteOtraCategoriaConEseNombre(nuevoNombre) || categoria.Nombre == nuevoNombre)
                try
                {
                    if (categoria.Nombre != nuevoNombre)
                        controladorCategoria.ModificarCategoria(ref this.categoria, nuevoNombre);

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
            List<Categoria> categorias = controladorCategoria.ObtenerCategorias();

            foreach (Categoria cat in categorias)
                if (cat.Nombre.ToLower() == nuevoNombreCategoria.ToLower())
                    return true;

            return false;
        }

        private void IrACategoria()
        {
            this.Close();
            InterfazCategorias categoria = new InterfazCategorias(ref usuario);
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
