using System.Windows.Forms;
using OblDiseño1;
using System.IO;
using System;

namespace InterfazGrafica.InterfacesDataBreaches
{
    public partial class InterfazImportarDatosDesdeArchivoTxt : Form
    {
        private string rutaSeleccionada = "";

        public InterfazImportarDatosDesdeArchivoTxt()
        {
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
                if (VerificarQueEsTxt(rutaDelResultado))
                {
                    this.richTextBox_rutaDelArchivoSeleccionado.Text = rutaDelResultado;
                }
                else
                {
                    MessageBox.Show("ERROR: El archivo debe tener formato: .txt");
                }
            }
        }

        private bool VerificarQueEsTxt(string ruta)
        {
            string extencionTxt = ".txt";
            bool retorno = false;

            if (Path.HasExtension(ruta))
            {
                if (Path.GetExtension(ruta).Equals(extencionTxt))
                {
                    retorno = true;
                }
            }
            return retorno;
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
