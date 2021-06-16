using OblDiseño1.ControladoresPorFuncionalidad;
using InterfazGrafica.InterfazCategoria;
using System.Collections.Generic;
using System.Windows.Forms;
using AccesoDatos;
using OblDiseño1;

namespace InterfazGrafica.InterfazDeCategorias
{
    public partial class InterfazModificarCategoria : Form
    {
        private Usuario usuario;
        private Sistema sistema;
        private Categoria categoria;

        private CategoriaRepositorio repositorioCategoria;

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

            repositorioCategoria = new CategoriaRepositorio(this.usuario);
        }

        private void btnModificarCategoria_Click_1(object sender, System.EventArgs e)
        {

            string nuevoNombre = textBoxModificarCategoria.Text;
            if (!YaExisteOtraCategoriaConEseNombre(nuevoNombre) || categoria.Nombre == nuevoNombre)
                try
                {
                    if (categoria.Nombre != nuevoNombre)
                    {
                        Categoria categoriaModificar = new Categoria(nuevoNombre);
                        ControladorModificar controladorModificar = new ControladorModificar();
                        controladorModificar.ModificarCategoria(this.categoria, categoriaModificar, repositorioCategoria);
                        this.categoria.ActualizarNombre(nuevoNombre);
                    }

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
            ControladorObtener controladorObtener = new ControladorObtener();
            List<Categoria> categorias = controladorObtener.ObtenerCategorias(repositorioCategoria);
            foreach (Categoria cat in categorias)
                if (cat.Nombre.ToLower() == nuevoNombreCategoria.ToLower())
                    return true;
            return false;
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
