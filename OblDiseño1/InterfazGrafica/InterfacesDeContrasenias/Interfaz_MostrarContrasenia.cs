using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OblDiseño1;

namespace InterfazGrafica.InterfacesDeContrasenias
{
    public partial class Contraseña : Form
    {
        private Credencial credencial;
        public Contraseña(Credencial unaCredencial)
        {
            this.credencial = unaCredencial;
            InitializeComponent();
            ColocarContrasenia();
            IniziarCronometroParaAutodestruccion();
        }

        private void ColocarContrasenia()
        {
            this.textBox_contrasenia.Text = credencial.ObtenerContraseña;
        }

        private void IniziarCronometroParaAutodestruccion()
        {
            int tiempoMostrandoContrasenia_enMilisegundos = 30000;

            System.Windows.Forms.Timer unTimer = new System.Windows.Forms.Timer();
            unTimer.Tick += new EventHandler(button_Volver_Click);
            unTimer.Interval = tiempoMostrandoContrasenia_enMilisegundos;
            unTimer.Start();
        }

        private void button_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblListadoContrasenias_Click(object sender, EventArgs e)
        {

        }
    }
}
