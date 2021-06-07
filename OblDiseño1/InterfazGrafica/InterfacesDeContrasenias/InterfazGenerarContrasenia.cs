using OblDiseño1.Entidades;
using System.Windows.Forms;
using System;

namespace InterfazGrafica.InterfacesDeContrasenias
{
    public partial class InterfazGenerarContrasenia : Form
    {
        private string contrasenia = "";
        private string msgErrorDebeContenerCasillas = "La contrasenia debe contener" +
            " al menos un tipo de caracter. Por favor marque una de las casillas.";

        public InterfazGenerarContrasenia()
        {
            InitializeComponent();
        }

        public string ObtenerNuevaContrasenia()
        {
            return this.contrasenia;
        }

        private void button_Confirmar_Click(object sender, EventArgs e)
        {
            if (FueMarcadoAlgunCheck())
            {
                GenerarLaContraseña();

                this.Close();
            }
            else
            {
                MessageBox.Show(msgErrorDebeContenerCasillas);
            }
        }

        private void GenerarLaContraseña()
        {
            bool[] caracteresReqeuridos = { checkBox_Mayusculas.Checked, checkBox_Minusculas.Checked,
                                                checkBox_Numeros.Checked, checkBox_Especiales.Checked};

            this.contrasenia = Contraseña.
                GenerarContrasenia((int)numericUpDown_cantCaracteres.Value, caracteresReqeuridos);
        }

        private bool FueMarcadoAlgunCheck()
        {
            return checkBox_Mayusculas.Checked || checkBox_Minusculas.Checked ||
                checkBox_Numeros.Checked || checkBox_Especiales.Checked;
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
