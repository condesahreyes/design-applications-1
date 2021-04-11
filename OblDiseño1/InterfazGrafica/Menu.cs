using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazGrafica
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void categoria_Click(object sender, EventArgs e)
        {
            this.Hide();
            Categoria categoria = new Categoria();
            categoria.Show();
        }

        private void duplasPss_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsuarioContrasenia usuarioContrasenia = new UsuarioContrasenia();
            usuarioContrasenia.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
