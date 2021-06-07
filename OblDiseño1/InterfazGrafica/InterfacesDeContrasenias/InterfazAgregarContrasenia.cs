using System.Windows.Forms;
using OblDiseño1.Entidades;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfacesDeContrasenias
{
    public partial class InterfazAgregarContrasenia : Form
    {
        private Usuario usuario;
        private Sistema sistema;
        public InterfazAgregarContrasenia(ref Sistema sistema, ref Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.sistema = sistema;
            AgregarCategorias();    
        }

        private void AgregarCategorias()
        {
            var bindingSource = new BindingSource();
            bindingSource.DataSource = usuario.ObtenerCategorias();
            this.comboBoxCategoria.DataSource = bindingSource.DataSource;
            this.comboBoxCategoria.SelectedIndex = 0;
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                DarDeAltaCredencial();
                IrAContraseñas();
            }
            catch (ExepcionDatosDeContraseniaInvalidos)
            {
                MostrarCualesSonLosDatosCorrectos();
            }
            catch (ExepcionInvalidUsuarioData)
            {
                MostrarMensajeUsuarioYaRegistrado();
            }
        }

        private void DarDeAltaCredencial()
        {
            string nombreUsuario = textBoxNombre.Text;
            string contrasenia = textBoxContrasenia.Text;
            string nombreSitio = textBoxNombreSitioApp.Text;
            string nota = textBoxNota.Text;

            Categoria categoria = (Categoria)comboBoxCategoria.SelectedItem;
            Contraseña contraseña = new Contraseña(contrasenia);
            Credencial credencial = new Credencial(nombreUsuario, contraseña, nombreSitio, nota, categoria);

            usuario.AgregarCredencial(credencial);

            MessageBox.Show("Se ha agregado la contraseña con éxito");
        }

        private void MostrarCualesSonLosDatosCorrectos()
        {
            MessageBox.Show("DATOS ERRONEOS. Por faver recuerde que la Contraseña " +
                "debe cumplir con el siguiente formato: " +
                "\n\n" +
                "> Nombre de Usuario: Mínimo 5 caracteres y máximo 25\n\n" +
                "> Contraseña: Mínimo 5 caracteres y máximo 25\n\n" +
                "> Sitio: Mínimo 3 caracteres y máximo 25\n\n" +
                "> Categoría: Se selecciona de las disponibles en el sistema");
        }

        private void MostrarMensajeUsuarioYaRegistrado()
        {
            MessageBox.Show("Error: este usuario ya esta registado para este sitio en el sistema");
        }

        private void btnCancelarCategoria_Click(object sender, EventArgs e)
        {
            IrAContraseñas();
        }

        private void IrAContraseñas()
        {
            InterfazContrasenia interfazContrasenia = new InterfazContrasenia(ref usuario, ref sistema);
            interfazContrasenia.Show();
            this.Close();
        }

        private void butto_GenerarContrasenia_Click(object sender, EventArgs e)
        {
            InterfazGenerarContrasenia generarContrasenia = new InterfazGenerarContrasenia();

            string nuevaContrasenia = "";
            generarContrasenia.ShowDialog();
            string posibleNuevaContra = generarContrasenia.ObtenerNuevaContrasenia();

            if (!posibleNuevaContra.Equals(""))
                nuevaContrasenia = generarContrasenia.ObtenerNuevaContrasenia();

            this.textBoxContrasenia.Text = nuevaContrasenia;
        }
    }
}
