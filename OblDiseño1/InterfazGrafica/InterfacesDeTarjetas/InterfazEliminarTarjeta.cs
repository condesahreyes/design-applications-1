using OblDiseño1;
using System;
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


        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            usuario.EliminarTarjeta(tarjeta);
            IrAInterfazTarjeta();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            IrAInterfazTarjeta();
        }

        private void IrAInterfazTarjeta()
        {
            this.Close();
            InterfazTarjeta interfazTarjeta = new InterfazTarjeta(ref usuario, ref sistema);
            interfazTarjeta.Show();
        }
    }
}
