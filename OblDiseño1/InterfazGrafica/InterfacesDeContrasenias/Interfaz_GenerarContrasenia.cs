using OblDiseño1;
using OblDiseño1.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazGrafica.InterfacesDeContrasenias
{
    public partial class Interfaz_GenerarContrasenia : Form
    {
        private Usuario usuario;
        private Sistema sistema;
        private string contrasenia = "";
        public Interfaz_GenerarContrasenia(ref Usuario usu, ref Sistema sist)
        {
            this.usuario = usu;
            this.sistema = sist;
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
