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
            string nomCategoria = textBoxNombreCategoria.Text;
            Categoria categoria = new Categoria(nomCategoria);
            if (categoria != null)
            {
                usuario.AgregarCategoria(categoria);
                MessageBox.Show("Categoria '" + nomCategoria + "' creada con exito");
                this.Hide();
                InterfazCategorias categoriaInterfaz = new InterfazCategorias(ref usuario, ref sistema);
                categoriaInterfaz.Show();

            }
            else
            {
                MessageBox.Show("No se puede agregar");
                textBoxNombreCategoria.Clear();
            }
        }

        private void btnCancelarCategoria_Click(object sender, EventArgs e)
        {
            this.Hide();
            InterfazCategorias categoria = new InterfazCategorias(ref usuario, ref sistema);
            categoria.Show();
        }
    }
}
