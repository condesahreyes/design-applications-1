using OblDiseño1;
using System;
using System.Windows.Forms;
using InterfazGrafica.InterfazCategoria;
using InterfazGrafica.InterfacesDeTarjetas;
using InterfazGrafica.InterfacesDeContrasenias;
using InterfazGrafica.InterfacesReporte;
using InterfazGrafica.InterfazIngreso;
using InterfazGrafica.InterfazDataBreaches;
using InterfazGrafica.InterfazCompartirContraseñas;


namespace InterfazGrafica.InterfacesMenu
{
    public partial class Menu : Form
    {
        Sistema sistema;
        Usuario usuario;
    
        public Menu(ref Sistema sistema, ref Usuario usuario)
        {
            this.usuario = usuario;
            this.sistema = sistema;
            //1* ESTO ES PARA TESTEAR LA INTERFAZ, SACAR ANTES DE ENTREGAR
            if (sistema.getHayQueCrearDatosDePrueba())
            {
                CargarTarjetasDeEjemplo();
                CargarDatosDeEjemplo();
                 sistema.yaSeCrearonDatosDePruva();

            }

             InitializeComponent();
        }


        //1* ESTO ES PARA TESTEAR LA INTERFAZ, SACAR ANTES DE ENTREGAR
        private void CargarDatosDeEjemplo()
        {
            Categoria categoriaEjemplo1 = new Categoria("Personal"); 
            Categoria categoriaEjemplo2 = new Categoria("Laburo");
            Categoria categoriaEjemplo3 = new Categoria("Juegitos");


            Dupla_UsuarioContrasenia contra1 = new Dupla_UsuarioContrasenia("usua1", "aaaaaaa", "aaaaaa.aaa.aa", "aaaaaaaaaaaAAAAaaa", categoriaEjemplo1);
            Dupla_UsuarioContrasenia contra2 = new Dupla_UsuarioContrasenia("usua2", "bbbbbbbbbbbb", "bbbbbb.aaa.aa", "bbbbAAAAbbbbb", categoriaEjemplo1);
            Dupla_UsuarioContrasenia contra3 = new Dupla_UsuarioContrasenia("usua3", "ccccccccccccccccc", "cccccc.aaa.aa", "cccAAAAc", categoriaEjemplo1);
            Dupla_UsuarioContrasenia contra4 = new Dupla_UsuarioContrasenia("usua4", "dddddddddddDDDDDD", "dddddd.aaa.aa", "dAAAAddd", categoriaEjemplo1);
            Dupla_UsuarioContrasenia contra5 = new Dupla_UsuarioContrasenia("usua5", "EEE!!EEEeeeee1111", "eeeeee.aaa.aa", "eeeAAAAe", categoriaEjemplo1);
            Dupla_UsuarioContrasenia contra6 = new Dupla_UsuarioContrasenia("usua6", "ffffffFFFFFF111", "ffffff.aaa.aa", "ffAAAAff!!", categoriaEjemplo1);
            Dupla_UsuarioContrasenia contra7 = new Dupla_UsuarioContrasenia("usua7", "gggggGGGGGG222222", "aaaaaa.aaa.aa", "ggAAAAgg", categoriaEjemplo1);
            Dupla_UsuarioContrasenia contra13 = new Dupla_UsuarioContrasenia("usua8", "gggggGGGGGG$$$222", "aaaaaa.aaa.aa", "ggAAAgg", categoriaEjemplo1);
            Dupla_UsuarioContrasenia contra8 = new Dupla_UsuarioContrasenia("cuenta1", "aaaaaa", "aaaaaa.aaa.aa", "aaaaaaaaaaaAAAAa", categoriaEjemplo2);
            Dupla_UsuarioContrasenia contra9 = new Dupla_UsuarioContrasenia("cuenta2", "aaAAAAAAAAA222@@@aaa", "aaaaaa.aaa.aa", "aa", categoriaEjemplo3);
            Dupla_UsuarioContrasenia contra0 = new Dupla_UsuarioContrasenia("cuenta3", "aaaaAAAAAAAAAAAAAAAaa", "aaaaaa.aaa.aa", "a", categoriaEjemplo2);
            Dupla_UsuarioContrasenia contra10 = new Dupla_UsuarioContrasenia("cuenta4", "aaaaVV11212DFE1!!1a", "aaaaaa.aaa.aa", "aa", categoriaEjemplo3);
            Dupla_UsuarioContrasenia contra11 = new Dupla_UsuarioContrasenia("cuenta5", "aaaAAAAaaa", "aaaaaa.aaa.aa", "aaaaaaaaaaa", categoriaEjemplo2);
            Dupla_UsuarioContrasenia contra12 = new Dupla_UsuarioContrasenia("cuenta6", "aa@#$#@EFWEEW3331aaa", "aaaaaa.aaa.aa", "a", categoriaEjemplo3);
            //  public Dupla_UsuarioContrasenia(string unNombreUsuario, string unaContrasenia, 
            //string unSitio, string laNota, Categoria laCategoria)

            this.usuario.AgregarCategoria(categoriaEjemplo1);
            this.usuario.AgregarCategoria(categoriaEjemplo2);
            this.usuario.AgregarCategoria(categoriaEjemplo3);

            this.usuario.AgregarDupla(contra1);
            this.usuario.AgregarDupla(contra2);
            this.usuario.AgregarDupla(contra3);
            this.usuario.AgregarDupla(contra4);
            this.usuario.AgregarDupla(contra5);
            this.usuario.AgregarDupla(contra6);
            this.usuario.AgregarDupla(contra7);
            this.usuario.AgregarDupla(contra8);
            this.usuario.AgregarDupla(contra9);
            this.usuario.AgregarDupla(contra0);
            this.usuario.AgregarDupla(contra10);
            this.usuario.AgregarDupla(contra11);
            this.usuario.AgregarDupla(contra12);
            this.usuario.AgregarDupla(contra13);
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

        private void btnReportes_Click(object sender, EventArgs e)
        {
            InterfazReporte reporte = new InterfazReporte(ref usuario, ref sistema);
            reporte.Show();
            this.Close();
        }

        private void CargarTarjetasDeEjemplo()
        {
            Categoria primerCategoria = new Categoria("Personalsssd");
            Categoria segundaCategoria = new Categoria("Trabajossds");
            Categoria tercerCategoria = new Categoria("Websdsd");


            Tarjeta primerTarjeta = new Tarjeta("Tarjeta BBVA Gold", "VISA", "1342768988934544", 721, new DateTime(2022, 09,17), primerCategoria, "Tarjeta de cobro de sueldo" );
            Tarjeta segundaTarjeta = new Tarjeta("Tarjeta ITAU", "MASTERCARD", "6726534165445561", 966, new DateTime(2028,03,15), segundaCategoria, "");
            Tarjeta tercerTarjeta = new Tarjeta("Black Brou", "MASTERCARD", "9347272233351211", 666, new DateTime(2031,02,09), primerCategoria, "Sin mucho que decir");
            Tarjeta cuartaTarjeta = new Tarjeta("HSBC Credito", "AMERICAN EXPRESS", "8888999936544567",255, new DateTime(2026,11,25), tercerCategoria,"");

            usuario.AgregarCategoria(primerCategoria);
            usuario.AgregarCategoria(segundaCategoria);
            usuario.AgregarCategoria(tercerCategoria);

            usuario.AgregarTarjeta(primerTarjeta);
            usuario.AgregarTarjeta(segundaTarjeta);
            usuario.AgregarTarjeta(tercerTarjeta);
            usuario.AgregarTarjeta(cuartaTarjeta);

        }

        private void btnCompartirContrasenia_Click(object sender, EventArgs e)
        {
            this.Close();
            InterfazContraseñasCompartidas interfazContraseñas = new InterfazContraseñasCompartidas(ref sistema, ref usuario);
            interfazContraseñas.Show();
        }

        private void buttonContraseñasCompartidasConmigo_Click(object sender, EventArgs e)
        {

        }
    }
}
