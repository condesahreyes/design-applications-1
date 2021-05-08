using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterfazGrafica.InterfacesReporte;
using OblDiseño1;

namespace InterfazGrafica.InterfacesDeContrasenias
{
    public partial class Interfaz_ModificarContrasenia : Form
    {
        private Usuario usuario;
        private Sistema sistema;
        private Dupla_UsuarioContrasenia dupla;
        private string interfazPadre;
        private int nivelSeguridadContrasenia;


        public Interfaz_ModificarContrasenia(ref Usuario usuario, ref Sistema sistema, Dupla_UsuarioContrasenia dupla, string padre)
        {
            this.usuario = usuario;
            this.sistema = sistema;
            this.dupla = dupla;
            this.interfazPadre = padre;
            this.nivelSeguridadContrasenia = dupla.NivelSeguridadContrasenia;

            InitializeComponent();
            ColocarDatosEnLosCampos();
        }

        private void ColocarDatosEnLosCampos()
        {
            this.textBox_Usuario.Text = dupla.NombreUsuario;
            this.textBox_Contrasenia.Text = dupla.Contrasenia;
            this.textBox_Sitio.Text = dupla.NombreSitioApp;
            var bindingSource = new BindingSource();
            bindingSource.DataSource = usuario.ObtenerCategorias();
            this.comboBox_Categoria.DataSource = bindingSource.DataSource;
            this.richTextBox_Nota.Text = dupla.Nota;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label_Categoria_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_Categoria_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_RevertirUsuario_Click(object sender, EventArgs e)
        {
            this.textBox_Usuario.Text = dupla.NombreUsuario;
        }

        private void button_RevertirContrasenia_Click(object sender, EventArgs e)
        {
            this.textBox_Contrasenia.Text = dupla.Contrasenia;
        }

        private void button_RevertirSitio_Click(object sender, EventArgs e)
        {
            this.textBox_Sitio.Text = dupla.NombreSitioApp;
        }

        private void button_RevertirNota_Click(object sender, EventArgs e)
        {
            this.richTextBox_Nota.Text = dupla.Nota;
        }

        private void button__RevertirCategoria_Click(object sender, EventArgs e)
        {
            int indiceCatOriginal = -1;
            for (int i = 0; i < comboBox_Categoria.Items.Count; i++)
            {
                if (this.dupla.Categoria.Nombre.Equals(comboBox_Categoria.Items[i].ToString()))
                {
                    indiceCatOriginal = i;
                    break;
                }
            }
            this.comboBox_Categoria.SelectedIndex = indiceCatOriginal;
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            CerrarVentana();
        }

        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            if (ModificarContrasenia())
            {
                MessageBox.Show("La contrasenia se guardo correctamente");
                CerrarVentana();
            }
        }

        private void CerrarVentana()
        {
            switch (this.interfazPadre)
            {
                case "InterfazReporteVer":
                    InterfazReporteVer interfazVer = new InterfazReporteVer(ref usuario, ref sistema, usuario.ObtenerReporteSeguridadContrasenias(), nivelSeguridadContrasenia);
                    interfazVer.Show();
                    this.Close();
                    break;
                case "InterfazContrasenia":
                    InterfazContrasenia interfazContra = new InterfazContrasenia(ref usuario, ref sistema);
                    interfazContra.Show();
                    this.Close();
                    break;
            }
        }

        private bool ModificarContrasenia()
        {
            if (!this.dupla.NombreUsuario.Equals(this.textBox_Usuario.Text))
                this.dupla.NombreUsuario = this.textBox_Usuario.Text;
            if (!this.dupla.Contrasenia.Equals(this.textBox_Contrasenia.Text))
                this.dupla.Contrasenia = this.textBox_Contrasenia.Text;
            if (!this.dupla.NombreSitioApp.Equals(this.textBox_Sitio.Text))
                this.dupla.NombreSitioApp = this.textBox_Sitio.Text;
            if (!this.dupla.Categoria.Nombre.Equals((Categoria)this.comboBox_Categoria.SelectedItem))
                this.dupla.Categoria = (Categoria)this.comboBox_Categoria.SelectedItem;
            if (!this.dupla.Nota.Equals(this.richTextBox_Nota.Text))
                this.dupla.Nota = this.richTextBox_Nota.Text;

            return true;
        }

        private void button_GenerarContrasenia_Click(object sender, EventArgs e)
        {
            string nuevaContra = this.textBox_Contrasenia.Text;
            Interfaz_GenerarContrasenia genContra = new Interfaz_GenerarContrasenia(ref usuario, ref sistema);
            genContra.ShowDialog();
            nuevaContra = genContra.ObtenerNuevaContrasenia();
            this.textBox_Contrasenia.Text = nuevaContra;
        }
    }
}
