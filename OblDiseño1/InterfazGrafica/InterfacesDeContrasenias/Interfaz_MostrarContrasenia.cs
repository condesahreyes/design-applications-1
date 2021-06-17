using System.Windows.Forms;
using OblDiseño1;
using System;

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
    }
}
