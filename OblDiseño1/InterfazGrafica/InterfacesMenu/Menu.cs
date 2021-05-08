using OblDiseño1;
using System;
using System.Windows.Forms;
using InterfazGrafica.InterfazCategoria;
using InterfazGrafica.InterfacesDeTarjetas;
using InterfazGrafica.InterfacesDeContrasenias;

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
            //1* ESTO ES PARA TESTEAR LA INTERFAZ, SACAR ANTES DE ENTREGAR
            if (sistema.getHayQueCrearDatosDePrueba())
            {
                CargarTarjetasDeEjemplo();
                sistema.yaSeCrearonDatosDePruva();
            }
            //1* HASTA HACA


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
            this.Hide();
            InterfazContrasenia contrasenias = new InterfazContrasenia(ref usuario, ref sistema);
            contrasenias.Show();
        }

        private void btnTarjetas_Click(object sender, EventArgs e)
        {
            this.Hide();
            InterfazTarjeta tarjeta = new InterfazTarjeta(ref usuario, ref sistema);
            tarjeta.Show();
        }

        private void CargarTarjetasDeEjemplo()
        {
            Categoria primerCategoria = new Categoria("Personal");
            Categoria segundaCategoria = new Categoria("Trabajo");
            Categoria tercerCategoria = new Categoria("Web");


            Tarjeta primerTarjeta = new Tarjeta("Tarjeta BBVA Gold", "VISA", 1342768988934544, 721, new DateTime(2022, 09,17), primerCategoria, "Tarjeta de cobro de sueldo" );
            Tarjeta segundaTarjeta = new Tarjeta("Tarjeta ITAU", "MASTERCARD", 6726534165445561, 966, new DateTime(2028,03,15), segundaCategoria, "");
            Tarjeta tercerTarjeta = new Tarjeta("Black Brou", "MASTERCARD", 9347272233351211, 666, new DateTime(2031,02,09), primerCategoria, "Sin mucho que decir");
            Tarjeta cuartaTarjeta = new Tarjeta("HSBC Credito", "AMERICAN EXPRESS", 8888999936544567,255, new DateTime(2026,11,25), tercerCategoria,"");

            usuario.AgregarCategoria(primerCategoria);
            usuario.AgregarCategoria(segundaCategoria);
            usuario.AgregarCategoria(tercerCategoria);

            usuario.AgregarTarjeta(primerTarjeta);
            usuario.AgregarTarjeta(segundaTarjeta);
            usuario.AgregarTarjeta(tercerTarjeta);
            usuario.AgregarTarjeta(cuartaTarjeta);

        }
    }
}
