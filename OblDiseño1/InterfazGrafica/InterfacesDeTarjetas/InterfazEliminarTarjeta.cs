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

namespace InterfazGrafica.InterfacesDeTarjetas
{
    public partial class InterfazEliminarTarjeta : Form
    {
        private Usuario usuario;
        private Sistema sistema;
        private Tarjeta tarjeta;
        public InterfazEliminarTarjeta(ref Sistema sistema, ref Usuario usuario, ref Tarjeta tarjeta)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.sistema = sistema;
            this.tarjeta = tarjeta;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            usuario.EliminarTarjeta(tarjeta);
            this.Close();
            InterfazTarjeta interfazTarjeta = new InterfazTarjeta(ref usuario, ref sistema);
            interfazTarjeta.Show();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            InterfazTarjeta interfazTarjeta = new InterfazTarjeta(ref usuario, ref sistema);
            interfazTarjeta.Show();
        }
    }
}
