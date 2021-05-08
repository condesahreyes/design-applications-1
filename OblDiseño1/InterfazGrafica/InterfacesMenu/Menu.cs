using OblDiseño1;
using System;
using System.Windows.Forms;
using InterfazGrafica.InterfazCategoria;
using InterfazGrafica.InterfacesDeTarjetas;
using InterfazGrafica.InterfacesDeContrasenias;
using InterfazGrafica.InterfazIngreso;
using InterfazGrafica.InterfazDataBreaches;

namespace InterfazGrafica.InterfacesMenu
{
    public partial class Menu : Form
    {
        Sistema sistema;
        Usuario usuario;

        public Menu(ref Sistema sistema, ref Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.sistema = sistema;
            Categoria categoria = new Categoria("juancito");
            usuario.AgregarCategoria(categoria);
            usuario.AgregarDupla(new Dupla_UsuarioContrasenia("nombre", "contraseña", "netflix", "", categoria));
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            this.Hide();
            InterfazCategorias categoria = new InterfazCategorias(ref this.usuario, ref this.sistema);
            categoria.Show();
        }

        private void btnContrasenias_Click(object sender, EventArgs e)
        {
            if (usuario.ObtenerCategorias().Count > 0)
            {
                this.Hide();
                InterfazContrasenia contrasenias = new InterfazContrasenia(ref usuario, ref sistema);
                contrasenias.Show();
            }
            else
                MessageBox.Show("Error, primero se debe registrar una Categoría para acceder a esta opción.");
        }

        private void btnTarjetas_Click(object sender, EventArgs e)
        {
            if (usuario.ObtenerCategorias().Count > 0)
            {
                this.Hide();
                InterfazTarjeta tarjeta = new InterfazTarjeta(ref usuario, ref sistema);
                tarjeta.Show();
            }
            else
                MessageBox.Show("Error, primero se debe registrar una Categoría para acceder a esta opción.");
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            InterfazIngresoSistema login = new InterfazIngresoSistema(ref sistema);
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            InterfazCambioContrasenia cambioContrasenia = new InterfazCambioContrasenia(ref sistema);
            cambioContrasenia.Show();
        }

        private void btnDataBreaches_Click(object sender, EventArgs e)
        {
            this.Close();
            InterfazChequeoDataBreaches dataBreaches = new InterfazChequeoDataBreaches(ref sistema, ref usuario);
            dataBreaches.Show();
        }
    }
}
