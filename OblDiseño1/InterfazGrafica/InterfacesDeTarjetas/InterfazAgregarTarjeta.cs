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
    public partial class InterfazAgregarTarjeta : Form
    {
        private Usuario usuario;
        private Sistema sistema;
        public InterfazAgregarTarjeta(ref Usuario usuario, ref Sistema sistema)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.sistema = sistema;
        }

        private void lblAgregarTarjeta_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            string nombreTarjeta = textBoxNombre.Text;
            string tipoTarjeta = textBoxTipo.Text;
            string numeroTarjeta = textBoxNumeroTarjeta.Text;
            string codigoSeguridad = textBoxCodigoSeguridad.Text;
            DateTime fecha = dateTimePicker1.Value;
            string nombreCategoria = textBoxCategoria.Text;
            string notaOpcional = textBoxNotaOpcional.Text;
            
            int codigoSeguridadAConvertir = Int32.Parse(codigoSeguridad);
            Categoria categoria = new Categoria(nombreCategoria);
            Tarjeta nuevaTarjeta = new Tarjeta(nombreTarjeta, tipoTarjeta, numeroTarjeta, codigoSeguridadAConvertir, fecha, categoria, notaOpcional);
            usuario.AgregarTarjeta(nuevaTarjeta);
            usuario.AgregarCategoria(categoria);
            IrAInterfazTarjeta();
        }

        private void IrAInterfazTarjeta()
        {
            this.Close();
            InterfazTarjeta interfazTarjeta = new InterfazTarjeta(ref usuario, ref sistema);
            interfazTarjeta.Show();
        }

            private void textBoxCodigoSeguridad_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCategoria_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelarTarjeta_Click(object sender, EventArgs e)
        {

        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            IrAInterfazTarjeta();
        }

        private void InterfazAgregarTarjeta_Load(object sender, EventArgs e)
        {

        }

        private void textBoxNumeroTarjeta_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


