using OblDiseño1;
using OblDiseño1.Entidades;
using System;
using System.Windows.Forms;

namespace InterfazGrafica.InterfacesDeContrasenias
{
    public partial class Interfaz_GenerarContrasenia : Form
    {
        private Sistema sistema;
        private string contrasenia = "";
        public Interfaz_GenerarContrasenia(ref Sistema sistema)
        {
            this.sistema = sistema;
            InitializeComponent();
        }

        public string ObtenerNuevaContrasenia()
        {
            return this.contrasenia;
        }

        private void button_Confirmar_Click(object sender, EventArgs e)
        {
            
             
            if (checkBox_Mayusculas.Checked || checkBox_Minusculas.Checked || checkBox_Numeros.Checked || checkBox_Especiales.Checked)
            {
                bool[] caracteresReqeuridos = { checkBox_Mayusculas.Checked, checkBox_Minusculas.Checked, 
                                                checkBox_Numeros.Checked, checkBox_Especiales.Checked};
                this.contrasenia = Contraseña.GenerarContrasenia((int)numericUpDown_cantCaracteres.Value, caracteresReqeuridos);
                this.Close();
            }
            else
            {
                MessageBox.Show("La contrasenia debe contener al menos un tipo de caracter. Por favor marque una de las casillas.");
            }
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
