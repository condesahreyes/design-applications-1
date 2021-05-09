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
    public partial class InterfazModificarTarjeta : Form
    {
        private Usuario usuario;
        private Sistema sistema;
        private Tarjeta tarjeta;

        public InterfazModificarTarjeta(ref Sistema sistema, ref Usuario usuario, ref Tarjeta tarjeta)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.sistema = sistema;
            this.tarjeta = tarjeta;
            List<string> categorias = usuario.ListarCategorias();
            for (int i = 0; i < categorias.Count; i++)
            {
                string categoriaMostrar = categorias[i];
                comboBoxCategorias.Items.Add(categoriaMostrar);
            }
            textBoxNombre.Text = tarjeta.Nombre;
            textBoxTipo.Text = tarjeta.Tipo;
            textBoxNumeroTarjeta.Text = tarjeta.Numero.ToString();
            textBoxCodigoSeguridad.Text = tarjeta.CodigoSeguridad.ToString();
            dateTimePicker1.Value = tarjeta.FechaVencimiento;
            comboBoxCategorias.Text = tarjeta.Categoria.Nombre;
            textBoxNotaOpcional.Text = tarjeta.NotaOpcional;
        }

        private void InterfazModificarTarjeta_Load(object sender, EventArgs e)
        {

        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            string nombreTarjeta = textBoxNombre.Text;
            string tipoTarjeta = textBoxTipo.Text;
            string numeroTarjeta = textBoxNumeroTarjeta.Text;
            string codigoSeguridad = textBoxCodigoSeguridad.Text;
            DateTime fecha = dateTimePicker1.Value;
            string nombreCategoria = comboBoxCategorias.Text;
            string notaOpcional = textBoxNotaOpcional.Text;

            int codigoSeguridadAConvertir = Int32.Parse(codigoSeguridad);
            Categoria categoria = new Categoria(nombreCategoria);

            this.tarjeta.Nombre = textBoxNombre.Text;
            this.tarjeta.Tipo = tipoTarjeta;
            this.tarjeta.Numero = numeroTarjeta;
            this.tarjeta.CodigoSeguridad = codigoSeguridadAConvertir;
            this.tarjeta.FechaVencimiento = fecha;
            this.tarjeta.Categoria = categoria;
            this.tarjeta.NotaOpcional = notaOpcional;

            this.Close();
            IrAInterfazTarjeta();

        }

        private void IrAInterfazTarjeta()
        {
            this.Close();
            InterfazTarjeta interfazTarjeta = new InterfazTarjeta(ref usuario, ref sistema);
            interfazTarjeta.Show();
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            InterfazTarjeta interfazTarjeta = new InterfazTarjeta(ref usuario, ref sistema);
            interfazTarjeta.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
