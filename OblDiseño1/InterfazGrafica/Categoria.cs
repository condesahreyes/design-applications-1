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
    public partial class Categoria : Form
    {
        public Categoria()
        {
            InitializeComponent();
        }

        private void agregarCat_Click(object sender, EventArgs e)
        {

        }

        private void modificarCat_Click(object sender, EventArgs e)
        {

        }

        private void catVolverMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void Categoria_Load(object sender, EventArgs e)
        {

        }
    }
}
