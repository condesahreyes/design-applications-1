using System.Windows.Forms;
using OblDiseño1;
using System.IO;
using System;

namespace InterfazGrafica.InterfacesDataBreaches
{
    public partial class InterfazImportarDatosDesdeArchivoTxt : Form
    {
        private string rutaSeleccionada = "";
        private Sistema sistema;

        public InterfazImportarDatosDesdeArchivoTxt(ref Sistema sistema)
        {
            this.sistema = sistema;
            InitializeComponent();
        }

        private void button_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog navegadorDeArchivos = new OpenFileDialog();
            DialogResult resultado = navegadorDeArchivos.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                string rutaDelResultado = navegadorDeArchivos.FileName;
                this.richTextBox_rutaDelArchivoSeleccionado.Text = rutaDelResultado;
            }
        }


        private void button_Importar_Click(object sender, EventArgs e)
        {
            string stringVacio = "";
            string rutaSeleccionada = this.richTextBox_rutaDelArchivoSeleccionado.Text;
            if (rutaSeleccionada.Equals(stringVacio)){
                MessageBox.Show("ERROR: Debe seleccionar una archivo");
            }
            else
            {
                this.rutaSeleccionada = this.richTextBox_rutaDelArchivoSeleccionado.Text;
                this.Close();
            }
        }

        public string ObteneRutaSeleccionada()
        {
            return this.rutaSeleccionada;
        }
    }
}
