using OblDiseño1.ControladoresPorFuncionalidad;
using InterfazGrafica.InterfazDataBreaches;
using InterfazGrafica.InterfacesReporte;
using System.Collections.Generic;
using OblDiseño1.Entidades;
using System.Windows.Forms;
using AccesoDatos;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfacesDeContrasenias
{
    public partial class InterfazDeModificarContrasenia : Form
    {
        private Credencial credencial;
        private Usuario usuario;
        private Sistema sistema;

        private int nivelSeguridadContrasenia;

        private string interfazPadre;

        private const string posibleInterfazPadre_ReporteVer = "InterfazReporteVer";
        private const string posibleInterfazPadre_Contrasenia = "InterfazContrasenia";
        private const string posibleInterfazPadre_ChequeoDataBreaches = "InterfazChequeoDataBreaches";

        private IRepositorio<Credencial> repositorioCredencial;
        private IRepositorio<Contraseña> repositorioContraseña;
        private IRepositorio<Categoria> repositorioCategoria;

        private ControladorObtener controladorObtener;

        public InterfazDeModificarContrasenia(ref Usuario usuario, ref Sistema sistema,
            Credencial credencial, string padre)
        {
            this.usuario = usuario;
            this.sistema = sistema;
            this.credencial = credencial;
            this.interfazPadre = padre;

            this.repositorioCredencial = new CredencialRepositorio(this.usuario);
            this.repositorioContraseña = new ContraseñaRepositorio(this.usuario);
            this.repositorioCategoria = new CategoriaRepositorio(this.usuario);
            this.controladorObtener = new ControladorObtener();

            InitializeComponent();
            ColocarDatosEnLosCampos();
        }

        private void ColocarDatosEnLosCampos()
        {
            this.textBox_Usuario.Text = credencial.NombreUsuario;

            this.textBox_Sitio.Text = credencial.NombreSitioApp;

            List<Categoria> categorias = repositorioCategoria.GetAll();

            Credencial credencialPorBD = controladorObtener.ObtenerCredencial(credencial, repositorioCredencial);

            this.textBox_Contrasenia.Text = credencialPorBD.ObtenerContraseña;

            var bindingSource = new BindingSource();
            bindingSource.DataSource = categorias;
            this.comboBox_Categoria.DataSource = bindingSource.DataSource;
            SeleccionarCategoriaOriginal();
            this.richTextBox_Nota.Text = credencial.Nota;
        }

        private void SeleccionarCategoriaOriginal()
        {
            int indiceCatOriginal = -1;
            for (int i = 0; i < comboBox_Categoria.Items.Count; i++)
            {
                if (this.credencial.Categoria.Nombre.Equals(comboBox_Categoria.Items[i].ToString()))
                {
                    indiceCatOriginal = i;
                    break;
                }
            }
            this.comboBox_Categoria.SelectedIndex = indiceCatOriginal;
        }

        private void button_RevertirUsuario_Click(object sender, EventArgs e)
        {
            this.textBox_Usuario.Text = credencial.NombreUsuario;
        }

        private void button_RevertirContrasenia_Click(object sender, EventArgs e)
        {
            this.textBox_Contrasenia.Text = credencial.Contraseña.Contrasenia;
        }

        private void button_RevertirSitio_Click(object sender, EventArgs e)
        {
            this.textBox_Sitio.Text = credencial.NombreSitioApp;
        }

        private void button_RevertirNota_Click(object sender, EventArgs e)
        {
            this.richTextBox_Nota.Text = credencial.Nota;
        }

        private void button__RevertirCategoria_Click(object sender, EventArgs e)
        {
            SeleccionarCategoriaOriginal();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            CerrarVentana();
        }

        private void button_Aceptar_Click(object sender, EventArgs e)
        {

            string nuevoNombreUsuario = this.textBox_Usuario.Text;
            string nuevoNombreSitio = this.textBox_Sitio.Text;

            if (VerificarQueTengoCombinacionNombreSitio(nuevoNombreUsuario, nuevoNombreSitio) &&
                 (nuevoNombreUsuario != this.credencial.NombreUsuario || nuevoNombreSitio != this.credencial.NombreSitioApp))
            {
                MessageBox.Show("Error: ese Nombre de Uusario ya esta registrado para ese Sitio en el sistema");
            }
            else
            {
                ModificarContrasenia();
                MessageBox.Show("La contraseña se modifico correctamente");
                CerrarVentana();
            }
        }

        public bool VerificarQueTengoCombinacionNombreSitio(string nuevoNombreUsuario, string nuevoNombreSitio)
        {
            List<Credencial> credenciales = repositorioCredencial.GetAll();
            foreach (var credencial in credenciales)
            {
                if (credencial.NombreUsuario == nuevoNombreUsuario && credencial.NombreSitioApp == nuevoNombreSitio)
                    return true;
            }
            return false;
        }

        private void CerrarVentana()
        {
            switch (this.interfazPadre)
            {
                case posibleInterfazPadre_ReporteVer:
                    Reporte funcionalidad = new Reporte(usuario);
                    InterfazReporteVer interfazVer = new InterfazReporteVer(ref usuario, 
                        ref sistema, funcionalidad.ObtenerReporteSeguridadContrasenias(), nivelSeguridadContrasenia);
                    interfazVer.Show();
                    this.Close();
                    break;
                case posibleInterfazPadre_Contrasenia:
                    InterfazContrasenia interfazContra = new InterfazContrasenia(ref usuario, ref sistema);
                    interfazContra.Show();
                    this.Close();
                    break;
                case posibleInterfazPadre_ChequeoDataBreaches:
                    InterfazChequeoDataBreaches interfazDataBreaches = new InterfazChequeoDataBreaches(ref sistema, ref usuario);
                    interfazDataBreaches.Show();
                    this.Close();
                    break;
            }
        }

        private bool ModificarContrasenia()
        {
            bool seModificoCorrectamente = false;
            try
            {
                ModificarCredencial();
            }
            catch (ExepcionDatosDeContraseniaInvalidos)
            {
                seModificoCorrectamente = false;
                MostrarCualesSonLosDatosCorrector();
            }
            return seModificoCorrectamente;
        }

        private void ModificarCredencial()
        {
            string nombreNuevaCredencial = textBox_Usuario.Text;
            string contraseñaNuevaCredencial = textBox_Contrasenia.Text;
            string sitioNuevaCredencial = textBox_Sitio.Text;
            string notaNuevaCredencial = richTextBox_Nota.Text;

            Contraseña nuevaContraseña = new Contraseña(contraseñaNuevaCredencial);
            Categoria categoriaNuevaCredencial = (Categoria)this.comboBox_Categoria.SelectedItem;
            Credencial credencialAModificar = new Credencial(nombreNuevaCredencial, nuevaContraseña, 
                sitioNuevaCredencial, notaNuevaCredencial, categoriaNuevaCredencial);
            ControladorModificar controladorModificar = new ControladorModificar();

            controladorModificar.ModificarCredencial(this.credencial, credencialAModificar, repositorioCredencial);
        }

        private void MostrarCualesSonLosDatosCorrector()
        {
            MessageBox.Show("DATOS ERRONEOS. Por faver recuerde que la Contraseña " +
                "debe cumplir con el siguiente formato: " +
                "\n\n" +
                "> Nombre de Usuario: Mínimo 5 caracteres y máximo 25\n\n" +
                "> Contraseña: Mínimo 5 caracteres y máximo 25\n\n" +
                "> Sitio: Mínimo 3 caracteres y máximo 25\n\n" +
                "> Categoría: Se selecciona de las disponibles en el sistema"
                );
        }

        private void button_GenerarContrasenia_Click(object sender, EventArgs e)
        {
            string nuevaContra = this.textBox_Contrasenia.Text;
            InterfazGenerarContrasenia genContra = new InterfazGenerarContrasenia();
            genContra.ShowDialog();
            string posibleNuevaContra = genContra.ObtenerNuevaContrasenia();
            if (!posibleNuevaContra.Equals(""))
            {
                nuevaContra = genContra.ObtenerNuevaContrasenia();
            }
            this.textBox_Contrasenia.Text = nuevaContra;
        }
    }
}
