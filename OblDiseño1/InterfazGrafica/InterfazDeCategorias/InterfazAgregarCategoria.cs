using InterfazGrafica.InterfazCategoria;
using OblDiseño1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazGrafica.InterfazDeCategorias
{
    public partial class InterfazAgregarCategoria : Form
    {
        Sistema sistema;
        Usuario usuario;
        public InterfazAgregarCategoria(ref Sistema sistema, ref Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.sistema = sistema;
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Categoria categoria = CrearCategoria();
            AgregarAMisCategorias(categoria);
        }

        private void AgregarAMisCategorias(Categoria categoria)
        {
            if (categoria != null)
                try
                {
                    usuario.AgregarCategoria(categoria);
                    MessageBox.Show("Categoria '" + categoria.Nombre + "' creada con exito");
                    IrACategoria();
                }
                catch (DuplicateNameException)
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
            catch(InvalidCategoriaDataException)
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
    }
}
