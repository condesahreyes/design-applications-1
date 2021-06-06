using System;
using System.Windows.Forms;
using InterfazGrafica.InterfacesReporte;
using InterfazGrafica.InterfazDataBreaches;
using OblDiseño1;
using OblDiseño1.Entidades;

namespace InterfazGrafica.InterfacesDeContrasenias
{
    public partial class Interfaz_ModificarContrasenia : Form
    {
        private Usuario usuario;
        private Sistema sistema;
        private Credencial credencial;
        private string interfazPadre;
        private int nivelSeguridadContrasenia;

        const string posibleInterfazPadre_ReporteVer = "InterfazReporteVer";
        const string posibleInterfazPadre_Contrasenia = "InterfazContrasenia";
        const string posibleInterfazPadre_ChequeoDataBreaches = "InterfazChequeoDataBreaches";

        public Interfaz_ModificarContrasenia(ref Usuario usuario, ref Sistema sistema, Credencial credencial, string padre)
        {
            this.usuario = usuario;
            this.sistema = sistema;
            this.credencial = credencial;
            this.interfazPadre = padre;
            this.nivelSeguridadContrasenia = credencial.Contraseña.NivelSeguridadContrasenia;

            InitializeComponent();
            ColocarDatosEnLosCampos();
        }

        private void ColocarDatosEnLosCampos()
        {
            this.textBox_Usuario.Text = credencial.NombreUsuario;
            this.textBox_Contrasenia.Text = credencial.Contraseña.Contrasenia;
            this.textBox_Sitio.Text = credencial.NombreSitioApp;
            var bindingSource = new BindingSource();
            bindingSource.DataSource = usuario.ObtenerCategorias();
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
            if (HuboCambios())
            {
                string nuevoNombreUsuario = this.textBox_Usuario.Text;
                string nuevoNombreSitio = this.textBox_Sitio.Text;
                if (usuario.VerificarQueTengoCombinacionNombreSitio(nuevoNombreUsuario, nuevoNombreSitio) &&
                    (nuevoNombreUsuario != this.credencial.NombreUsuario || nuevoNombreSitio != this.credencial.NombreSitioApp))
                {
                    MessageBox.Show("Error: ese Nombre de Uusario ya esta registrado para ese Sitio en el sistema");
                }
                else
                {
                    if (ModificarContrasenia())
                    {
                        MessageBox.Show("La contraseña se modifico correctamente");
                        CerrarVentana();
                    }
                }
            }
            else
            {
                MessageBox.Show("No se realizaron cambios");
                CerrarVentana();
            }
        }

        private void CerrarVentana()
        {
            switch (this.interfazPadre)
            {
                case posibleInterfazPadre_ReporteVer:
                    FuncionalidadReporte funcionalidad = new FuncionalidadReporte(usuario);
                    InterfazReporteVer interfazVer = new InterfazReporteVer(ref usuario, ref sistema, funcionalidad.ObtenerReporteSeguridadContrasenias(), nivelSeguridadContrasenia);
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

        private bool HuboCambios()
        {
            bool seRealizaronCambios = false;
            if (!this.credencial.NombreUsuario.Equals(this.textBox_Usuario.Text))
            {
                seRealizaronCambios = true;
            }
            if (!this.credencial.Contraseña.Contrasenia.Equals(this.textBox_Contrasenia.Text))
            {
                seRealizaronCambios = true;
            }
            if (!this.credencial.NombreSitioApp.Equals(this.textBox_Sitio.Text))
            {
                seRealizaronCambios = true;
            }
            if (!this.credencial.Categoria.Equals((Categoria)this.comboBox_Categoria.SelectedItem))
            {
                seRealizaronCambios = true;
            }
            if (!this.credencial.Nota.Equals(this.richTextBox_Nota.Text))
            {
                seRealizaronCambios = true;
            }
            return seRealizaronCambios;
        }


        private bool ModificarContrasenia()
        {
            bool seModificoCorrectamente = false;
            try
            {
                if (!this.credencial.NombreUsuario.Equals(this.textBox_Usuario.Text))
                {
                    this.credencial.NombreUsuario = this.textBox_Usuario.Text;
                    seModificoCorrectamente = true;
                }
                if (!this.credencial.Contraseña.Contrasenia.Equals(this.textBox_Contrasenia.Text))
                {
                    this.credencial.Contraseña.Contrasenia = this.textBox_Contrasenia.Text;
                    seModificoCorrectamente = true;
                }
                if (!this.credencial.NombreSitioApp.Equals(this.textBox_Sitio.Text))
                {
                    this.credencial.NombreSitioApp = this.textBox_Sitio.Text;
                    seModificoCorrectamente = true;
                }
                if (!this.credencial.Categoria.Equals((Categoria)this.comboBox_Categoria.SelectedItem))
                {
                    this.credencial.Categoria = (Categoria)this.comboBox_Categoria.SelectedItem;
                    seModificoCorrectamente = true;
                }
                if (!this.credencial.Nota.Equals(this.richTextBox_Nota.Text))
                {
                    this.credencial.Nota = this.richTextBox_Nota.Text;
                    seModificoCorrectamente = true;
                }
            }
            catch (ExepcionDatosDeContraseniaInvalidos)
            {
                seModificoCorrectamente = false;
                MessageBox.Show("DATOS ERRONEOS. Por faver recuerde que la Contraseña " +
                                "debe cumplir con el siguiente formato: " +
                                "\n\n" +
                                "> Nombre de Usuario: Mínimo 5 caracteres y máximo 25\n\n" +
                                "> Contraseña: Mínimo 5 caracteres y máximo 25\n\n" +
                                "> Sitio: Mínimo 3 caracteres y máximo 25\n\n" +
                                "> Categoría: Se selecciona de las disponibles en el sistema"
                                );
            }
            return seModificoCorrectamente;
        }

        private void button_GenerarContrasenia_Click(object sender, EventArgs e)
        {
            string nuevaContra = this.textBox_Contrasenia.Text;
            Interfaz_GenerarContrasenia genContra = new Interfaz_GenerarContrasenia(ref sistema);
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
