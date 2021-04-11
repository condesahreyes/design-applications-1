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
    public partial class Tarjeta : Form
    {
        public Tarjeta()
        {
            InitializeComponent();
        }

        private void Tarjeta_Load(object sender, EventArgs e)
        {

        }

        private void tarjetaVolverMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }
    }
}
