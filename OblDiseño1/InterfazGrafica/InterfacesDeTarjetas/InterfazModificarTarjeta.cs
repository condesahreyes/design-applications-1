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

            CargarDatosViejos();
        }

        private void CargarDatosViejos()
        {
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
            string codigoSeguridad = textBoxCodigoSeguridad.Text;
            string nombreCategoria = comboBoxCategorias.Text;

            Categoria categoria = new Categoria(nombreCategoria);

            try
            {
                int codigoSeguridadAConvertir = Int32.Parse(codigoSeguridad);
                this.tarjeta.Nombre = textBoxNombre.Text;
                this.tarjeta.Tipo = textBoxTipo.Text;
                this.tarjeta.Numero = textBoxNumeroTarjeta.Text;
                this.tarjeta.CodigoSeguridad = codigoSeguridadAConvertir;
                this.tarjeta.FechaVencimiento = dateTimePicker1.Value;
                this.tarjeta.Categoria = categoria;
                this.tarjeta.NotaOpcional = textBoxNotaOpcional.Text;

                this.Close();
                IrAInterfazTarjeta();
            }
            catch (Exception TarjetaIncorrectaException)
            {
                MessageBox.Show("DATOS ERRONEOS.Por faver recuerde que la Tarjeta " +
                                "debe cumplir con el siguiente formato: " +
                                "\n\n" +
                                "> Nombre: Mínimo 3 y máximo 25 caracteres \n\n" +
                                "> Tipo: Mínimo 3 y máximo 25 caracteres \n\n" +
                                "> Número: Enteros de 16 dígitos\n\n" +
                                "> Código: Enteros de 3 o 4 dígitos\n\n" +
                                "> Fecha: No vacía\n\n" +
                                "> Nota: Como máximo 250 caracteress\n\n" +
                                "> Categoría: Se selecciona de las disponibles en el sistema");
            }
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
